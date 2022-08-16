using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject zombie_c;
    public GameObject zombie_b;
    public bool started = false;
    public AudioClip spawnClip;
    public GameObject waveText;
    public AudioClip waveSound;
    public bool final = false;
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
        if (GameManager.instance.targetTime <= 20)
        {
            if (!final)
                StartCoroutine(FinalWave());
        }
    }
    IEnumerator StartSpawnZombies()
    {
        yield return new WaitForSeconds(20f);
        SoundManager.instance.PlayClip(spawnClip);
        Spawn(Random.Range(0, 5),zombie);
        StartCoroutine(SpawnZombies(15f));
    }
    IEnumerator SpawnZombies(float time)
    {
        yield return new WaitForSeconds(time);
        if (GameManager.instance.targetTime >= 150)
            Spawn(Random.Range(0, 5), zombie);
        else if (GameManager.instance.targetTime >=100)
        {
            int i = Random.Range(0, 3);
            if(i!=0)
                Spawn(Random.Range(0, 5), zombie);
            else
                Spawn(Random.Range(0, 5), zombie_c);
        }
        else if (GameManager.instance.targetTime >= 70)
        {
            int i = Random.Range(0, 2);
            if (i != 0)
                Spawn(Random.Range(0, 5), zombie);
            else
                Spawn(Random.Range(0, 5), zombie_c);
        }
        else if (GameManager.instance.targetTime >= 20)
        {
            int i = Random.Range(0, 4);
            if (i == 0)
                Spawn(Random.Range(0, 5), zombie);
            else if(i==1||i==2)
                Spawn(Random.Range(0, 5), zombie_c);
            else
                Spawn(Random.Range(0, 5), zombie_b);
        }
        if (GameManager.instance.targetTime>=150)
            StartCoroutine(SpawnZombies(15f));
        else if (GameManager.instance.targetTime >=100)
            StartCoroutine(SpawnZombies(12f));
        else if (GameManager.instance.targetTime >= 70)
            StartCoroutine(SpawnZombies(10f));
        else if (GameManager.instance.targetTime >= 20)
            StartCoroutine(SpawnZombies(7f));
    }
    IEnumerator FinalWave()
    {
        final = true;
        yield return new WaitForSeconds(5f);
        SoundManager.instance.PlayClip(waveSound);
        waveText.SetActive(true);
        yield return new WaitForSeconds(3f);
        waveText.SetActive(false);
        Spawn(0, zombie,true);
        Spawn(1, zombie_b,true);
        Spawn(2, zombie,true);
        Spawn(3, zombie_c,true);
        Spawn(4, zombie,true);
        yield return new WaitForSeconds(4f);
        Spawn(0, zombie, true);
        Spawn(1, zombie, true);
        Spawn(2, zombie_b, true);
        Spawn(3, zombie_c, true);
        Spawn(4, zombie, true);
    }
    public void Spawn(int lane, GameObject zombie)
    {
        GameObject z = Instantiate(zombie);
        z.transform.position = new Vector3(4.3f, lane-2, 0);
    }
    public void Spawn(int lane, GameObject zombie,bool final)
    {
        GameObject z = Instantiate(zombie);
        z.transform.position = new Vector3(4.3f, lane - 2, 0);
        if (final)
        {
            GameManager.instance.finalWave.Add(z);
        }
    }
}
