using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour {
   
   // public List<platfom> Floor2 = new List<platfom>();
    public List<GameObject> BombList = new List<GameObject>();
    public float NpWidht = 3;
    public float Height = 3;
    public GameObject platform;
    // Use this for initialization
    private void Start() {
        Vector3 worldVec = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, 0.0f));
     //   CratePlatrorm(NpWidht, Height,worldVec);
       }
    void CratePlatrorm(float x, float y, Vector3 wW)
    {
        float sprSizeX = platform.GetComponent<SpriteRenderer>().bounds.size.x;
        float sprSizeY = platform.GetComponent<SpriteRenderer>().bounds.size.y;

        for (int i = 0; i < NpWidht; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                transform.position = new Vector3(wW.x = (sprSizeX * x), wW.y = (sprSizeY * -y), 0);
                Instantiate(platform, transform.position, Quaternion.identity);
            }
        }
    }
    int i = 0;
	// Update is called once per frame
	void Update () {
      /*  if (Input.GetKeyDown(KeyCode.Space))
        {
           // Floor2[i].Intss( );
            i += 1;
            Debug.Log("fds");
        }*/
	}
}

