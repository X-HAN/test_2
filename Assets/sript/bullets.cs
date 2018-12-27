using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour {
    Transform target;
    List<GameObject> smallBull = new List<GameObject>();
    int damage = 10;
     public float speed = 1f;
    void Start()
    {
        smallBull = GameObject.Find("Main Camera").GetComponent<main>().BombList;
        
    }
    void Update()
    {
        Move();
    }
    public void SetTarget(Transform enemy)
    {
        target = enemy;
        
       // Debug.Log("set target posishion " + target.position);
    }
    private void Move()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
            {
                target.GetComponent<Enemy>().TakeDamege(damage);
                Destroy(gameObject);
            }
            else
            {
                Vector2 dir = target.transform.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * speed);
             
            }
        }
        else
            Destroy(gameObject);

    }

}
