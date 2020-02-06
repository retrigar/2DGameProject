using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    public bool grounded = false;
    [SerializeField] float HP = 2;
    public float speed;
    public float jumpHeight;
    bool gameOver = false;
    float moveInput;
    float upInput;
    bool faceRight = true;
    Rigidbody2D rb;


    float points;

    //refences the sprites to change at runtime
    public Sprite Armored;
    public Sprite NoArmor;

    //sets weapons
    public bool spear = true;
    public float WeaponSpeed;

    //for weapon spawning
    public Rigidbody2D jav;
    public Rigidbody2D sword;
    public Transform SP;

    //animation stuff
    public Animation noArmorRun;

    //climbing
    private float inputVertical;
    public LayerMask Ladders;
    private bool isClimbing;
    public float cSpeed;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //basic movement *complete*
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //turns the player *complete*
        if (faceRight == false && moveInput > 0)
        {
            turn();
        }
        else if (faceRight == true && moveInput < 0)
        {
            turn();
        }

        //jumping *complete*
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }

        //changes the sprite when the HP changes *complete*
        if (HP == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = Armored;
        }
        if (HP == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = NoArmor;
        }

        //throw weapon
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (spear == true)
            {
                if (faceRight == true)
                {
                    Rigidbody2D WeaponInstance;
                    WeaponInstance = Instantiate(jav, SP.position, SP.rotation);
                    WeaponInstance.AddForce(SP.right * WeaponSpeed);
                }
                else if (faceRight == false)
                {
                    Rigidbody2D WeaponInstance;
                    WeaponInstance = Instantiate(jav, SP.position, SP.rotation);
                    WeaponInstance.AddForce(SP.right * -WeaponSpeed);
                }
            }
            else if (spear == false)
            {
                if (faceRight == true)
                {
                    Rigidbody2D WeaponInstance;
                    WeaponInstance = Instantiate(sword, SP.position, SP.rotation);
                    WeaponInstance.AddForce(SP.right * WeaponSpeed);
                }
                else if (faceRight == false)
                {
                    Rigidbody2D WeaponInstance;
                    WeaponInstance = Instantiate(sword, SP.position, SP.rotation);
                    WeaponInstance.AddForce(SP.right * -WeaponSpeed);
                }
            }
        }

    }

    private void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, Ladders);
        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                isClimbing = true;
            }
            else
            {
                isClimbing = false;
            }
        }
        if (isClimbing == true)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * cSpeed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    //reduce HP when the player collides with enimies
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "hostile")
        {
            HP = HP - 1;
            if (HP == 0)
            {
                gameOver = true;
                //game over
                Loss();
            }
        }
    }


    //pickups and hostile projectiles
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Armor_PickUp")
        {
            HP = HP + 1;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Money_PickUp")
        {
            points = points + 1000;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Sword_PickUp")
        {
            spear = false;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Hostile_Projectile")
        {
            HP = HP - 1;
            Destroy(other.gameObject);
        }

    }



    //turns the player sprite when it changes direction *testing*
    void turn()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    //loads the game over scene when HP = 0
    void Loss()
    {

    }
}