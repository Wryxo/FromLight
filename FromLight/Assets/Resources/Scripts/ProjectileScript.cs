using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileScript : MonoBehaviour {
    private Dictionary<string, int> config;
    private BlockScript blok;
    private Rigidbody2D rb;

    public void load(Spell spell) {
        rb = GetComponent<Rigidbody2D>();
        config = spell.Projectile;
        blok = spell.Blok;

        if (config["bounces"] == 0)
            GetComponent<Collider2D>().isTrigger = true;
        if (config["gravity"] == 0)
            rb.gravityScale = 0;
    }
    public void resolve() {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (config["bounces"] == 1)
			resolve ();
		else {
			config["bounces"]--;
		}
    }
	public int getMagnetic() {
		return config ["magnetic"];
	}

	public int getOnFire(){
		return config["onFire"];
	}

    void FixedUpdate() {
        rb.velocity *= (1f - ((float)config["slowDown"]) / 100f);
		if (Mathf.Abs(rb.velocity.x) < 0.2f && rb.velocity.magnitude < 5f && config["slowDown"] != 0) {
			resolve();
		}
    }
}
