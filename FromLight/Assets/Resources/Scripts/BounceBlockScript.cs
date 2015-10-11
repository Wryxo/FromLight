using UnityEngine;
using System.Collections;

public class BounceBlockScript : BlockScript
{
	void Start(){
		this.Duration = 5f;
		transform.GetComponent<SpriteRenderer> ().sprite = this.Image;
	}
	
	void Update(){
		this.Duration -= Time.deltaTime;
		if (this.Duration < 0) {
			Destroy(transform.parent.gameObject);
		}
	}

	//this block attracts enemies
	public override void Special(){
		return;
	}
}


