using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPlayerScript : MonoBehaviour {

    public GameObject ManaBar;

	// Use this for initialization
	void Start () {
        ManaBar.GetComponentInChildren<Image>().fillMethod = Image.FillMethod.Radial360;
        ManaBar.GetComponentInChildren<Image>().type = Image.Type.Filled;
    }
	
	// Update is called once per frame
	void Update () {
        ManaBar.GetComponentInChildren<Image>().fillAmount = (float)gameObject.GetComponent<PlayerScript>().Mana / (float)gameObject.GetComponent<PlayerScript>().ManaCap;
    }
}
