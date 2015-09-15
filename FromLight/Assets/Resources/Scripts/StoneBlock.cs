using UnityEngine;
using System.Collections;

public class StoneBlock : Block
{
		void Start(){
			this.Duration = 5f;
			this.Image = new Sprite();
		}

		void Update(){
			this.Duration -= Time.deltaTime;
			if (this.Duration < 0) {
				Destroy(gameObject);
			}
		}
		
		void Special(){
			return;
		}
}

