using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platfom : MonoBehaviour {
    List<GameObject> waytPoints = new List<GameObject>();
   

    public bool spawn = false;
    public bool spawnExitTriger = false;
    int num = 1;
    // Use this for initialization
  public void test(bool x)
    {
        spawn = x;
       
    }
    public void SpawnExitTriger(bool ET=false)
    {
        spawnExitTriger = ET;
      
    }

     void Intss()
    {
        Instantiate(waytPoints[Random.Range(0, waytPoints.Count / 2)], transform.position, Quaternion.identity);
    }
   
    void Start()
    {
        waytPoints = GameObject.Find("Main Camera").GetComponent<main>().BombList;
        Intss();
        /*  if (spawn)
          {
              Intss();
             / spawn = false;
          }
         */
        // Intss();
    }
    private void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          
          /*  if (spawn) {
                Intss();
                spawn = false;
            }*/
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            if (spawnExitTriger) {
                Debug.Log("_ " + spawnExitTriger);
               // Intss();
                spawnExitTriger = false;
            }
        }
    }

}
