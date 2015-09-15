using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileScript : MonoBehaviour {
    public Dictionary<string, int> Config;

    public void load(Dictionary<string, int> config) {
        this.Config = config;

        if (config["bounces"] == 0)
            GetComponent<Collider2D>().isTrigger = true;
    }
    void Update() {
			Debug.DrawLine(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
    }
}
