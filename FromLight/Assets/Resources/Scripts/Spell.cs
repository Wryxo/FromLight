using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spell {
	public Dictionary<string, int> Projectile = new Dictionary<string, int>();
	public Block Blok;
	public uint ManaCost;
	public static Dictionary<string, Spell> SpellBook = new Dictionary<string, Spell> () {
		{ "Spell1", new Spell(null, 10, 1, 0, 0, 0, 0) },
		{ "Spell2", new Spell(null, 30, 0, 0, 1, 0, 0) }
	};

	/*
	 * blok - blok ktory to ma spawnut
	 * manaCost - manaCost
	 * bounces - pocet odrazov -> 0 = ghost, 1 = onImpact, >1 = n-1 odrazov
	 * slowDown - o kolko percent spomaluje projektil kazdy fixedUpdate
	 * onFire - boolean - ci hracov odpali na klik
	 * magnetic - ci je ovplyvneny magnetickou silou
	 * gravity - ci je ovplyvneny gravitaciou
	 */
	public Spell(Block blok, uint manaCost, int bounces, int slowDown, int onFire, int magnetic, int gravity) {
		this.Blok = blok;
		this.ManaCost = manaCost;
		this.Projectile.Add ("bounces", bounces);
		this.Projectile.Add ("slowDown", slowDown);
		this.Projectile.Add ("onFire", onFire);
		this.Projectile.Add ("magnetic", magnetic);
		this.Projectile.Add ("gravity", gravity);
	}


}
