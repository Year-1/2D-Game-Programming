using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public GameObject sprite;
    //Depending on the players rotation change its colour.
    void Update()
    {
        //if (transform.rotation.z > 0.1f) sprite.GetComponent<SpriteRenderer>().color = Color.blue;
        //if (transform.rotation.z < -0.1f) sprite.GetComponent<SpriteRenderer>().color = Color.red;
        //if (transform.rotation.z > -0.1f && transform.rotation.z < 0.1f) sprite.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
