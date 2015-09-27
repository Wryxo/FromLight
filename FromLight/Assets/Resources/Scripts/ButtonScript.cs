using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public int SpellId;
    private PlayerScript playerScript;

	void Start () {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { playerScript.SelectedSpell = SpellId; });
    }
	
	void Update () {
        gameObject.GetComponentInChildren<Text>().text = SpellId.ToString();
    }


}
