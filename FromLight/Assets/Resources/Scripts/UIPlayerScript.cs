using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPlayerScript : MonoBehaviour {

    private GameObject manaBar;
    private GameObject spellBar;
    private GameObject deathScreen;

    private GenerateScript generator;

    void Start () {
        manaBar = GameObject.FindGameObjectWithTag("ManaBar");
        spellBar = GameObject.FindGameObjectWithTag("SpellBar");
        deathScreen = GameObject.FindGameObjectWithTag("DeathScreen");
        generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<GenerateScript>();
        manaBar.GetComponentInChildren<Image>().fillMethod = Image.FillMethod.Radial360;
        manaBar.GetComponentInChildren<Image>().type = Image.Type.Filled;
    }
	
	void Update () {
        manaBar.GetComponentInChildren<Image>().fillAmount = (float)gameObject.GetComponent<PlayerScript>().Mana / (float)gameObject.GetComponent<PlayerScript>().ManaCap;
    }

    public void ReplaceSpellButtons() {
        int id = 0;
        spellBar = spellBar ?? GameObject.FindGameObjectWithTag("SpellBar");
        Debug.Log(spellBar);
        foreach (Transform child in spellBar.transform) {
            Destroy(child.gameObject);
        }
        foreach (var spell in gameObject.GetComponent<PlayerScript>().AvailableSpells) {
            GameObject button = Instantiate(Resources.Load("Prefabs/Buttons/SpellButton", typeof(GameObject))) as GameObject;
            button.GetComponent<ButtonScript>().SpellId = id;
            button.GetComponent<Transform>().SetParent(spellBar.GetComponent<Transform>(), false);
            id++;
        }
    }

    public void showDeathScreen() {
        //TODO fadein animation
        deathScreen.GetComponent<CanvasGroup>().alpha = 1;
    }

    public void reviveButtonCallback() {
        //TODO fadeout animation
        deathScreen.GetComponent<CanvasGroup>().alpha = 0;
        transform.parent.position = generator.lastCheckpoint.transform.position;
    }
}
