using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GameObject options;
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

    public void Op()
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
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
