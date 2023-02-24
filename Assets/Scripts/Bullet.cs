using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

        Invoke("DestroyProjectile", lifeTime);

    }

    // Update is called once per frame
    

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            
        }

        if(collision.gameObject.tag == "walls" && collision.gameObject.tag == "floor")
        {
            Destroy(gameObject);
        }

    }

}
