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
    bool faceRight = true;
    Rigidbody2D rb;

    //refences the sprites to change at runtime
    public Sprite Armored;
    public Sprite NoArmor;

    //sets weapons
    bool spear = true;
    bool sword = false;
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

        //turns the player
        if (faceRight == false && moveInput > 0)
        {
            turn();
        } else if (faceRight == true && moveInput < 0)
        {
            turn();
        }

        //jumping *complete*
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }

        //changes the sprite when the HP lowers *complete*
        if (HP == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = NoArmor;
        }

        //throw weapon
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
