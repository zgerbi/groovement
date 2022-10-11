using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killZone : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    public GameObject Player;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.position = new Vector3(0, 0, 0);
        }
    }
}