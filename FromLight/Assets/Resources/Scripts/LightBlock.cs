using System;
using UnityEngine;
namespace AssemblyCSharp
{
	public class LightBlock : Block
	{
		void Start(){
			this.Duration = 15f;
			this.Image = new Sprite ();
		}
		
		void Update(){
			this.Duration -= Time.deltaTime;
			this.Special ();
			if (this.Duration < 0) {
				Destroy(gameObject);
			}
		}

		//this block attracts enemies
        public override void Special() {
			return;
		}
	}
}

