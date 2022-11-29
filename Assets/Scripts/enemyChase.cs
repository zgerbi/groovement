using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyChase : MonoBehaviour
{
    private GameObject Player;
    public float speed = 6f;
    public Rigidbody2D rb;

    private float range = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector2.Distance(transform.position, Player.transform.position));

        if (range >= Vector2.Distance(rb.transform.position, Player.transform.position))
        {
            //Debug.Log("yep");
            rb.transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
    }
}
