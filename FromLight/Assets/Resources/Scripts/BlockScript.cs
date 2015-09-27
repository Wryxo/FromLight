using UnityEngine;
using System.Collections;

public abstract class BlockScript : MonoBehaviour {
	public float Duration;
	public Sprite Image;

	// Special resolves unordinary effects of a block
    public abstract void Special();


}
