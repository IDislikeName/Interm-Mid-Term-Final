using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBomb : MonoBehaviour
{
    public Sprite explode;
    public AudioClip cl;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Explode()
    {
        SoundManager.instance.PlayClip(cl);
        yield return new WaitForSeconds(1.2f);
        GetComponent<SpriteRenderer>().sprite = explode;
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
