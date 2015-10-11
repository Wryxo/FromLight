using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSegmentScript : MonoBehaviour {

    // level segment consists of one or more stages (or 0 in case of "simple" stage)
    // each segment begins with checkpoint - which is given to it, stores required and forbidden spells for the stages it contains
    // and should be initialized with the number of stages it should consist of (via segmentSize)

    // segment stages are generated when previous segment is entered, and segment is destroyed when 
    // the second one after it is entered (done from GenerateScript)

    public int size;
    public GameObject checkpoint;
    public bool horizontalDirection;

    private GameObject nextCheckpoint;

    public uint manaCap;
    List<Spell> RequiredSpells = new List<Spell>();
    List<Spell> ForbiddenSpells = new List<Spell>();

    private bool generated = false;

    public void InitSegment(int _size, GameObject _check, bool _initDir) {
        size = _size;
        checkpoint = _check;
        horizontalDirection = _initDir;
        manaCap = 100; // TODO check this with default player mana at the start
    }
	
    public GameObject generate() {
        if (generated)
            return nextCheckpoint;
        else
            generated = true;
        Vector3 lastPoint = checkpoint.transform.position;
        if (Random.value > 0.5f) {
            //simple
            Vector3 point = new Vector2(Random.Range(20f, 40f), Random.RandomRange(3f, 30f));
            if (Random.value > 0.5f) point.x = -1f * point.x;
            return generateIsland(checkpoint.transform.position + point);
            //simple transition always with same blocks as previous
        } else {
            for (int i = 0; i < size; i++) {
                GameObject stage;
                //stages - always generate towards the direction opposite to the one player just came from
                stage = horizontalDirection ? getLeftStage() : getRightStage();
                if (!stage.GetComponent<StageScript>().TrySpellset(RequiredSpells, ForbiddenSpells)) {
                    Destroy(stage);
                    continue;
                }
                //the start point of a stage should always be 0,0,0 (relative to the stage parent object)
                stage.transform.position = lastPoint;
                lastPoint = stage.transform.Find("ExitPoint").position;
            }
        }
        return generateIsland(lastPoint);
    }

    // TODO: get random
    private GameObject getLeftStage() {
        GameObject stage = Instantiate(Resources.Load("Prefabs/Generator/Stages/Left/TestLeftStage", typeof(GameObject))) as GameObject;
        stage.transform.SetParent(transform, true);
        return stage;
    }

    // TODO: get random
    private GameObject getRightStage() {
        GameObject stage = Instantiate(Resources.Load("Prefabs/Generator/Stages/Right/TestRightStage", typeof(GameObject))) as GameObject;
        stage.transform.SetParent(transform, true);
        return stage;
    }

    private GameObject generateIsland(Vector2 point) {
        nextCheckpoint = Instantiate(Resources.Load("Prefabs/Generator/Checkpoint", typeof(GameObject))) as GameObject;
        nextCheckpoint.transform.position = point;
        nextCheckpoint.transform.SetParent(transform, true);
        GameObject safeSpot = Instantiate(Resources.Load("Prefabs/Blocks/BlockObject", typeof(GameObject))) as GameObject;
        safeSpot.transform.SetParent(transform, true);
        point.y = point.y - 1.2f;
        point.x = point.x - 1.2f;
        safeSpot.transform.position = point;
        return nextCheckpoint;
    }

    public void SetPlayerSpellset() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().AvailableSpells = RequiredSpells;
    }

    public void SetPlayerManaCap() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().ManaCap = manaCap;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Mana = manaCap;
    }
}
