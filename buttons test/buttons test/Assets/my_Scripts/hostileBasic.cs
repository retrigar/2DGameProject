using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hostileBasic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // disables collider temporarally when hits the player *complete*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {          
            StartCoroutine(Waiting());
        }
    }

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
