using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileScript : MonoBehaviour {
    private Dictionary<string, int> Config;
    private Block Blok;
    private Rigidbody2D rb;

    public void load(Spell spell) {
        Config = spell.Projectile;
        Blok = spell.Blok;

        if (Config["bounces"] == 0)
            GetComponent<Collider2D>().isTrigger = true;
        if (Config["gravity"] == 0)
            rb.gravityScale = 0;
    }
    private void resolve() {
        Destroy(gameObject);
        throw new System.NotImplementedException();
    }
    void onCollisionEnter(Collision2D col) {
        if (col.gameObject.tag != "ground")
            return;

        if (Config["bounces"] == 1)
            resolve();
        else
            Config["bounces"]--;
    }
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
    }
    void FixedUpdate() {
        rb.velocity *= 1f - ((float)Config["slowdown"]) / 100f;
    }
}
