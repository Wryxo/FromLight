using UnityEngine;
using System.Collections;

public class OosaScript : MonoBehaviour {
    public float Acceleration, MaxSpeed;
    public float MaxSwarmDistance;
    public GameObject SwarmParent;
    public GameObject tempSwarmParent = null;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
	void FixedUpdate () {
        Vector2 currPos = transform.position;
        Vector2 swarmPoint = SwarmParent.transform.position;
        if (tempSwarmParent != null)
            swarmPoint = tempSwarmParent.transform.position;

        if (Vector2.Distance(currPos, swarmPoint) > MaxSwarmDistance) {
            rb.velocity *= 0.95f;
        }

        Vector2 direction = (swarmPoint - (Vector2)transform.position).normalized;
        rb.AddForce(direction * Acceleration * rb.mass);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed * rb.mass);

        tempSwarmParent = null;
	}
    void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.layer == 9 || c.gameObject.layer == 15) {
            tempSwarmParent = null;
            Destroy(c.gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D c) {
        if (c.gameObject.layer == 9 || c.gameObject.layer == 15) {
            tempSwarmParent = c.gameObject;
        }
    }
}
