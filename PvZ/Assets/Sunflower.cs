using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour
{
    public GameObject sun;
    public float spawnTime = 22f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sun(8f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Sun(float spawnT)
    {
        yield return new WaitForSeconds(spawnT);
        GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.yellow, 2f);
        yield return new WaitForSeconds(2f);
        GameObject s = Instantiate(sun);
        s.transform.position = new Vector3(transform.position.x, transform.position.y+0.1f, 1);
        s.GetComponent<Sun>().target = new Vector3(s.transform.position.x + Random.Range(-0.3f, 0.3f), transform.position.y-0.4f,1);
        GetComponent<SpriteRenderer>().color = Color.Lerp(Color.yellow, Color.white, 2f);
        if (GameManager.instance.playing)
        {
            StartCoroutine(Sun(spawnTime));
        }
    }
}
