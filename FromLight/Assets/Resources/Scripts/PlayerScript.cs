using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {
    public uint Mana, ManaCap, ManaRegen;
	public List<Spell> AvailableSpells;
	public int SelectedSpell = 0;
	public GameObject Projektil;
	public int ShootForce = 5;

	private GameObject player;
	private float sec;

	void Start() {
		AvailableSpells = new List<Spell> ();
		AvailableSpells.Add (Spell.SpellBook["Spell1"]);
		AvailableSpells.Add (Spell.SpellBook["Spell2"]);
		Mana = ManaCap;
	}

	void Update() {
		sec += Time.deltaTime;
		if (sec > 1f) {
			Mana = (uint)Mathf.Clamp(Mana+ManaRegen,0,ManaCap);
			sec = 0;
		}
	}

	public GameObject Shoot(Vector3 mouse) {
		var currentSpell = AvailableSpells [SelectedSpell];
		if (currentSpell.ManaCost <= Mana){
			var go = Instantiate (Projektil, transform.position, Quaternion.identity) as GameObject;
			var projektil = go.GetComponent<ProjectileScript> ();
			//TODO: Uncomment next line
			//projektil.load (AvailableSpells[SelectedSpell]);
			float dist = Vector2.Distance (transform.position, mouse);
			Vector2 direction = (transform.position - mouse) / dist;
			projektil.GetComponent<Rigidbody2D>().AddForce(-direction * ShootForce, ForceMode2D.Impulse);
			Mana = (uint)Mathf.Clamp(Mana-currentSpell.ManaCost, 0, ManaCap);
			return go;
		}

		return null;
	}
}
