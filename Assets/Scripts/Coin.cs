using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	Rigidbody2D rb;
	GameObject player;
	Vector2 catDirection;
	float timeStamp;
	public bool flyToCat = false;

	GameObject buttonGO;
	MobileButton button;

	void Start()
	{
		player = FindObjectOfType<Player>().gameObject;
		rb = GetComponent<Rigidbody2D> ();
		buttonGO = GameObject.Find("/Canvas/MobileControls/ButtonSucker");
		if(buttonGO)
			button = buttonGO.GetComponent<MobileButton>();
	}

    private void FixedUpdate()
    {
        if (button)
        {
			if (flyToCat && button.pressing)
			{
				//catDirection = -(transform.position - player.gameObject.GetComponent<Player>().colliderTrashTest.transform.position).normalized;
				catDirection = -(transform.position - player.transform.position).normalized;
				rb.velocity = new Vector2(catDirection.x, catDirection.y) * 48f * (Time.time / timeStamp);
				
			}
		}
	}

    void Update()
	{
		//if(gameObject.scene.name.Equals("Fase02"))
		player = FindObjectOfType<Player>().gameObject;

		if (player.transform.position.x > gameObject.transform.position.x && player.GetComponent<SpriteRenderer>().flipX.Equals(false))
        {
			flyToCat = false;
        }

		if (flyToCat && Input.GetMouseButton(0) || flyToCat && Input.GetKey("c"))
		{
			catDirection = - (transform.position - player.gameObject.GetComponent<Player>().colliderTrashTest.transform.position).normalized;
			rb.velocity = new Vector2 (catDirection.x, catDirection.y) * 48f * (Time.time / timeStamp);
			
		}

		Collider2D[] objetosNoRaioDeAlcance = Physics2D.OverlapCircleAll(transform.position, 0.06f, 1);
		foreach (Collider2D targetCollider in objetosNoRaioDeAlcance)
		{
			if (Input.GetMouseButton(0) && targetCollider.gameObject.name.Equals("Player") 
				|| Input.GetMouseButton(0) && targetCollider.gameObject.name.Equals("Boy") 
				|| Input.GetMouseButton(0) && targetCollider.gameObject.name.Equals("Girl")
				|| Input.GetKey("c") && targetCollider.gameObject.name.Equals("Player") 
				|| Input.GetKey("c") && targetCollider.gameObject.name.Equals("Boy") 
				|| Input.GetKey("c") && targetCollider.gameObject.name.Equals("Girl"))
			{
				targetCollider.gameObject.GetComponent<Player>().points += 1;

				gameObject.SetActive(false);
				flyToCat = false;
				player.GetComponent<AudioSource>().Play();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals ("SuckerTrash") || col.gameObject.name.Equals("SuckerTrashByGirl")) {
			timeStamp = Time.time;
			player = GameObject.Find ("Player");
			flyToCat = true;
		}
        if (col.gameObject.tag.Equals("LimitSucker"))
        {
			flyToCat = false;
        }
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag.Equals("Enemy"))
		{
			Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
		}

	}


}
