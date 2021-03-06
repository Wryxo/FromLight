﻿using UnityEngine;
using System.Collections;

public class ForgleScript : MonoBehaviour {
    public float Acceleration, MaxSpeed;
    public int knockbackPower;
    public GameObject WaypointParent;

    private Transform[] waypoints;
    private int currentWaypointI;
    private Vector2 nextWaypoint;
    private Rigidbody2D rb;
    private bool facingRight = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
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

            j = Random.Range(0, waypoints.Length);
            while (i == j)
                j = Random.Range(0, waypoints.Length);

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
        Vector2 currPos = transform.position;
        if (Vector2.Distance(currPos, nextWaypoint).CompareTo(4.0f) < 0)
            rb.velocity *= 0.95f;
        if (Vector2.Distance(currPos, nextWaypoint).CompareTo(0.25f) < 0) {
            rb.velocity = Vector2.zero;
            popWaypoint();
        }

        Vector2 direction = (nextWaypoint - (Vector2)transform.position).normalized;
        rb.AddForce(direction * Acceleration * rb.mass);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed * rb.mass);
	}
    void Update() {
        if (facingRight && rb.velocity.x < 0) {
            facingRight = false;
            transform.localScale = new Vector3(-1.0f, 1f, 1f);
        } else if (!facingRight && rb.velocity.x > 0) {
            facingRight = true;
            transform.localScale = new Vector3(1.0f, 1f, 1f);
        }
    }
    void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.tag == "Player") {
            Vector2 direction = Random.insideUnitCircle.normalized;

            if (c.transform.position.x < transform.position.x && direction.x > 0 ||
                c.transform.position.x >= transform.position.x && direction.x <= 0)
                direction.x *= -1;
            c.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * knockbackPower);
        }
    }
}
