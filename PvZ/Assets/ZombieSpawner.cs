using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public bool started = false;
    public AudioClip spawnClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currentState == GameManager.State.PLAYING)
        {
            if (!started)
            {
                started = true;
                StartCoroutine(StartSpawnZombies());
            }
        }
    }
    IEnumerator StartSpawnZombies()
    {
        yield return new WaitForSeconds(20f);
        SoundManager.instance.PlayClip(spawnClip);
        Spawn();
        StartCoroutine(SpawnZombies());
    }
    IEnumerator SpawnZombies()
    {
        yield return new WaitForSeconds(10f);
        Spawn();
        StartCoroutine(SpawnZombies());
    }
    public void Spawn()
    {
        int lane = Random.Range(0,5);
        lane -= 2;
        GameObject z = Instantiate(zombie);
        z.transform.position = new Vector3(4.3f, lane, 0);
    }
}
