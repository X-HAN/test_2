using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 2;
    private Transform waypoints;
    private Transform waypoint;
    private int waypintIndex = -1;

    public int health = 30;
    void Start () {
        waypoints = GameObject.Find("waypoints").transform;
        NextWaypint();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 dir = waypoint.transform.position - transform.position;

        float _speed = Time.deltaTime * speed;
        transform.Translate(dir.normalized * _speed);
        
        if(dir.magnitude <= _speed)
        {
            NextWaypint();
        }
        CheckIsAlive();

    }
    void NextWaypint()
    {
        waypintIndex++;
        if(waypintIndex >= waypoints.childCount)
        {
            Destroy(gameObject);
            return;
        }
        waypoint = waypoints.GetChild(waypintIndex);

    }
    public void TakeDamege(int damage)
    {
        health -= damage;
    }
    void CheckIsAlive()
    {
        if(health <=0)
            Destroy(gameObject); 
    }
}
