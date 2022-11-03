using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [Header("Movement Properties")]
    public float walkSpeed;
    public float jumpSpeed=1f;
    public float force = 0.5f;
    public float airControl = 0.5f;
    public bool groundCheck;
    public Transform groundPoint;
    public LayerMask groundLayerMask;
    public float radius;

    Rigidbody2D rb;
   Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Jump();
        onGround();
        Quit();
        Restart();
    }

    public void Movement()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
       groundCheck = Physics2D.OverlapCircle(groundPoint.position, radius, groundLayerMask);

        if ((groundCheck) && x!=0.0)
        {
            rb.AddForce(Vector2.right * ((x > 0.0f) ? 1.0f : -1.0f) * force * ((groundCheck) ? 1.0f: airControl));
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, walkSpeed);
            anim.SetInteger("AnimationChange", 1);
        }
        if (x == 0 && (groundCheck))
            anim.SetInteger("AnimationChange", 0);

        Flip(x);
       
        
          
        
        
    }
    public void Flip(float x)
    {
        if (x != 0.0f)
            transform.localScale = new Vector3((x>0)?1:-1,1,1);
      
    }

    public void Jump()
    {
        float y = Input.GetAxisRaw("Jump");
        if(groundCheck && y > 0.0f)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            anim.SetInteger("AnimationChange", 2);
        }

    }

    public void onGround()
    {
        if (!groundCheck)
        {
            anim.SetInteger("AnimationChange", 2);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundPoint.position, radius);
    }

    private void Quit()
    {
        if(Input.GetKey(KeyCode.Q))
            Application.Quit();
    }
    void Restart()
    {
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene("Main");
           
    }

}
