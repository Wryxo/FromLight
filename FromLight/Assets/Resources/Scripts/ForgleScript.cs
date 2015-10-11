using UnityEngine;
using System.Collections;

public class ForgleScript : MonoBehaviour {
    public float ForgleSpeed;
    public GameObject WaypointParent;

    private Transform[] waypoints;
    private int currentWaypointI;
    private Vector2 nextWaypoint;

    void Start() {
        loadWaypoints();
    }
    public void loadParentWaypoint(string WayName) {
        WaypointParent = GameObject.Find(WayName);
        loadWaypoints();
    }
    private void loadWaypoints() {
        Transform[] temp = WaypointParent.GetComponentsInChildren<Transform>();
        waypoints = new Transform[temp.Length - 1];
        int i = 0;
        foreach (Transform t in temp)
            if (t.gameObject != WaypointParent)
                waypoints[i++] = t;
        shuffleWaypoints();

        if (waypoints.Length < 2)
            Debug.LogError("Less than two waypoints for Forgle");
        transform.position = waypoints[0].position;
        currentWaypointI = 0;
        popWaypoint();
    }
    private void shuffleWaypoints() {
        Transform temp;
        int j;
        for (int i = 0; i < waypoints.Length; i++) {
            temp = waypoints[i];

            j = Random.Range(0, waypoints.Length - 1);
            while (i == j)
                j = Random.Range(0, waypoints.Length - 1);

            waypoints[i] = waypoints[j];
            waypoints[j] = temp;
        }
    }
    private void popWaypoint() {
        int nextWP = currentWaypointI + 1;
        if (nextWP == waypoints.Length)     // cycle through waypoints
            nextWP = 0;

        nextWaypoint = waypoints[nextWP].position;
        currentWaypointI = nextWP;
    }
	void FixedUpdate () {
        transform.position = Vector2.Lerp(transform.position, nextWaypoint, Time.deltaTime * ForgleSpeed);
        if (Vector2.Distance(transform.position, nextWaypoint).CompareTo(0.5f) < 0)
            popWaypoint();
	}
}
