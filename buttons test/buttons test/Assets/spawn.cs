using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject Zombie;
    public Transform SP1;
    public Transform SP2;
    public Transform SP3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(Zombie, SP1.position, SP1.rotation);
            Instantiate(Zombie, SP2.position, SP2.rotation);
            Instantiate(Zombie, SP3.position, SP3.rotation);
            Destroy(this.gameObject);
        }
    }
}
