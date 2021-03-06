﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileScript : MonoBehaviour {
    public GameObject BlockObject;
    public GameObject BounceBlockObject;
    public GameObject RedPS, GreenPS, BluePS;
    private Dictionary<string, int> config;
    
    private string blok;
    private Rigidbody2D rb;

    public void load(Spell spell) {
        rb = GetComponent<Rigidbody2D>();
        config = spell.Projectile;
        blok = spell.Blok;

        if (config["bounces"] == 0)
            gameObject.layer = 15;
        if (config["gravity"] == 0)
            rb.gravityScale = 0;

        switch (config["bounces"]) {
            case 0:
                setColorGradient(RedPS);
                break;
            case 1:
                setColorGradient(GreenPS);
                break;
            default:
                setColorGradient(BluePS);
                break;
        }
    }
    private void setColorGradient(GameObject ps) {
        GameObject gops = (GameObject)GameObject.Instantiate(ps, Vector3.zero, Quaternion.identity);
        gops.transform.SetParent(gameObject.transform, false);
        gops.GetComponent<ParticleSystem>().Play();
    }
    public void resolve() {
		GameObject b;
		if (!blok.Equals ("BounceBlock")) {
			b = (GameObject)GameObject.Instantiate (BlockObject, transform.position, Quaternion.identity);
		} else {
			b = (GameObject)GameObject.Instantiate (BounceBlockObject, transform.position, Quaternion.identity);
		}
		GameObject spec = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Blocks/"+blok), b.transform.Find ("PrototypeWhite04x01").GetComponent<SpriteRenderer>().bounds.center, Quaternion.identity);
		spec.transform.SetParent (b.transform);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.layer == 14)
            return;

        if (config["bounces"] == 1)
			resolve();
		else {
			config["bounces"]--;
		}
    }
	public int getMagnetic() {
		return config["magnetic"];
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

    void Update() {
        garbageCollect();
    }

    // "killnet" for lost projectiles
    private void garbageCollect() {
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position)>100f) Destroy(gameObject); 
    }
}
