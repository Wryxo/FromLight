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

	void Start() {
		AvailableSpells = new List<Spell> ();
		Mana = ManaCap;
	}

	public void Shoot(bool fire, Vector3 mouse) {
		if (fire) {
			var go = Instantiate (Projektil, transform.position, Quaternion.identity) as GameObject;
			var projektil = go.GetComponent<ProjectileScript> ();
			//TODO: Uncomment next line
			//projektil.load (AvailableSpells[SelectedSpell]);
			Vector2 direction = Vector3.Normalize(transform.position - mouse);
			projektil.GetComponent<Rigidbody2D>().AddForce(direction * ShootForce);
			Mana -= AvailableSpells [SelectedSpell].ManaCost;
		}
	}
}
