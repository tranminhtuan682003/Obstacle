using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D colider;
    public LayerMask groudlayer;
    private float StartPosition;

    [SerializeField] private float JumpSpeed;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private Transform bulletposition;
    [SerializeField] private TrailRenderer trailRenderer;

    [Header("acceleration")]
    [SerializeField] private float moveSpeed ;


    [Header("Dash")]
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingtime = 0.2f;
    private float dashingcooldown = 1f;
    private bool isfacing;

    [Header("wall jump system")]
    public Transform wallcheck;
    bool isWallTouch;
    bool isSilding;
    public float wallSlidingSpeed;
    bool isJump;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        colider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        StartPosition = transform.position.x;
    }

    void Update()
    {

        Move();
        if (isDashing)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        isWallTouch = Physics2D.OverlapBox(wallcheck.position, new Vector2(0.17f, 0.8f), 0, 0);
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        if(isWallTouch)
        {
            isSilding = true;
        }
        else
        {
            isSilding = false;
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        if (isSilding)
        {
            rb.velocity = new Vector2(rb.velocity.x,Mathf.Clamp(rb.velocity.y,-wallSlidingSpeed,float.MaxValue));
        }

    }
    private void Move()
    {
        float Dhorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Dhorizontal * moveSpeed, rb.velocity.y);
        Jump();
        playerFall();
        if (rb.velocity.x < 0)
        {
            Flip(-1);
        }
        else if (rb.velocity.x>0)
        {
            //isfacing = true;
            Flip(1);
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (GroundCheck())
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
                isJump = true;
            }
            else if (isJump) 
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
                isJump = false;
            }

        }
    }
    private void playerFall()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !GroundCheck())
        {
            rb.velocity = new Vector2(rb.velocity.x, -JumpSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Triangle"))
        {
            GameObject[] playerList = GameObject.FindGameObjectsWithTag("player");
            foreach (GameObject playerGameObject in playerList) 
            {
                Destroy(playerGameObject);
            }
            SceneManaGer.instance.ResetLevel();
        }
    }
    private void Fire()
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if(bullet != null)
        {
            bullet.transform.position = bulletposition.position;
            bullet.SetActive(true);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingtime);
        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingcooldown);
        canDash = true;
    }
    public void Flip(int x)
    {
        transform.localScale = new Vector3(x*1, 1, 1);
    }
    public bool GroundCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast(colider.bounds.center, colider.bounds.size,0f,Vector2.down,0.1f,groudlayer);
        return hit.collider != null;
    }
}
