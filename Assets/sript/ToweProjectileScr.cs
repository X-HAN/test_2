using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToweProjectileScr : MonoBehaviour {
    Transform target;
    float speed = 7;

	void Update () {
        Move();	
	}
    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }
    private void Move()
    {
        if(target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < .1f)
            {
                target.GetComponent<Enemy>();
                Destroy(gameObject);
            }
            else
            {
                Vector2 dir = target.transform.position - transform.position;
                transform.Translate(dir.normalized * speed);
            }
        }
        else
            Destroy(gameObject);

    }

}
