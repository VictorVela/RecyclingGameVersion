using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
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
    public GameObject desableSceneP;
    public GameObject startSceneP;
    public GameObject trashCollectorPlayer;
    public GameObject colliderTrashTest;

    private bool isGrounded;
    private bool isMobile;
    public bool isGameRunning;
    public bool canPause;
    public int points = 0;
    private Camera camera;
    public float bkpCamera= -8;

    public float walkingSpeed = 4;
    public float runSpeed = 6;
    public float jumpSpeed = 6;
    public float desableSceneXPosition;
    public float startSceneXPosition;
    public float trashCollectorSceneXPosition;

    public int trashInRiver = 0;
    private bool inRiver;
    public bool inBoat;

    // Start is called before the first frame update
    void Start()
    {
         camera = FindObjectOfType<Camera>();

        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        isGameRunning = true;
        inRiver = false;
        isMobile = MobileTest();
        inBoat = false;
        canPause = false;
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
        if (!inRiver)
        {
            suckerTrash.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        else
        {
            suckerTrash.transform.position = new Vector2(transform.position.x, transform.position.y - 0.8f);
        }
        
        if (!gameObject.scene.name.Equals("Fase02"))
        {
            desableSceneP.transform.position = new Vector2(transform.position.x - desableSceneXPosition, desableSceneP.transform.position.y);
            startSceneP.transform.position = new Vector2(transform.position.x + startSceneXPosition, startSceneP.transform.position.y);
            trashCollectorPlayer.transform.position = new Vector2(transform.position.x - trashCollectorSceneXPosition, trashCollectorPlayer.transform.position.y);
        }
            
        pointsLabel.text = points.ToString();

        // OBJETOS PARA TRATAMENTO DE CENA SEGUIREM O PLAYER
        
        PointScreen.pointPlayer = points;
    }

    private void FixedUpdate()
    {
        if (PersonSelect.pause)
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            canPause = true;
        }
        else
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (canPause)
            {
                rigidbody2D.velocity = new Vector2(walkingSpeed, rigidbody2D.velocity.y + 0.1f);
                canPause = false;
            }
                
        }

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

            if (Input.GetKey("space") && isGrounded || Input.GetKey("x") && isGrounded)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);

            }
        }

        if (isMobile)
        {
            if (isGameRunning)
            {
                if (joystick.Vertical > 0.3f && isGrounded)
                {
                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);

                }

                if (joystick.Horizontal > 0f && joystick.Horizontal < 0.4f)
                {
                    rigidbody2D.velocity = (new Vector2(walkingSpeed, rigidbody2D.velocity.y));
                    if (isGrounded)
                        animator.Play("Player_Walking");
                    if(!PersonSelect.pause)
                    spriteRenderer.flipX = false;
                }
                else if (joystick.Horizontal > 0.4f)
                {
                    rigidbody2D.velocity = (new Vector2(runSpeed, rigidbody2D.velocity.y));
                    if (isGrounded)
                        animator.Play("Player_Running");
                    if (!PersonSelect.pause)
                        spriteRenderer.flipX = false;
                }
                else if (joystick.Horizontal < 0f && joystick.Horizontal > -0.4f)
                {
                    rigidbody2D.velocity = (new Vector2(-walkingSpeed, rigidbody2D.velocity.y));
                    if (isGrounded)
                        animator.Play("Player_Walking");
                    if (!PersonSelect.pause)
                        spriteRenderer.flipX = true;
                }
                else if (joystick.Horizontal < -0.4f && joystick.Horizontal != 0)
                {
                    rigidbody2D.velocity = (new Vector2(-runSpeed, rigidbody2D.velocity.y));
                    if (isGrounded)
                        animator.Play("Player_Running");
                    if (!PersonSelect.pause)
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
                if (   Input.GetKey("d") && !Input.GetKey(KeyCode.LeftControl) || Input.GetKey("right") && !Input.GetKey("z"))
                {
                    rigidbody2D.velocity = new Vector2(walkingSpeed, rigidbody2D.velocity.y);
                    if (isGrounded)
                        animator.Play("Player_Walking");
                    if (!PersonSelect.pause)
                        spriteRenderer.flipX = false;
                    if (transform.position.x > bkpCamera)
                        bkpCamera = transform.position.x;

                }
                else if (  Input.GetKey(KeyCode.LeftControl) && Input.GetKey("d") || Input.GetKey("z") && Input.GetKey("right")) // CORRIDA
                {
                    if (isGrounded)
                    {
                        rigidbody2D.velocity = new Vector2(runSpeed, rigidbody2D.velocity.y);
                        animator.Play("Player_Running");
                        if (!PersonSelect.pause)
                            spriteRenderer.flipX = false;
                        if(transform.position.x > bkpCamera)
                        bkpCamera = transform.position.x;
                    }
                }
                else if (Input.GetKey("a") && !Input.GetKey(KeyCode.LeftControl) || Input.GetKey("left") && !Input.GetKey("z"))
                {
                    rigidbody2D.velocity = new Vector2(-walkingSpeed, rigidbody2D.velocity.y);
                    
                    if (isGrounded)
                        animator.Play("Player_Walking");
                    if (!PersonSelect.pause)
                        spriteRenderer.flipX = true;

                }
                else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey("a") || Input.GetKey("z") && Input.GetKey("left")) // CORRIDA
                {
                    if (isGrounded)
                    {
                        rigidbody2D.velocity = new Vector2(-runSpeed, rigidbody2D.velocity.y);
                        animator.Play("Player_Running");
                        if (!PersonSelect.pause)
                            spriteRenderer.flipX = true;
                    }
                }
                else
                {
                    if (isGrounded && !isMobile)
                        animator.Play("Player_Iddle");
                    if(!inBoat)
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
        } return false;
    }

    private void dataExportTest()
    {
        print(gameObject.scene.name.ToString() + " - " + points + "sementes");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ELIMINACAO DO LIXO
        if (collision.gameObject.tag.Equals("Trash") && Input.GetMouseButton(0) || collision.gameObject.tag.Equals("Trash") && Input.GetKey("c"))
        {
            if (collision.gameObject.layer.Equals(13))
            {
                trashInRiver += 1;
            }

            //print(gameObject.transform.Find("GameObject").gameObject.name);
            collision.gameObject.SetActive(false);
            Coin lixinhos = collision.gameObject.GetComponent<Coin>();
            lixinhos.flyToCat = false;
            points += 1;
            GetComponent<AudioSource>().Play();

            
        }

        // COLISAO COM O INIMIGO
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            if(!isGrounded)
            {
                animator.Play("Player_Jumping");
            }
            else
            {
                animator.Play("Player_Iddle");
            }

            //dataExportTest();
            if (!gameObject.scene.name.Equals("Fase01"))
            {
                collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            }

            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            PointScreen.pointPlayer = points;
            OnPlayerHitted.Invoke();
            isGameRunning = false;
        }

        if (collision.gameObject.name.Equals("DeadZone"))
        {
            PointScreen.pointPlayer = points;
            OnPlayerHitted.Invoke();
            gameObject.SetActive(false);

            //dataExportTest();
            camera.transform.position = camera.transform.position;
        }

        if (collision.gameObject.tag.Equals("DeadZone"))
        {
            PointScreen.pointPlayer = points;
            OnPlayerHitted.Invoke();
            gameObject.SetActive(false);

            //dataExportTest();
            //camera.transform.position = camera.transform.position;
        }

        if (collision.gameObject.tag.Equals("NormalTrahSucker"))
        {
            inRiver = false;
        }

        if (collision.gameObject.tag.Equals("Tronco"))
        {
            inRiver = true;
        }
    }
}
