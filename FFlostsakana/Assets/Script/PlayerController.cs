using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameController gameController;

    [Range(1, 10)]
    public float jumpVelocity;

    public float jumpForce = 25f;
    public float checkRadius;
    public float distance;
    public float speed;
    public float fallMultiplier = 3.5f;
    public float lowJumpMultiplier = 2.5f;
    private float moveInput;
    private float moveSpeed;
    public float speedWall = -5f;
    public float dashSpeed;
    private float dashTime;
    public float startDashTIme;

    private Animator Anim;

    public LayerMask whatIsGround;
    public LayerMask wallLayerMask;

    public Transform groundCheck;
    public Transform wallCheckPoint;
    public Transform slidingCheckPoint;

    public GameObject player;
    public GameObject Boss;
    public GameObject dashparticle;

    public Slider healthBar;

    public int health;
    
    private int Maxhealth = 100;
    public int life;
    private int direction;
    private int extraJumps;
    public int extraJumpValue;

    public Rigidbody2D rb;

    private bool facingRight = true;
    public bool isGrounded;
    public bool wallSliding = false;
    public bool isWall;
    public bool isSliding;
    public bool jumpRequest;
    public bool wallJumping;

    //Vector2 wallRight;
    //Vector2 wallLeft;
    //Vector2 wallJ;

    void Start()
    {
        Anim = GetComponent<Animator>();

        dashTime = startDashTIme;
        //wallRight = new Vector2(-2f, 3f);
        //wallLeft = new Vector2(2f, 3f);
        //wallJ = new Vector2(-1f, 1f);

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

        //HP
        healthBar.value = health;

        if (health <= 0)
        {
            PlayerDie();
        }
        else if (health > 100)
        {
            health = Maxhealth;
        }

        //life

        //movement
        if(Input.GetAxis("Horizontal") < 0f || Input.GetAxis("Horizontal") > 0f)
        {
            Anim.SetBool("isRunning", true);
        }
        else
        {
            Anim.SetBool("isRunning", false);
        }
        //number of double jump
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
            // rb.velocity = new Vector2(speed * moveInput, rb.velocity.y);
            wallSliding = false;
            isSliding = false;
            wallJumping = false;
        }


        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            extraJumps--;
            jumpRequest = true;
        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            jumpRequest = true;
        }



        //wall sliding

        if (isGrounded == false && hit.collider != null)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, -rb.velocity.y/1.2f);
            rb.velocity = new Vector2(rb.velocity.x+1, (-rb.velocity.y-1)/2);
            Flip();
        }

        //wall jump
        if (Input.GetButtonDown("Jump") && isSliding)
        {
            wallJumping = true;
        }
        if (wallJumping)
        {
            Anim.SetTrigger("jumping");
            rb.velocity += Vector2.up * jumpVelocity;
            if (!facingRight && isSliding == true)
            {
                //GetComponent<Rigidbody2D>().AddForce(Vector2.one * jumpVelocity, ForceMode2D.Impulse);
                //GetComponent<Rigidbody2D>().AddForce(Vector2.left * jumpForce, ForceMode2D.Impulse);
                //GetComponent<Rigidbody2D>().AddForce(wallRight * jumpVelocity, ForceMode2D.Impulse);
                // GetComponent<Rigidbody2D>().AddForce(Vector2.left * speedWall, ForceMode2D.Impulse);
                //rb.velocity = Vector2.up * jumpVelocity;
                GetComponent<Rigidbody2D>().velocity = new Vector2(speedWall * 1 * Time.deltaTime, jumpVelocity *1.5f);
                //rb.velocity += Vector2.right  * jumpForce * Time.deltaTime;
                //rb.AddForce(new Vector2(-3f, 3f) * jumpVelocity);
                Debug.Log(wallJumping);
                wallJumping = false;
                //StartCoroutine(AirTimeWait());
            }
            else if (facingRight && isSliding == true)
            {
                //GetComponent<Rigidbody2D>().AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);
                //GetComponent<Rigidbody2D>().AddForce(wallLeft * jumpVelocity, ForceMode2D.Impulse);
                //GetComponent<Rigidbody2D>().AddForce(Vector2.left * speedWall, ForceMode2D.Impulse);
                //rb.velocity = Vector2.up * jumpVelocity;
                GetComponent<Rigidbody2D>().velocity = new Vector2(speedWall * -1 * Time.deltaTime, jumpVelocity*1.5f);
                //rb.velocity += Vector2.left * jumpForce * Time.deltaTime;

                //rb.AddForce(new Vector2(3f, 3f) * jumpVelocity);
                Debug.Log(wallJumping);
                wallJumping = false;
                //StartCoroutine(AirTimeWait());
            }
        }
        //if (Input.GetButtonDown("Jump") && isSliding == true)
        //{
        //    //rb.AddForce(new Vector2(0f, jumpForce));
        //    wallJumping = true;
        //}

        //dash


    }

    void FixedUpdate ()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, whatIsGround);
        isWall = Physics2D.Linecast(transform.position, wallCheckPoint.position, whatIsGround);
        isSliding = Physics2D.Linecast(transform.position, slidingCheckPoint.position, whatIsGround);


        //Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

        //movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * moveInput, rb.velocity.y);
        
        //if (!isSliding)
        //{
        
        //}
        //else if (isSliding)
        //{

        //}



        //wall sliding


        //Better jump
        if (jumpRequest)
        {
            //GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            //rb.AddForce(new Vector2(0f, jumpForce));
            Anim.SetTrigger("jumping");

            rb.velocity = Vector2.up * jumpVelocity;
            jumpRequest = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        //faceflip
        if (facingRight == true && moveInput > 0 || facingRight == false && moveInput < 0)
        {
            Flip();
        }

        //wall jump
        //if (wallJumping)
        //{
        //    Anim.SetTrigger("jumping");
        //    rb.velocity = Vector2.up * jumpVelocity;
        //    if (!facingRight && isSliding == true)
        //    {
        //        //GetComponent<Rigidbody2D>().AddForce(Vector2.one * jumpVelocity, ForceMode2D.Impulse);
        //        //GetComponent<Rigidbody2D>().AddForce(Vector2.left * jumpForce, ForceMode2D.Impulse);
        //        //GetComponent<Rigidbody2D>().AddForce(wallRight * jumpVelocity, ForceMode2D.Impulse);
        //        // GetComponent<Rigidbody2D>().AddForce(Vector2.left * speedWall, ForceMode2D.Impulse);
        //        //rb.velocity = Vector2.up * jumpVelocity;
        //        GetComponent<Rigidbody2D>().velocity = new Vector2(speedWall * moveInput * Time.deltaTime, jumpVelocity * 2);
        //        //rb.AddForce(new Vector2(-3f, 3f) * jumpVelocity);
        //        Debug.Log(wallJumping);
        //        Debug.Log(jumpRequest);
        //        wallJumping = false;
        //        //StartCoroutine(AirTimeWait());
        //    }
        //    else if (facingRight && isSliding == true)
        //    {
        //        //GetComponent<Rigidbody2D>().AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);
        //        //GetComponent<Rigidbody2D>().AddForce(wallLeft * jumpVelocity, ForceMode2D.Impulse);
        //        //GetComponent<Rigidbody2D>().AddForce(Vector2.left * speedWall, ForceMode2D.Impulse);
        //        //rb.velocity = Vector2.up * jumpVelocity;
        //        GetComponent<Rigidbody2D>().velocity = new Vector2(speedWall * moveInput * Time.deltaTime, jumpVelocity * 2);
        //        //rb.AddForce(new Vector2(3f, 3f) * jumpVelocity);
        //        Debug.Log(wallJumping);
        //        Debug.Log(jumpRequest);
        //        wallJumping = false;
        //        //StartCoroutine(AirTimeWait());
        //    }
        //}

        //if (rb.velocity.x < 0)
        //{
        //    rb.velocity -= Vector2.right * Physics2D.gravity.x * (fallMultiplier - 1) * Time.deltaTime;
        //}
        //else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        //{
        //    rb.velocity -= Vector2.left * Physics2D.gravity.x * (lowJumpMultiplier - 1) * Time.deltaTime;
        //}




        //dash
        if (direction == 0)
        {
            if (moveInput > 0f && Input.GetKeyDown(KeyCode.X))
            {
                direction = 1;
                //Debug.Log(moveInput);
            }
            else if (moveInput < 0f && Input.GetKeyDown(KeyCode.X))
            {
                direction = 2;
                //Debug.Log(moveInput);

            }
        }
        else
        {
            if (dashTime <= 0)
            {
                dashparticle.gameObject.SetActive(false);
                direction = 0;
                dashTime = startDashTIme;
            }
            else
            {
                dashTime -= Time.deltaTime;
                rb.velocity = Vector2.zero;

                if (direction == 1)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.right * dashSpeed, ForceMode2D.Impulse);
                    FindObjectOfType<AudioManager>().Play("dash");
                    dashparticle.gameObject.SetActive(true);
                    Anim.SetTrigger("dash");

                }
                else if (direction == 2)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.left * dashSpeed, ForceMode2D.Impulse);
                    FindObjectOfType<AudioManager>().Play("dash");
                    dashparticle.gameObject.SetActive(true);
                    Anim.SetTrigger("dash");
                }
            }
        }

    }

    //IEnumerator AirTimeWait()
    //{

    //    yield return new WaitForSecondsRealtime(5);

    //    rb.velocity = new Vector2(speed * moveInput, rb.velocity.y);

    //    isSliding = true;
    //}

    public void PlayerTakeDamage(int damage)
    {
        //StartCoroutine(KnockBack(0.5f, 10, player.transform.position));
        FindObjectOfType<AudioManager>().Play("DMG");
        health -= damage;
        Debug.Log("The Player damage taken !");
    }
    public void Healing(int Heal)
    {
        FindObjectOfType<AudioManager>().Play("pick");
        health += Heal;
        Debug.Log("The Player Healed");
    }

    public void LifeRecover(int lifeUp)
    {
        FindObjectOfType<AudioManager>().Play("pick");
        life += lifeUp;
        Debug.Log("The Player recovered");

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
            
    }

    //method flip
    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    public IEnumerator KnockBack(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            if (!facingRight)
            { 
                rb.AddForce(new Vector3(knockbackDir.x * -50 * Time.deltaTime, (knockbackDir.y+1) * knockbackPwr * Time.deltaTime, transform.position.z));
                //rb.velocity.Scale(new Vector3(knockbackDir.x * -50, (knockbackDir.y + 1) * knockbackPwr, transform.position.z));
                //GetComponent<Rigidbody2D>().velocity = new Vector3(knockbackDir.x * 25,  knockbackPwr, transform.position.z);
            }
            else if (facingRight)
            {
                rb.AddForce(new Vector3(knockbackDir.x * 50 * Time.deltaTime, (knockbackDir.y+1) * knockbackPwr * Time.deltaTime, transform.position.z));
                //rb.velocity.Scale(new Vector3(knockbackDir.x * -50, (knockbackDir.y + 1) * knockbackPwr, transform.position.z));
                //GetComponent<Rigidbody2D>().velocity = new Vector3(knockbackDir.x * -25,  knockbackPwr, transform.position.z);


            }
        }
        yield return 0;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CheckPoint")
        {
            gameController.respawnPoint = other.transform.position;
        }
        if (other.tag == "fallDetector")
        {
            PlayerTakeDamage(999);
        }
    }

    void PlayerDie()
    {
        if (life > 0)
        {
            life -= 1;
            transform.position = gameController.respawnPoint;
            health = Maxhealth;
            Boss.gameObject.SetActive(false);
            Debug.Log("Respawned");
        }
        else
        {
            gameController.GameOver();
            Destroy(player);
        }
    }



}
