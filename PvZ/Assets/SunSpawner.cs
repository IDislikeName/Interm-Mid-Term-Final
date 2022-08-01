using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    public float spawnTime;
    public GameObject sun;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sun());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Sun()
    {
        yield return new WaitForSeconds(spawnTime);
        GameObject s =  Instantiate(sun);
        s.transform.position = new Vector3(Random.Range(-3.5f,3.5f),3.4f,1);
        s.GetComponent<Sun>().target = new Vector2(s.transform.position.x,Random.Range(-2.5f, 1.7f));
        if (GameManager.instance.playing)
        {
            StartCoroutine(Sun());
        }    
    }
}
