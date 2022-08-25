using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioClip start;
    public GameObject helpstuff;
    public GameObject options;
    public GameObject quitMenu;
    public Slider music;
    public Slider fx;
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
        SoundManager.instance.PlayClip(SoundManager.instance.uiSound);
        quitMenu.SetActive(!quitMenu.activeSelf);
    }
    public void QuitGame()
    {
        SoundManager.instance.PlayClip(SoundManager.instance.uiSound);
        Application.Quit();
    }
    public void Help()
    {
        SoundManager.instance.PlayClip(SoundManager.instance.uiSound);
        helpstuff.SetActive(!helpstuff.activeSelf);
    }
    public void Options()
    {
        SoundManager.instance.PlayClip(SoundManager.instance.uiSound);
        options.SetActive(!options.activeSelf);
        music.value = SoundManager.instance.BGM.volume;
        fx.value = SoundManager.instance.aud.volume;
    }
    public void SetVolMusic()
    {
        SoundData.mus = music.value;
        SoundManager.instance.SetVolBGM(SoundData.mus);

    }
    public void SetVolFX()
    {
        SoundData.f = fx.value;
        SoundManager.instance.SetVolVFX(SoundData.f);
    }
}
