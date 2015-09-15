using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileScript : MonoBehaviour {
    private Dictionary<string, int> Config;
    private Block Blok;

    public void load(Spell spell) {
        Config = spell.Projectile;
        Blok = spell.Blok;

        if (Config["bounces"] == 0)
            GetComponent<Collider2D>().isTrigger = true;
    }
    void onCollisionEnter(Collision2D col) {

    }
    void Update() {
        
    }
}
