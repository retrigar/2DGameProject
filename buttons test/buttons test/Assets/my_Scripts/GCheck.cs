using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCheck : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //checks if the player is on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player.GetComponent<PlayerCon>().grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player.GetComponent<PlayerCon>().grounded = false;
        }
    }
}
