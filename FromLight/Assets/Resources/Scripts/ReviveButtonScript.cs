using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReviveButtonScript : MonoBehaviour {

    UIPlayerScript uiScript;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { clickFunction(); });
        uiScript = GameObject.FindGameObjectWithTag("Player").GetComponent<UIPlayerScript>();
    }
	
	void clickFunction() {
        uiScript.reviveButtonCallback();
    }
}
