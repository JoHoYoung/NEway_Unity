using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour {

	public Rigidbody2D rb;
	float offset;
	public int speed;
	bool right;

	// Use this for initialization
	void Start ()
	{
		right = true;
	}
	
	// Update is called once per frame
	void Update () {
		offset += 0.05f;
		if (offset > 5) {
			right = !right;
			offset = 0;
		}
		if (right) {
			rb.velocity = new Vector2 (speed, 0);
			rb.transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
		} else {
			rb.velocity = new Vector2 (-speed, 0);
			rb.transform.rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
		}
	}
}
