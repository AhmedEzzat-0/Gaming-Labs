using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float movespeed;
    public float jumpHeight;
    public KeyCode L;
    public KeyCode R;
    public KeyCode space;
    
    public Transform groundcheck;
    public float r;
    public LayerMask whatIsGround;
    private bool grounded;
private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {

anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));


if (Input.GetKeyDown(space) && grounded){
    jump();
}

     if (Input.GetKey(L))  {
        GetComponent<Rigidbody2D>().velocity= new Vector2(-movespeed, GetComponent<Rigidbody2D>().velocity.y);
       
        if(GetComponent<SpriteRenderer>()!=null)
        {
GetComponent<SpriteRenderer>().flipX = true;
        }
     }

     if (Input.GetKey(R))  {
        GetComponent<Rigidbody2D>().velocity= new Vector2(movespeed, GetComponent<Rigidbody2D>().velocity.y);
       
        if(GetComponent<SpriteRenderer>()!=null)
        {
GetComponent<SpriteRenderer>().flipX = false;
        }
     }
     anim.SetBool("Grounded", grounded);
        
    }

    void jump(){
        GetComponent<Rigidbody2D>().velocity= new Vector2( GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
    

   void FixedUpdate()
{
    grounded = Physics2D.OverlapCircle(
        groundcheck.position,
        r,
        whatIsGround
    );
}
}
