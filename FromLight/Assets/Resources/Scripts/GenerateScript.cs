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
        if (Input.GetKeyDown("space"))
        {
            generateNextPoint();
        }
    }

    public void generateNextPoint() {
        //horizontalDirection == true => came from right, else came from left
        bool horizontalDirection = lastCheckpoint.transform.position.x > currentCheckpoint.transform.position.x;
        if (lastCheckpoint != null) Destroy(lastCheckpoint);
        lastCheckpoint = currentCheckpoint;
        Vector2 lastPoint = lastCheckpoint.transform.position;
        // TODO: decide between building blocks and simple transition
        if (true)
        {
            //simple
            Vector2 point = new Vector2(Random.Range(20f,40f), Random.RandomRange(3f,30f));
            if (Random.value > 0.5f) point.x = -1f * point.x;
            generateIsland(point);
            // TODO: assign blocks
        } else
        {
            // TODO make this less random
            int limit = Random.RandomRange(1,3);
            for (int i=0;i< limit;i++)
            {
                //stages - always generate towards the direction opposite to the one player just came from
                GameObject stage = horizontalDirection ? getLeftStage() : getRightStage();
                //stage origin is also it's entry point
                stage.transform.position = lastPoint;
                lastPoint = stage.transform.position;
                //resources
                stage.GetComponent<StageScript>
            }
            generateIsland(lastPoint);
        }
    }

    public void generateSimple()
    {

    }

    // TODO: get random
    private GameObject getLeftStage()
    {
        return Instantiate(Resources.Load("Prefabs/Generator/Stages/", typeof(GameObject))) as GameObject;
    }

    // TODO: get random
    private GameObject getRightStage()
    {
        return Instantiate(Resources.Load("Prefabs/Generator/Stages/", typeof(GameObject))) as GameObject;
    }

    private void generateIsland(Vector2 point)
    {
        currentCheckpoint = Instantiate(Resources.Load("Prefabs/Generator/Checkpoint", typeof(GameObject))) as GameObject;
        currentCheckpoint.transform.position = point;
        GameObject safeSpot = Instantiate(Resources.Load("Prefabs/Blocks/SafespotPlacehold", typeof(GameObject))) as GameObject;
        point.y = point.y - 1.2f;
        point.x = point.x - 1.2f;
        safeSpot.transform.position = point;
        safeSpots.Add(safeSpot);
    }

}
