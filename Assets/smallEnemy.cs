using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallEnemy : MonoBehaviour
{

    public float attackspeed;
    private float attackTime;
    public int speed;
    public float stopdistance;
    // Start is called before the first frame update
    
    public float timeBetweenAttack;
    public int health;
    public int damage;
    [HideInInspector]
    private Transform player;

    public void Start()
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


    
    // Update is called once per frame
    void Update()
    {
        if (player.position != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopdistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(attack());
                    attackTime = Time.time + timeBetweenAttack;
                }
            }

        }
    }
    IEnumerator attack()
    {
        player.GetComponent<movement>().takeDamage(damage);
        Vector2 originalPosition = transform.position;
        Vector2 attackPosition = player.position;
        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackspeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, attackPosition, formula);
            yield return null;
        }
    }

}
