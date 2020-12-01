using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meeleeEnemy : enemydamage
{
    public float attackspeed;
    private float attackTime;
    public int speed;
    public float stopdistance;
    // Start is called before the first frame update
    public override void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {
        if (base.player.position != null)
        {
            if (Vector2.Distance(transform.position, base.player.position) > stopdistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, base.player.position, speed * Time.deltaTime);
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
        base.player.GetComponent<movement>().takeDamage(damage);
        Vector2 originalPosition = transform.position;
        Vector2 attackPosition = base.player.position;
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

