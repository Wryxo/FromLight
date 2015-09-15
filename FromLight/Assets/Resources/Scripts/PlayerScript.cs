using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {
    public uint Mana, ManaCap, ManaRegen;
	public List<Spell> AvailableSpells;
	public int SelectedSpell = 0;
	public GameObject Projektil;

	private GameObject player;

	void Start() {
		AvailableSpells = new List<Spell> ();

	}

    public void Shoot() {
		var go = Instantiate (Projektil, transform.position, Quaternion.identity) as GameObject;
		var projektil = go.GetComponent<ProjectileScript> ();
    }
}
