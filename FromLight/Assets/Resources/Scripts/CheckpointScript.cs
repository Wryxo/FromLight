using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D c) {
        Debug.Log("wheeeej");
        if (c.gameObject.tag == "Player") {
            c.gameObject.GetComponent<PlayerScript>().LastCheckpoint = gameObject;
            if (transform.parent != null && transform.parent.parent != null) {
                // checkpoint.stage.levelsegment.setWhat'sNeeded
                Debug.Log("whaaaj");
                transform.parent.parent.gameObject.GetComponent<LevelSegmentScript>().SetPlayerSpellset();
                transform.parent.parent.gameObject.GetComponent<LevelSegmentScript>().SetPlayerManaCap();
            } else {
                Debug.Log(":((");
                //simple, random stage, levelsegment is direct parent
                transform.parent.gameObject.GetComponent<LevelSegmentScript>().SetPlayerSpellset();
                transform.parent.gameObject.GetComponent<LevelSegmentScript>().SetPlayerManaCap();
            }
        }
    }
}
