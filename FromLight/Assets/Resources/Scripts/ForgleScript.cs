using UnityEngine;
using System.Collections;

public class ForgleScript : MonoBehaviour {
    public float ForgleSpeed;
    private GameObject[] waypoints;
    private int currentWaypointI;
    private Vector2 nextWaypoint;

    void Awake() {
        loadWaypoints(new GameObject[] {
                GameObject.Find("WP1 - Forgle"),
                GameObject.Find("WP2 - Forgle"),
                GameObject.Find("WP3 - Forgle"),
            });
    }
    public void loadWaypoints(GameObject[] wps) {
        if (wps.Length < 2)
            Debug.LogError("Less than two waypoints for Forgle");
        waypoints = wps;
        transform.position = waypoints[0].transform.position;
        currentWaypointI = 0;
        popWaypoint();
    }
    private void popWaypoint() {
        int nextWP = currentWaypointI + 1;
        if (nextWP == waypoints.Length)     // cycle through waypoints
            nextWP = 0;

        nextWaypoint = waypoints[nextWP].transform.position;
        currentWaypointI = nextWP;
    }
	void FixedUpdate () {
        transform.position = Vector2.Lerp(transform.position, nextWaypoint, Time.deltaTime * ForgleSpeed);
        if (Vector2.Distance(transform.position, nextWaypoint).CompareTo(0.5f) < 0)
            popWaypoint();
	}
}
