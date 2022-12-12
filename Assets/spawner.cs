using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject player;
    public int interval = 300;
    public float radius = 5;
    private int counter = 0;
    public RectTransform area;
    private Vector3[] corners = new Vector3[4];
    private float xmin, xmax, ymin, ymax;

    //private bool waited = false;
    //private int waitTime = 500;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RectTransform>().GetWorldCorners(corners);
        xmin = corners[0].x;
        ymin = corners[0].y;
        xmax = corners[2].x;
        ymax = corners[2].y;
    }

    void FixedUpdate()
    {
        if (persistence.instance.completed())
        {
            counter += 1;
            //Debug.Log(counter);
            if (counter >= interval)
            {
                counter = 0;
                Spawn();
            }
        }
    }

    void Spawn()
    {
        //Debug.Log("Spawning");
        Vector3 spawnpos = new Vector3(Random.Range(xmin, xmax), Random.Range(ymin, ymax), 0);
        //Debug.Log(Vector3.Distance(player.transform.position, spawnpos));
        if (Vector3.Distance(player.transform.position, spawnpos) >= radius)
        {
            //Debug.Log("Spawned!");
            Instantiate(enemy, spawnpos, new Quaternion());
        }
    }
}
