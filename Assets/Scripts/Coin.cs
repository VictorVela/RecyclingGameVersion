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
				catDirection = -(transform.position - player.transform.position).normalized;
				rb.velocity = new Vector2(catDirection.x, catDirection.y) * 6f * (Time.time / timeStamp);
			}
		}
	}

    void Update()
	{
		if (flyToCat && Input.GetButton("Fire1")) {
			catDirection = - (transform.position - player.transform.position).normalized;
			rb.velocity = new Vector2 (catDirection.x, catDirection.y) * 6f * (Time.time / timeStamp);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals ("SuckerTrash")) {
			timeStamp = Time.time;
			player = GameObject.Find ("Player");
			flyToCat = true;
		}
        if (col.gameObject.tag.Equals("LimitSucker"))
        {
			flyToCat = false;
        }
	}


}
