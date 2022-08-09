using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMine : MonoBehaviour
{
    public bool armed = false;
    public Sprite unarmed;
    public Sprite ready;
    public Sprite boom;
    public AudioClip explode;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Arming());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Arming()
    {
        sr.sprite = unarmed;
        yield return new WaitForSeconds(15f);
        sr.sprite = ready;
        armed = true;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (armed && collision.CompareTag("Zombie"))
        {
            collision.GetComponent<Zombie>().currentHp -= 90;
            StartCoroutine(Explode());
        }
    }
    IEnumerator Explode()
    {
        SoundManager.instance.PlayClip(explode);
        sr.sprite = boom;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
