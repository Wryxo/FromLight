﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPlayerScript : MonoBehaviour {

    private GameObject manaBar;
    private GameObject spellBar;

	void Start () {
        manaBar = GameObject.FindGameObjectWithTag("ManaBar");
        spellBar = GameObject.FindGameObjectWithTag("SpellBar");
        manaBar.GetComponentInChildren<Image>().fillMethod = Image.FillMethod.Radial360;
        manaBar.GetComponentInChildren<Image>().type = Image.Type.Filled;
    }
	
	void Update () {
        manaBar.GetComponentInChildren<Image>().fillAmount = (float)gameObject.GetComponent<PlayerScript>().Mana / (float)gameObject.GetComponent<PlayerScript>().ManaCap;
    }

    public void ReplaceSpellButtons() {
        int id = 0;
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
}
