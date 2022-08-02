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
    }

    // Update is called once per frame
    void Update()
    {
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
                rb.velocity = new Vector2(-0.8f / timePerSquare, 0);
            }
            else if (currentState == State.ATTACKING)
            {
                GetComponent<Animator>().SetBool("Attacking", true);
                rb.velocity = new Vector2(0, 0);
                currentCD -= Time.deltaTime;
                if (currentCD <= 0 && target != null)
                {
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
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
