using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conjurer : enemydamage
{
    public float timeBetweenConjuring;
    private float conjuringTime;

    public enemydamage enemy;

    public float speed;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    //private Vector2 currentPosition;
    private Vector2 targetPosition;
    private Animator anim;
    // Start is called before the first frame update
    public override void Start()
   {
       base.Start();
       float randomX = Random.Range(minX, maxX);
       float randomY = Random.Range(minY, maxY);
       targetPosition = new Vector2(randomX, randomY);
       anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    private void Update()
   {
       if (player != null)
       {
           if(Vector2.Distance(transform.position,targetPosition) > .5f)
           {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                //anim.SetBool("isRunning", true);
           }
            else
            {
                anim.SetBool("isRunning", false);
                if(Time.time >= conjuringTime)
                {
                    conjuringTime = Time.time + timeBetweenConjuring;
                    //anim.SetTrigger("isConjuring");
                    Summon();

                }
            }
       }
    }
    public void Summon()
    {
        if (player != null)
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }
    }
  
}
