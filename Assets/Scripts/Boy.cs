using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Boy : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public UnityEvent OnPlayerHitted;
    public Transform groundCheck;
    public GameObject suckerTrash;
    public Joystick joystick;
    public MobileButton ButtonRun;
    public TextMeshProUGUI pointsLabel;
    public Transform startPlayerPosition;

    private bool isGrounded;
    private bool isMobile;
    public bool isGameRunning;
    public int points = 0;

    public float walkingSpeed = 4;
    public float runSpeed = 6;
    public float jumpSpeed = 6;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        isGameRunning = true;
        isMobile = MobileTest();
    }

    public void SetActive()
    {
        isGameRunning = true;
        gameObject.transform.localPosition = startPlayerPosition.localPosition;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        points = 0;
    }

    void Update()
    {
        suckerTrash.transform.position = new Vector2(transform.position.x, transform.position.y);
       
        pointsLabel.text = points.ToString();
    }

    private void FixedUpdate()
    {
        if (isGameRunning)
        {
            // JUMP TEST
            if (Physics2D.Linecast(transform.position, groundCheck.position, -1 << LayerMask.NameToLayer("Ground")))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
                animator.Play("Player_Jumping");
            }

            if (Input.GetKey("space") && isGrounded)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);

            }
        }

        if (isMobile)
        {
            if (isGameRunning)
            {
                if (joystick.Horizontal > 0f && joystick.Horizontal < 0.4f)
                {
                    rigidbody2D.velocity = (new Vector2(walkingSpeed, rigidbody2D.velocity.y));
                    if (isGrounded)
                        animator.Play("Player_Walking");
                    spriteRenderer.flipX = false;
                }
                else if (joystick.Horizontal > 0.4f)
                {
                    rigidbody2D.velocity = (new Vector2(runSpeed, rigidbody2D.velocity.y));
                    if (isGrounded)
                        animator.Play("Player_Running");
                    spriteRenderer.flipX = false;
                }
                else if (joystick.Horizontal < 0f && joystick.Horizontal > -0.4f)
                {
                    rigidbody2D.velocity = (new Vector2(-walkingSpeed, rigidbody2D.velocity.y));
                    if (isGrounded)
                        animator.Play("Player_Walking");
                    spriteRenderer.flipX = true;
                }
                else if (joystick.Horizontal < -0.4f && joystick.Horizontal != 0)
                {
                    rigidbody2D.velocity = (new Vector2(-runSpeed, rigidbody2D.velocity.y));
                    if (isGrounded)
                        animator.Play("Player_Running");
                    spriteRenderer.flipX = true;
                }
                else
                {
                    if (isGrounded)
                        animator.Play("Player_Iddle");
                    rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y); //CANCELA A FORCA DA CAMINHADA - PAROU DE ANDAR
                }
            }
        }
        else
        {
            if (isGameRunning)
            {
                // WALKING TEST L AND R 
                if (Input.GetKey("d") && !Input.GetKey(KeyCode.LeftControl) || Input.GetKey("right") && !Input.GetKey(KeyCode.LeftControl))
                {
                    rigidbody2D.velocity = new Vector2(walkingSpeed, rigidbody2D.velocity.y);
                    if (isGrounded)
                        animator.Play("Player_Walking");
                    spriteRenderer.flipX = false;
                    

                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey("d") || Input.GetKey(KeyCode.LeftControl) && Input.GetKey("right")) // CORRIDA
                {
                    if (isGrounded)
                    {
                        rigidbody2D.velocity = new Vector2(runSpeed, rigidbody2D.velocity.y);
                        animator.Play("Player_Running");
                        spriteRenderer.flipX = false;
                        
                    }
                }
                else if (Input.GetKey("a") && !Input.GetKey(KeyCode.LeftControl) || Input.GetKey("left") && !Input.GetKey(KeyCode.LeftControl))
                {
                    rigidbody2D.velocity = new Vector2(-walkingSpeed, rigidbody2D.velocity.y);

                    if (isGrounded)
                        animator.Play("Player_Walking");
                    spriteRenderer.flipX = true;

                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey("a") || Input.GetKey(KeyCode.LeftControl) && Input.GetKey("left")) // CORRIDA
                {
                    if (isGrounded)
                    {
                        rigidbody2D.velocity = new Vector2(-runSpeed, rigidbody2D.velocity.y);
                        animator.Play("Player_Running");
                        spriteRenderer.flipX = true;
                    }
                }
                else
                {
                    if (isGrounded && !isMobile)
                        animator.Play("Player_Iddle");
                    rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y); //CANCELA A FORCA DA CAMINHADA - PAROU DE ANDAR
                }
            }
        }
    }

    private bool MobileTest()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        float aux = canvas.transform.localScale.x;
        if (aux < 0.8f)
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ELIMINACAO DO LIXO
        if (collision.gameObject.tag.Equals("Trash") && Input.GetMouseButton(0))
        {
            collision.gameObject.SetActive(false);
            Coin lixinhos = collision.gameObject.GetComponent<Coin>();
            lixinhos.flyToCat = false;
            points += 1;
        }

        // COLISAO COM O INIMIGO
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            if (!isGrounded)
            {
                animator.Play("Player_Jumping");
            }
            else
            {
                animator.Play("Player_Iddle");
            }

            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            OnPlayerHitted.Invoke();
            isGameRunning = false;
        }

        if (collision.gameObject.name.Equals("DeadZone"))
        {
            OnPlayerHitted.Invoke();
            gameObject.SetActive(false);
        }
    }
}
