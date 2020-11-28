using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float health;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized*speed;
        if(moveInput!=Vector2.zero){
            anim.SetBool("isRunning",true);
        }
        else
        {
            anim.SetBool("isRunning",false);
        }
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);        
    }
    public void takeDamage(int damageamount)
    {
        health -= damageamount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
