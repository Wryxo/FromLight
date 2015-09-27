using UnityEngine;
using System.Collections;

public class MagneticBlockScript : BlockScript{
	public float Radius;
	public float MaxForce;
	private Collider2D[] collidery;

	void Start(){
		//this.Duration = 7f;
		//this.Image = new Sprite ();
		//this.Radius = 10f;
		//this.MaxForce = 10f;
		// TODO: bude pritahovanych naraz maximalne 5 colliderov ?
		this.collidery = new Collider2D[5];
	}
	
	void Update(){
		Special ();
		this.Duration -= Time.deltaTime;
		if (this.Duration < 0) {
			Destroy(gameObject);
		}
	}
	
	//this block attracts enemies
	public override void Special(){
		int count = Physics2D.OverlapCircleNonAlloc (transform.position, Radius, collidery, 1 << LayerMask.NameToLayer("Projectile"));
		for (int i = 0; i < count; i++) {
			if (collidery[i].GetComponent<ProjectileScript>().getMagnetic() > 0) {
				var rb = collidery[i].attachedRigidbody;
				rb.AddForce((transform.position - new Vector3(rb.position.x, rb.position.y)).normalized * (MaxForce * ( 1 - Mathf.Pow(Vector2.Distance(rb.position, transform.position)/Radius, 4))));
			}
		}
		return;
	}
}