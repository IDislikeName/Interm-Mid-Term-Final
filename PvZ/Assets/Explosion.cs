using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        StartCoroutine(inActive());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            collision.GetComponent<SpriteRenderer>().color = Color.black;
            collision.GetComponent<Zombie>().currentHp -= 90;
        }
    }
    IEnumerator inActive()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
