using System;
using UnityEngine;
namespace AssemblyCSharp
{
	public class LightBlockScript : BlockScript
	{
		void Start(){
			this.Duration = 15f;
			this.Image = new Sprite ();
			GetComponent<Collider2D> ().isTrigger = true; //This Block has no collision
		}

		//Keeps track of Blocks duration and resolves its behavior after expiration
		void Update(){
			this.Duration -= Time.deltaTime;
			this.Special ();
			if (this.Duration < 0) {
				Destroy(gameObject);
			}
		}

		//This block attracts enemies
        public override void Special() {
			return;
		}
	}
}

