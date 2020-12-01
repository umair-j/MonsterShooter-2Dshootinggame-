using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydamage : MonoBehaviour
{
    public float timeBetweenAttack;
    public int health;
    public int damage;
    [HideInInspector]
    public Transform player;
    
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
   
    public void doDamage(int damageamount)
    {
        health -= damageamount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
