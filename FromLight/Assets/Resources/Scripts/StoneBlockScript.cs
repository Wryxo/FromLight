using UnityEngine;
using System.Collections;

public class StoneBlockScript : BlockScript
{
		void Start(){
			this.Duration = 20f;
			transform.GetComponent<SpriteRenderer> ().sprite = this.Image;
		}

		void Update(){
			this.Duration -= Time.deltaTime;
			if (this.Duration < 0) {
				Destroy(transform.parent.gameObject);
			}
		}
		
        public override void Special() {
			return;
		}
}

