using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D jav;
    public Rigidbody2D sword;
    public GameObject SP;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {        
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        Rigidbody2D P = Instantiate(jav, SP.transform.position, SP.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
