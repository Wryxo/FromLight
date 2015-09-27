using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spell {
	public Dictionary<string, int> Projectile = new Dictionary<string, int>();
	public BlockScript Blok;
	public uint ManaCost;
	public static Dictionary<string, Spell> SpellBook = new Dictionary<string, Spell> () {
		{ "Spell1", new Spell(new StoneBlockScript(), 10, 1, 5, 0, 0, 1) },
		{ "Spell2", new Spell(new StoneBlockScript(), 30, 4, 0, 1, 0, 0) },
		{ "Spell3", new Spell(new StoneBlockScript(), 40, 0, 5, 0, 0, 1) }
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
	public Spell(BlockScript blok, uint manaCost, int bounces, int slowDown, int onFire, int magnetic, int gravity) {
		this.Blok = blok;
		this.ManaCost = manaCost;
		this.Projectile = new Dictionary<string, int> ();
		this.Projectile.Add ("bounces", bounces);
		this.Projectile.Add ("slowDown", slowDown);
		this.Projectile.Add ("onFire", onFire);
		this.Projectile.Add ("magnetic", magnetic);
		this.Projectile.Add ("gravity", gravity);
	}

	public Spell(Spell spell){
		this.Blok = spell.Blok;
		this.ManaCost = spell.ManaCost;
		this.Projectile = new Dictionary<string, int> (spell.Projectile);
	}


}
