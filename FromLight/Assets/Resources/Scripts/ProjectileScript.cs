using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileScript : MonoBehaviour {
    private Dictionary<string, int> config;
    private Block blok;
    private Rigidbody2D rb;

    public void load(Spell spell) {
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
		Debug.Log ("tuk " + config ["bounces"]);
        if (config ["bounces"] == 1)
			resolve ();
		else {
			config ["bounces"]--;
		}
    }
	public int getOnFire(){
		return config ["onFire"];
	}
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
    }
    void FixedUpdate() {
        rb.velocity *= (1f - ((float)config["slowDown"]) / 100f);
		if (Mathf.Abs(rb.velocity.x) < 0.2f && rb.velocity.magnitude < 5f && config["slowDown"] != 0) {
			resolve ();
		}
    }
}
