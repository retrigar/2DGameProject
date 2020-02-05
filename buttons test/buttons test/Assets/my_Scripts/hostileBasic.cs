using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hostileBasic : MonoBehaviour
{
    public GameObject Player;
    bool faceRight = true;
    public float moveSpeed;
    Rigidbody2D Rb;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
       //points the hostile at the player when they start
       if(Player.transform.position.x < this.transform.position.x)
        {
            turn();
        }

        /*if (Player.transform.position.x < this.transform.position.x)
        {
            Rb.velocity = new Vector2(-moveSpeed, Rb.velocity.y);
        }
        else if (Player.transform.position.x > this.transform.position.x)
        {
            Rb.velocity = new Vector2(moveSpeed, Rb.velocity.y);
        }*/
    }

    //turns the enimy in the direction of the player *complete*
    void turn()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x < this.transform.position.x)
        {
            Rb.velocity = new Vector2(-moveSpeed, Rb.velocity.y);
        } else if (Player.transform.position.x > this.transform.position.x)
        {
            Rb.velocity = new Vector2(moveSpeed, Rb.velocity.y);
        }
    }

    // disables collider temporarally when hits the player *complete*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {          
            StartCoroutine(Waiting());
        }
    }

    //disables collisions 
    IEnumerator Waiting()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(3);
        GetComponent<BoxCollider2D>().enabled = true;
    }
   

    //destroys when hit with weapon
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "projectile")
        {
            Destroy(this.gameObject);
        }
    }

   
}
