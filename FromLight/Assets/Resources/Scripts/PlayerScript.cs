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

	public GameObject Shoot(Vector3 mouse, float forceQuotient) {
		var currentSpell = AvailableSpells [SelectedSpell];
		if (currentSpell.ManaCost <= Mana){
			float dist = Vector2.Distance (transform.position, mouse);
			Vector3 direction = (transform.position - mouse) / dist;
			var go = Instantiate (Projektil, transform.position - direction*1.1f, Quaternion.identity) as GameObject;
			var projektil = go.GetComponent<ProjectileScript> ();
			projektil.load (new Spell(currentSpell));
			projektil.GetComponent<Rigidbody2D>().AddForce(-direction * ShootForce * forceQuotient, ForceMode2D.Impulse);
			Mana = (uint)Mathf.Clamp(Mana-currentSpell.ManaCost, 0, ManaCap);
			return go;
		}

		return null;
	}
}
