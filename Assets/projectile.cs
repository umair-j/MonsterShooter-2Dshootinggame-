using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public GameObject blood;
    public int damage;
    public float lifetime;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyProjectile",lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.GetComponent<enemydamage>().doDamage(damage);
            destroyProjectile();
        }
    }
    void destroyProjectile()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
