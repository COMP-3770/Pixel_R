using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float speedScale = 100f;

  //  public float jumpSpeed = 5f;
    public float jumpForce;
    private float movement = 0f;
    private Rigidbody rigidBody;
    public Transform groundCheckPoint;
    //  public Transform CheckPoint2;
    public Vector3 groundCheckHalfExtents;
    public LayerMask groundLayer;
    private bool isBotTounchingGround;


    private int extraJumps;
    public int numJumps = 1;


    //   private bool isUpTounchingGround;
    private Animator playerAnimation;


    private bool m_FacingRight = true; //for determing which way the player is curretlyfacing.

    //health bar
    public HealthSystem healthSystem;
    //  public Vector3 respawnPoint;
    //   public LevelManager gameLM;
    // Start is called before the first frame update
    void Start()
    {
        /*
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnites = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
        */
        rigidBody = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        //    respawnPoint = transform.position;
        //   gameLM = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isBotTounchingGround = Physics.CheckBox(groundCheckPoint.position, groundCheckHalfExtents, groundCheckPoint.rotation, groundLayer);
        //   isUpTounchingGround = Physics2D.OverlapCircle(CheckPoint2.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");

        rigidBody.velocity = new Vector3(movement * walkSpeed * Time.deltaTime * speedScale, rigidBody.velocity.y, rigidBody.velocity.z);

        if (movement > 0f && !m_FacingRight)
        {       

            Flip();
        }
        else if (movement < 0f && m_FacingRight)
        {       
            Flip();
        }
        /*
        else
        {
            rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, rigidBody.velocity.z);
            //  transform.Translate(rigidBody.velocity.x, rigidBody.velocity.y, rigidBody.velocity.z);
        }
        */

      //   Debug.Log("**********" + isBotTounchingGround);
      /*
        if (Input.GetButtonDown("Jump") && isBotTounchingGround == true)
        {
         //      Debug.Log("!!!!!!!!!!!" + isBotTounchingGround);
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpSpeed * Time.deltaTime, rigidBody.velocity.z);
        }
        */

        //double jump
        if (isBotTounchingGround == true)
        {
            extraJumps = numJumps;
        }

        //hold left ctrl to run
        if (Input.GetButton("Fire3"))
        {
            rigidBody.velocity = new Vector3(movement * runSpeed * Time.deltaTime * speedScale, rigidBody.velocity.y, rigidBody.velocity.z);
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rigidBody.velocity = Vector3.up * jumpForce;
            extraJumps--;
        }

        else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isBotTounchingGround == true)
        {
            rigidBody.velocity = Vector3.up * jumpForce;
        }

        //Debug.Log(movement);

        playerAnimation.SetFloat("speed", Mathf.Abs(rigidBody.velocity.x));
        //  playerAnimation.SetBool("onGround", isUpTounchingGround);
        playerAnimation.SetBool("onGround", isBotTounchingGround);
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "charger")
        {

        }

        /*
        if (other.tag == "CheckPoint")
        {
            // Debug.Log("22222222222");

            respawnPoint = other.transform.position;
        }
        */
    }

    /*

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health < 0)
        {
            health = 0;
            Die();
        }
    }
    */

}

