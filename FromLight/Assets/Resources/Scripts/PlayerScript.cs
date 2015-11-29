using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {
    public uint Mana, ManaCap;
    public List<Spell> AvailableSpells;
    public int SelectedSpell = 0;
    public GameObject Projektil;
    public GameObject LastCheckpoint;
    public int ShootForce = 5;

    private GameObject player;
    private float sec;

    void Start() {
        AvailableSpells = new List<Spell>();
        AvailableSpells.Add(Spell.SpellBook["Spell1"]);
        AvailableSpells.Add(Spell.SpellBook["Spell2"]);
        AvailableSpells.Add(Spell.SpellBook["Spell3"]);
        gameObject.GetComponent<UIPlayerScript>().ReplaceSpellButtons();
        Mana = ManaCap;
        LastCheckpoint = GameObject.FindGameObjectWithTag("InitialCheckpoint");
    }

    public void ReplaceSpells(List<Spell> spells) {
        AvailableSpells = spells;
    }

	public GameObject Shoot(Vector3 mouse, float forceQuotient) {
		var currentSpell = AvailableSpells [SelectedSpell];
		if (currentSpell.ManaCost <= Mana){
			float dist = Vector2.Distance (transform.position, mouse);
			Vector3 direction = (transform.position - mouse) / dist;
			if (Mathf.Sign (direction.x) == Mathf.Sign (transform.localScale.x)){
				var go = Instantiate (Projektil, transform.Find("Lantern").transform.position/*transform.position - direction*1.1f*/, transform.rotation) as GameObject;
				var projektil = go.GetComponent<ProjectileScript> ();
				projektil.load (new Spell(currentSpell));
				projektil.GetComponent<Rigidbody2D>().AddForce(-direction * ShootForce * forceQuotient, ForceMode2D.Impulse);
				Mana = (uint)Mathf.Clamp(Mana-currentSpell.ManaCost, 0, ManaCap);
				return go;
			}
		}

		return null;
	}
}
