using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour {
    public float vel = 10.0f;
    private Rigidbody2D rb;
    private Vector2 borda;

    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-vel, 0);
        borda = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update () {
        if(transform.position.x < -borda.x * 2){
            Destroy(this.gameObject);
        }
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
