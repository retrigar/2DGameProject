using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_script : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "hostile")
        {
            Destroy(this.gameObject);
        }
    }
}