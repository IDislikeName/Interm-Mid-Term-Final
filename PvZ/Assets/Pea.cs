using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pea : MonoBehaviour
{
    public float damage;
    public float spd;
    public AudioClip hitSound;
    public bool collided = false;
    public bool snow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(spd, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            if (!collided)
            {
                collided = true;
                if (!collision.GetComponent<Zombie>().dead)
                {
                    collision.GetComponent<Zombie>().currentHp -= damage;
                    if (snow)
                    {
                        collision.GetComponent<Zombie>().Slowed();
                    }
                    SoundManager.instance.PlayClip(hitSound);
                    Destroy(gameObject);
                }
            }
            
        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
