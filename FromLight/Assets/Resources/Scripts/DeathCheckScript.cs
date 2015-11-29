using UnityEngine;
using System.Collections;

public class DeathCheckScript : MonoBehaviour {

    public int deathOffset;

    float lastYPosition;
    
    UIPlayerScript uiScript;
    UserControl2D playerScript;

    // intended to be on a object who's parent is player
	void Start () {
        resetToOffset();
        uiScript = transform.parent.gameObject.GetComponent<UIPlayerScript>();
        playerScript = GameObject.Find("CharacterRobotBoy").GetComponent<UserControl2D>();
	}
	
	void Update () {
        if (transform.position.y >= transform.parent.position.y) {
            //fallen to death
            uiScript.showDeathScreen();
            playerScript.enabled = false;
        } else {
            uiScript.hideDeathScreen();
            playerScript.enabled = true;
        }
	    if (transform.position.y < lastYPosition) {
            transform.position = new Vector3(0, lastYPosition);
        }
        lastYPosition = transform.position.y;
    }

    public void resetToOffset() {
        transform.localPosition = new Vector3(0, deathOffset);
        lastYPosition = transform.position.y;
    }
}
