using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoweBompPoint : MonoBehaviour {
    List<GameObject> waytPoints = new List<GameObject>();

    bool mouseDown;
    Vector3 cursor;
    private bool selected = false;
    public int sets = 1;
    Vector2 poditionBase;
    private platfom Pl;
    void Start()
    {
        waytPoints = GameObject.Find("Main Camera").GetComponent<main>().BombList;
        poditionBase = transform.position;
    }
    void Update()
    {
        
        Pl = GameObject.FindObjectOfType<platfom>();
        if (Input.GetMouseButtonDown(0))
        {
            var box = GetComponent<BoxCollider2D>();
            Vector2 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (box.OverlapPoint(v))
            {
                selected = true;
            }
        }
        if (selected == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }

        if (Input.GetMouseButtonUp(0) && selected)
        {
            var box = GetComponent<BoxCollider2D>();
            // inventory = GameObject.FindGameObjectsWithTag("Player").GetComponent<SpawnerE>();
            Vector2 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var overlaps = Physics2D.OverlapPointAll(v);
            foreach (var aaa in overlaps)
            {
                if (aaa != box && aaa.gameObject.GetComponent<MoweBompPoint>() != null)
                {
                    var d = aaa.gameObject.GetComponent<MoweBompPoint>();
                   
                    if (d != null)
                    {
                        if (d.sets == sets)
                        {
                           
                           // Debug.Log(waytPoints.Count);
                            Destroy(this.gameObject);
                             Destroy(d.gameObject);
                           if (sets < waytPoints.Count)
                            {
                                //Debug.Log(waytPoints.Count/2);
                                sets += 1;
                               Instantiate(waytPoints[Random.Range(0, waytPoints.Count / 2)], poditionBase, Quaternion.identity);
                                Instantiate(waytPoints[sets ], d.transform.position, Quaternion.identity);
                            }
                            else
                            {
                                 Instantiate(waytPoints[0], poditionBase, Quaternion.identity);
                                 Instantiate(waytPoints[0], transform.position, Quaternion.identity);

                            }
                          
                            //Pl.test(true);
                            //Pl.SpawnExitTriger(true);
                            break;
                        }
                    }
                }
            }
           // Pl.SpawnExitTriger(false);
            selected = false;
            transform.position = poditionBase;
        }
    }
}
