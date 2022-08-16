using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float maxHp;
    public float currentHp;
    public float timePerSquare;
    public float atkCD = 0.2f;
    public float currentCD;
    private Rigidbody2D rb;
    public GameObject target;
    public bool dead = false;
    public AudioClip biteSound;
    public AudioClip eatSound;
    public AudioClip dieSound;
    public bool slowed = false;
    public float slowAtkCD;
    public float slowTimer;
    public GameObject headGear;
    public enum State
    {
        WALKING,
        ATTACKING,
        DEAD,
    }
    public State currentState = State.WALKING;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(0, 5);
        rb = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
        slowAtkCD = 2 * atkCD;
        if (headGear != null)
        {
            currentHp += headGear.GetComponent<HeadGear>().hp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (slowTimer>0)
        {
            slowed = true;
            GetComponent<SpriteRenderer>().color = Color.blue;
            if (headGear != null)
            {
                headGear.GetComponent<SpriteRenderer>().color = Color.blue;

            }
            slowTimer -= Time.deltaTime;
        }
        if (currentHp <= 0)
        {
            currentState = State.DEAD;
        }
        if (currentState != State.DEAD)
        {
            if (target != null)
            {
                currentState = State.ATTACKING;
            }
            else
            {
                currentState = State.WALKING;
            }

            if (currentState == State.WALKING)
            {
                GetComponent<Animator>().SetBool("Attacking", false);
                if(slowed)
                    rb.velocity = new Vector2(-0.4f / timePerSquare, 0);
                else
                    rb.velocity = new Vector2(-0.8f / timePerSquare, 0);
            }
            else if (currentState == State.ATTACKING)
            {
                GetComponent<Animator>().SetBool("Attacking", true);
                rb.velocity = new Vector2(0, 0);
                currentCD -= Time.deltaTime;
                if (currentCD <= 0 && target != null)
                {
                    if(slowed)
                        currentCD = slowAtkCD;
                    else
                        currentCD = atkCD;
                    Attack(target);
                }
            }
        }
        else
        {
            if (!dead)
            {         
                StartCoroutine("Die");
            }
        }
        
    }
    public void Attack(GameObject target)
    {
        SoundManager.instance.PlayClip(biteSound);
        target.GetComponent<Plant>().TakeDamage();
        if (target.GetComponent<Plant>().currentHp <= 0)
        {
            SoundManager.instance.PlayClip(eatSound);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Plant"))
        {
            target = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Plant"))
        {
            target = null;
        }
    }
    IEnumerator Die()
    {
        dead = true;
        SoundManager.instance.PlayClip(dieSound);
        GetComponent<Animator>().Play("z_die");
        yield return new WaitForSeconds(1.5f);
        if (GameManager.instance.finalWave.Contains(gameObject))
        {
            GameManager.instance.finalWave.Remove(gameObject);
        }
        Destroy(gameObject);
    }
    public void Slowed()
    {
        slowTimer = 10f;   
    }
}
