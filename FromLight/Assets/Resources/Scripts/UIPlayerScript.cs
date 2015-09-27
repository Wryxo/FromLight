using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPlayerScript : MonoBehaviour {

    public GameObject ManaBar;
    public GameObject SpellBar;

	void Start () {
        ManaBar.GetComponentInChildren<Image>().fillMethod = Image.FillMethod.Radial360;
        ManaBar.GetComponentInChildren<Image>().type = Image.Type.Filled;
    }
	
	void Update () {
        ManaBar.GetComponentInChildren<Image>().fillAmount = (float)gameObject.GetComponent<PlayerScript>().Mana / (float)gameObject.GetComponent<PlayerScript>().ManaCap;
    }

    public void ReplaceSpellButtons() {
        int id = 0;
        foreach (Transform child in SpellBar.transform) {
            Destroy(child.gameObject);
        }
        foreach (var spell in gameObject.GetComponent<PlayerScript>().AvailableSpells) {
            GameObject button = Instantiate(Resources.Load("Prefabs/Buttons/SpellButton", typeof(GameObject))) as GameObject;
            button.GetComponent<ButtonScript>().SpellId = id;
            button.GetComponent<Transform>().SetParent(SpellBar.GetComponent<Transform>(), false);
            id++;
        }
    }
}
