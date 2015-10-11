using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateScript : MonoBehaviour {

    public const int test_distance = 30;

    public GameObject lastCheckpoint;
    public GameObject currentCheckpoint;

    public List<GameObject> blocks = new List<GameObject>();
    public List<GameObject> safeSpots = new List<GameObject>();
    public List<List<GameObject>> stageLists = new List<List<GameObject>>();
    public List<GameObject> levelSegments = new List<GameObject>();

    // init first 3 segments, generate first two, TODO nicerer
	void Start () {
        currentCheckpoint = GameObject.FindGameObjectWithTag("InitialCheckpoint");
        for (int i = 0; i < 3; i++) generateSegment();
    }

    public void generateSegment() {
        GameObject nextSegment = Instantiate(Resources.Load("Prefabs/Generator/LevelSegment", typeof(GameObject))) as GameObject;
        nextSegment.GetComponent<LevelSegmentScript>().InitSegment(1, currentCheckpoint, true);
        levelSegments.Add(nextSegment);
        int l = levelSegments.Count;
        Debug.Log(l);
        currentCheckpoint = levelSegments[l - 1].GetComponent<LevelSegmentScript>().generate();
        if (levelSegments.Count > 4) {
            GameObject ls = levelSegments[0]; // TODO check if this is necessary
            levelSegments.RemoveAt(0);
            Destroy(ls);
        }
    }

	void Update () {
        if (Input.GetKeyDown("x")) {
            generateSegment();
        }
    }

}
