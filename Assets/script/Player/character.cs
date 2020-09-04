using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;
using Firebase.Analytics;
public class character : Unit
{

    public GameObject respawn;
    public GameObject CanvasLose;
    public GameObject Controller;
    [SerializeField] public static int lives = 5;
    [SerializeField] public static int Score = 0;
    [SerializeField] public int key = 0;
    public int collectlives;
    // [SerializeField] private float circleRadius = 0.03f;
    [SerializeField] public Livesbar livesbar;
    [SerializeField] private float speed = 3.0F;
    public float jumpForce = 8.0F;
    public bool isGrounded = false;
    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private SpriteRenderer player;
    public GameObject currentRespawn;
    public LayerMask groundLayer;
    public AudioSource CheckPointSound;
    public AudioSource JumpMusic;

    private SpriteRenderer _sprite;
    private Vector2 _initialSpriteSize;
    //public Transform groundCheckPoint;
    //public float groundCheckRadius;

    //private bool isTouchingGround;

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value <= 5)
            {
                lives = value;
            }
            if (value == 0)
            {
                FirebaseAnalytics.LogEvent(
                 //2
                 FirebaseAnalytics.EventPostScore,
                 //3 
                 new Parameter[] {
                      new Parameter(
                        //4
                        FirebaseAnalytics.ParameterScore, Score),
                 }
                );
                CanvasLose.SetActive(true);
                Controller.SetActive(false);
                lives = 5;
                Score = 0;
                Destroy(gameObject);
                

            }
            else
            {
                Controller.SetActive(true);
            }
            livesbar.Refresh(value);
        }
    }


    //Зберігаю життя
    public static void Save()
    {

        PlayerPrefs.SetInt("exampleIntSave", lives);

    }
    void CollectSavedValues()
    {
        collectlives = PlayerPrefs.GetInt("exampleIntSave");
        livesbar.Refresh(Lives);
    }

    void Start()
    {
        livesbar = FindObjectOfType<Livesbar>();
         rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        _startParentTransform = gameObject.transform.parent;

        Save();
        CollectSavedValues();
        // Чек поінт
        //transform.position = new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));
        Time.timeScale = 1;

        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _initialSpriteSize = _sprite.size;

    }
    private void FixedUpdate()
    {
        //CheckGround();
        IsGrounded();

    }
    private void Update()
    {
        //int yMovement = (int)Input.GetAxisRaw("Vertical");
        //    if(yMovement == 1)
        //    {
        //    Jump();
        //    }
        //Jump();

        if (IsGrounded() && Input.GetButtonUp("Jump"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);

        }

        float movement = Input.GetAxis("Horizontal");

        if (Input.GetButton("Horizontal"))
        {
            Run(movement);
        }
        //if (IsGrounded() && Input.GetButtonDown("Jump")) Jump();
        //transform.position = new Vector3(sprite.transform.position.x, sprite.transform.position.y, -5.0F);

    }



    // Фліп по Х
    public void Run(float movement)
    {
        Vector3 direction = transform.right * movement;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

    }
    // Прижкі
    public void Jump()
    {
        JumpMusic.Play();
        if (IsGrounded() /*&& Input.GetButtonUp("Jump")*/)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            animator.SetTrigger("Jump");

        }
        //Debug.Log("SpaceJump");
    }
    // Отримання дамга
    private bool canDamage = true;


    private IEnumerator DamageAnim()
    {
        canDamage = false;
        for (int i = 0; i < 2; i++)
        {
            _sprite.size = new Vector2(_initialSpriteSize.x, _initialSpriteSize.y / 2);
            _sprite.color = new Color(0.5f, 1, 1, 1);
            yield return new WaitForSeconds(0.2f);
            _sprite.size = new Vector2(_initialSpriteSize.x, _initialSpriteSize.y);
            _sprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.2f);
        }
        canDamage = true;
    }

    public override void ReceiveDamage()
    {
        Debug.Log("ReceiveDamage");
        if (canDamage)
        {
            Lives--;
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.up * 3f, ForceMode2D.Impulse);
            StartCoroutine(DamageAnim());
        }



    }
    // Функція додавання життя
    public override void AddLives()
    {
        Lives++;

    }
    // Функція віднімання життя від ворога
    public override void DeductLives()
    {
        if (canDamage)
        {
            Lives--;
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.up * 2f, ForceMode2D.Impulse);
            StartCoroutine(DamageAnim());
        }
    }


    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;
        Debug.DrawRay(position, direction, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
    /////////////////////////////////////////////////////////////////////////////
    private Transform _startParentTransform;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Platform>() != null)
            this.transform.parent = collision.transform;


    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Platform>() != null)
            this.transform.parent = _startParentTransform;

    }
    public void AddKey()
    {
        key++;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "checkpoint")
        {
            CheckPointSound.Play();
            currentRespawn = collision.gameObject;
            PlayerPrefs.SetFloat("xPos", transform.position.x);
            PlayerPrefs.SetFloat("yPos", transform.position.y);

        }
    }
 
}
