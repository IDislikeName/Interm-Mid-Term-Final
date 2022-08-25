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
    }
    IEnumerator StartSpawnZombies()
    {
        yield return new WaitForSeconds(20f);
        SoundManager.instance.PlayClip(spawnClip);
        Spawn(4, zombie);
        yield return new WaitForSeconds(7f);
        Spawn(2, zombie);
        yield return new WaitForSeconds(18f);
        Spawn(3, zombie);
        yield return new WaitForSeconds(17f);
        Spawn(4, zombie);
        yield return new WaitForSeconds(1f);
        Spawn(1, zombie);
        yield return new WaitForSeconds(19f);
        Spawn(0, zombie);
        yield return new WaitForSeconds(1f);
        Spawn(2, zombie);
        yield return new WaitForSeconds(17f);
        Spawn(4, zombie_c);
        yield return new WaitForSeconds(25f);
        Spawn(1, zombie);
        Spawn(2, zombie);
        Spawn(3, zombie);
        yield return new WaitForSeconds(12f);
        Spawn(0, zombie_c);
        Spawn(4, zombie);
        yield return new WaitForSeconds(7f);
        Spawn(2, zombie_c);
        Spawn(3, zombie);
        yield return new WaitForSeconds(10f);
        yield return new WaitForSeconds(5f);
        SoundManager.instance.PlayClip(waveSound);
        waveText.SetActive(true);
        yield return new WaitForSeconds(3f);
        waveText.SetActive(false);
        yield return new WaitForSeconds(3f);
        Spawn(4,zombie);
        Spawn(3,zombie);
        Spawn(2,zombie_c);
        Spawn(2,zombie);
        Spawn(1,zombie);
        Spawn(1,zombie);
        Spawn(0,zombie);
        Spawn(0,zombie_c);
        yield return new WaitForSeconds(20f);
        Spawn(4, zombie);
        Spawn(4, zombie_c);
        Spawn(3, zombie);
        Spawn(2, zombie);
        Spawn(0, zombie_c);
        yield return new WaitForSeconds(15f);
        Spawn(0, zombie_b);
        yield return new WaitForSeconds(15f);
        Spawn(4, zombie_c);
        Spawn(3, zombie);
        Spawn(0, zombie_c);
        yield return new WaitForSeconds(15f);
        Spawn(4, zombie_c);
        Spawn(2, zombie_c);
        Spawn(1, zombie);
        yield return new WaitForSeconds(15f);
        Spawn(4, zombie);
        Spawn(3, zombie_c);
        Spawn(0, zombie_c);
        yield return new WaitForSeconds(15f);
        Spawn(4, zombie);
        Spawn(2, zombie_c);
        Spawn(3, zombie_c);
        Spawn(1, zombie);
        yield return new WaitForSeconds(15f);
        Spawn(2, zombie_b);
        Spawn(1, zombie);
        Spawn(0, zombie);
        yield return new WaitForSeconds(15f);
        Spawn(4, zombie_c);
        Spawn(3, zombie_c);
        Spawn(2, zombie_c);
        yield return new WaitForSeconds(15f);
        Spawn(3, zombie_c);
        Spawn(1, zombie_c);
        Spawn(1, zombie_c);
        Spawn(0, zombie);
        yield return new WaitForSeconds(20f);
        StartCoroutine(FinalWave());
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
        Spawn(1, zombie,true);
        Spawn(2, zombie,true);
        Spawn(3, zombie,true);
        Spawn(4, zombie_c,true);
        yield return new WaitForSeconds(4f);
        Spawn(0, zombie_b, true);
        Spawn(1, zombie, true);
        Spawn(2, zombie, true);
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
