using UnityEngine;
using System.Collections;

public class GenerateScript : MonoBehaviour {

    public const int test_distance = 30;

    public GameObject lastCheckpoint;
    public GameObject currentCheckpoint;

    void Awake()
    {
        currentCheckpoint = GameObject.FindGameObjectWithTag("InitialCheckpoint");
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
        } else
        {
            //blocks
            
        }
    }

    public void generateSimple()
    {

    }
}
