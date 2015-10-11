using UnityEngine;
using System.Collections;

public class DoBounceScript : MonoBehaviour {

	public int Sila;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Bounds myBounds = GetComponent<BoxCollider2D> ().bounds;
		Vector3 otherPos = other.transform.position;

		if ((otherPos.x < myBounds.center.x + myBounds.extents.x || otherPos.x > myBounds.center.x - myBounds.extents.x) &&
			(otherPos.y > myBounds.center.y + myBounds.extents.y || otherPos.y < myBounds.center.y - myBounds.extents.y)) {
			other.attachedRigidbody.AddForce(new Vector2 (Mathf.Clamp(other.attachedRigidbody.velocity.x*Sila,-1000, 1000), Mathf.Clamp(-other.attachedRigidbody.velocity.y*Sila,-1750, 1750)));
		} else {
			other.attachedRigidbody.AddForce(new Vector2 (Mathf.Clamp(-other.attachedRigidbody.velocity.x*Sila,-1750, 1750), Mathf.Clamp(other.attachedRigidbody.velocity.y*Sila,-1000, 1000)));
		}
	}
}
