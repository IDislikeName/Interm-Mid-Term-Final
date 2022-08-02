using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    // Update is called once per frame
    void Update()
    {
        
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
