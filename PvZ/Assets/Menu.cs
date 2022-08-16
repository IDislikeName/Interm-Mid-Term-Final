using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioClip start;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAdv()
    {
        StartCoroutine(bruh());

    }
    IEnumerator bruh()
    {
        SoundManager.instance.BGM.Stop();
        SoundManager.instance.PlayClip(start);
        yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
