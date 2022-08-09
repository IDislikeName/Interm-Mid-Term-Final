using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMower : MonoBehaviour
{
    public bool activated = false;
    Rigidbody2D rb;
    public float speed;
    public AudioClip vroom;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            if (!activated)
            {
                activated = true;
                SoundManager.instance.PlayClip(vroom);
            }   
            collision.GetComponent<Zombie>().currentHp = 0;
        }
        else if (collision.CompareTag("Wall")){
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (activated)
        {
            rb.velocity = new Vector2(speed,0);
        }
    }
}
