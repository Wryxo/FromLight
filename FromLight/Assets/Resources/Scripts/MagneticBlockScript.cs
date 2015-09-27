using UnityEngine;
using System.Collections;

public class MagneticBlockScript : BlockScript{


	void Start(){
		this.Duration = 7f;
		this.Image = new Sprite ();
	}
	
	void Update(){
		this.Duration -= Time.deltaTime;
		if (this.Duration < 0) {
			Destroy(gameObject);
		}
	}
	
	//this block attracts enemies
	public override void Special(){
		return;
	}
}
