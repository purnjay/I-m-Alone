using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour {

	//Floats
	[Header("Player Speed")]
	public float speed;

	//Vectors
	Vector2 direction;

	//Components
	Rigidbody2D rb2d;
	Animator anim;

	//Boolean
	bool isWalking;

	void Start () {
	
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	

	void Update () {

		var h = Input.GetAxisRaw("Horizontal");
		var v = Input.GetAxisRaw("Vertical");

		direction = new Vector2(h, v);
		rb2d.velocity = direction * speed;

		isWalking = (Mathf.Abs (h) + Mathf.Abs (v)) > 0;

		anim.SetBool ("isWalking", isWalking);

		if (isWalking) {
			anim.SetFloat ("X", h);
			anim.SetFloat ("Y", v);


		}
	
	}


}
