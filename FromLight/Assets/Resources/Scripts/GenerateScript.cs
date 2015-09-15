using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateScript : MonoBehaviour {

    public const int test_distance = 30;

    public GameObject lastCheckpoint;
    public GameObject currentCheckpoint;

    public List<GameObject> blocks = new List<GameObject>();
    public List<GameObject> safeSpots = new List<GameObject>();

    void Awake()
    {
        currentCheckpoint = GameObject.FindGameObjectWithTag("InitialCheckpoint");
        safeSpots.Add(GameObject.FindGameObjectWithTag("InitialSafespot"));
    }

	void Start () {
        //generate first
        generateNextPoint();
	}
	
	void Update () {
	
	}

    public void generateNextPoint() {
        if (lastCheckpoint != null) Destroy(lastCheckpoint);
        lastCheckpoint = currentCheckpoint;
        // TODO: decide between building blocks and simple transition
        if (true)
        {
            //simple
            Vector2 point = Random.insideUnitCircle*test_distance;
            point.x = point.x > 0 ? point.x + test_distance : point.x - test_distance;
            currentCheckpoint = Instantiate(Resources.Load( "Prefabs/Generator/Checkpoint", typeof(GameObject))) as GameObject;
            currentCheckpoint.transform.position = point;
            GameObject safeSpot = Instantiate(Resources.Load("Prefabs/Generator/Safespot", typeof(GameObject))) as GameObject;
            point.y = point.y - 5;
            safeSpot.transform.position = point;
            safeSpots.Add(safeSpot);
            // TODO: assign blocks
        } else
        {
            //blocks
            
        }
    }

    public void generateSimple()
    {

    }
}
