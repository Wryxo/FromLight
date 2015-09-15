using UnityEngine;
using System.Collections;

public abstract class Block : MonoBehaviour {
	public float Duration;
	public Sprite Image;

	// Special resolves unordinary effects of a block
    public abstract void Special();

}
