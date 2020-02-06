using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_Hostile : MonoBehaviour
{
    public GameObject Player;
    bool faceRight = true;
    public Rigidbody2D beam;
    public Rigidbody2D horBeam;
    public float WeaponSpeed;
    public Transform SP;
    // Start is called before the first frame update
    void Start()
    {
        //points the hostile at the player when they start
        if (Player.transform.position.x < this.transform.position.x)
        {
            turn();
        }
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


        if (Player.transform.position.y < this.transform.position.y && Player.transform.position.x == this.transform.position.x)
        {
            Rigidbody2D GhostAttack;
            GhostAttack = Instantiate(beam, SP.position, SP.rotation);
            GhostAttack.AddForce(SP.up * -WeaponSpeed);

        }
        else if (Player.transform.position.y == this.transform.position.y)
        {
            if (faceRight == true)
            {
                Rigidbody2D WeaponInstance;
                WeaponInstance = Instantiate(horBeam, SP.position, SP.rotation);
                WeaponInstance.AddForce(SP.right * WeaponSpeed);
            }
            if (faceRight != true)
            {
                Rigidbody2D WeaponInstance;
                WeaponInstance = Instantiate(horBeam, SP.position, SP.rotation);
                WeaponInstance.AddForce(SP.right * -WeaponSpeed);
            }
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

