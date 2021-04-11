using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject explosion;
    public GameObject respawn;
    private PlayerController player;


    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "DeathCollider")
        {
            Debug.Log("hit detected");
   
            player.transform.position = respawn.transform.position;

        }
    }

}