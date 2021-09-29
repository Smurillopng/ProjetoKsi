using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaiObj : MonoBehaviour {

	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject)
			rb.isKinematic = false;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject)
			Debug.Log ("Bateu!");
	}

}
