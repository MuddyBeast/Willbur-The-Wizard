using UnityEngine;
using System.Collections;


public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool grounded = true;
    public float movementSpeed;
    public float jumpSpeed;
    private bool hasJumped = false;
    public float doubleTapspeed;

    public float buttonCooler = 0.5f;
    public int buttonCount;





    // Use this for initialization
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float xAxisMovement = 0f;
        rb.velocity = new Vector2(moveHorizontal * movementSpeed * Time.deltaTime, rb.velocity.y);

        if (!grounded && rb.velocity.y == 0)
        {
            grounded = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && grounded == true)
        {
            hasJumped = true;
        }

        rb.velocity = new Vector2(moveHorizontal * movementSpeed * Time.deltaTime, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.D))
        {
            moveHorizontal = Input.GetAxis("Horizontal");

            xAxisMovement++; 
            if(xAxisMovement > 0)
            {
                
            }
            buttonCount++;

            if (buttonCount == 1)
            {
                Debug.Log("Rock my booty solid!");
                rb.velocity = new Vector2(rb.velocity.x * movementSpeed * doubleTapspeed, rb.velocity.y);

            }


        }
        if (buttonCount >= 1)
        {
            buttonCooler -= 1 * Time.deltaTime;

            if (buttonCooler < 0)
            {
                buttonCount = 0;
                buttonCooler = 0.5f;
            }
        }




    }
    void FixedUpdate()
    {
        if (hasJumped)
        {
            rb.AddForce(transform.up * jumpSpeed);
            grounded = false;
            hasJumped = false;
        }
    }





}
