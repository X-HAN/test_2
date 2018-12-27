using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    List<GameObject> ballBigg = new List<GameObject>();

    public float range = 2f;
    public float CurrCooldown, Coldown;
    // Update is called once per frame
    public GameObject Projectile;
    Vector2 poditionBase;


    // Use this for initialization
    void Start () {
          poditionBase = transform.position;
          ballBigg =  GameObject.Find("Main Camera").GetComponent<main>().BombList;
        Intss();
    }
    void Intss()
    {
        Instantiate(ballBigg[0], transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (CanShoot())
        {
            SearchTarget();
        }
        if (CurrCooldown > 0)
            CurrCooldown -= Time.deltaTime;
    }

    bool CanShoot()
    {
        if (CurrCooldown <= 0)
            return true;

        return false;

    }
    void SearchTarget()
    { 
        Transform nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;
        
        foreach(GameObject enemys in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Shoot(enemys.transform);
            float currDistance = Vector2.Distance(transform.position, enemys.transform.position);
            if(currDistance< nearestEnemyDistance && currDistance <= range)
            {
                //Destroy(enemy);
              
                  nearestEnemy = enemys.transform;
                  nearestEnemyDistance = currDistance;
            }
           
        }
        if (nearestEnemy != null)
        {
            Shoot(nearestEnemy);
        }

    }
    void Shoot(Transform enemy)
    {
        Vector2 xx = enemy.position;
        CurrCooldown = Coldown;
        /*  Instantiate(Projectile, poditionBase , Quaternion.identity);*/
       GameObject proj = Instantiate(Projectile);
        //GameObject proj = Instantiate(ballBigg[0]);
        proj.transform.position = poditionBase;
             proj.GetComponent<bullets>().SetTarget(enemy);
    }

}
