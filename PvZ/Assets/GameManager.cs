using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public static GameManager FindInstance()
    {
        return instance; //that's just a singletone as the region says
    }

    private void Awake() //this happens before the game even starts and it's a part of the singletone
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else if (instance == null)
        {
            //DontDestroyOnLoad(this);
            instance = this;
        }
    }
    public int sun = 50;
    public Seedpacket selectedPacket;
    public Seedpackets seedPackets;
    public TMP_Text sunText;
    public bool onUI;
    public bool playing = true;
    public Shovel shov;
    public GameObject readyText;
    public GameObject choosePlants;
    public AudioClip start;
    public AudioClip backGround;
    public GameObject lostText;
    public AudioClip lose;
    public float targetTime=139.0f;
    private RectTransform progressBarRT;
    public void DeselectAll()
    {
        seedPackets.DeselectAll();
    }
    public enum State
    {
        SELECTING,
        PLAYING,
        LOST,
        WON,
    }
    public State currentState = State.SELECTING;
    private void Start()
    {
        //GameStart();
        progressBarRT=GameObject.FindGameObjectWithTag("PBC").GetComponent<RectTransform>();
    }
    private void Update()
    {
        sunText.text  = sun + "";
        if(currentState==State.PLAYING){
            targetTime-=Time.deltaTime;
            progressBarRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, (139f-targetTime)/139f*59.735f);
            progressBarRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, progressBarRT.rect.height);
            if(targetTime<=0.0f){
               Win();
            }
        }
    }
    public void GameStart()
    {
        if(seedPackets.packets.Count==6)
            StartCoroutine(Ready()); 
    }
    IEnumerator Ready()
    {
        SoundManager.instance.PlayClip(SoundManager.instance.uiSound);
        choosePlants.SetActive(false);
        SoundManager.instance.PlayClip(start);
        readyText.SetActive(true);
        yield return new WaitForSeconds(3f);
        SoundManager.instance.PlayBGM(backGround);
        currentState = State.PLAYING;
        
        GetComponent<SunSpawner>().enabled = true;
    }
    public void Lose()
    {
        currentState = State.LOST;
        lostText.SetActive(true);
        SoundManager.instance.PlayClip(lose);
        StartCoroutine(RestartGame());

    }
    public void Win(){
        currentState=State.WON;
        Debug.Log("win");
        StartCoroutine(QuitToMenu());
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }
    IEnumerator QuitToMenu(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}