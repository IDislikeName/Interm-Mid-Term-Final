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
    public float targetTime=200f;
    private RectTransform progressBarRT;
    public bool cameraMoving = false;
    public List<GameObject> finalWave;
    public AudioClip winSound;
    public GameObject letter;
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
            
            if(targetTime>0.0f){
                targetTime -= Time.deltaTime;
                progressBarRT.localScale = new Vector3((200f-targetTime) / 200f, 1, 1);
            }
            else
            {
                if (finalWave.Count == 0)
                {
                    Win();
                }
            }
        }
        if (cameraMoving)
        {
            Camera.main.transform.Translate(-Camera.main.transform.right * Time.deltaTime*3f);
            if(Vector2.Distance(Camera.main.transform.position,new Vector2(0, 0)) <= 0.1f)
            {
                Camera.main.transform.position = new Vector3(0, 0, -10);
               cameraMoving = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
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
        SoundManager.instance.BGM.Stop();
        cameraMoving = true;
        yield return new WaitUntil(() =>!cameraMoving);
        SoundManager.instance.PlayClip(start);
        readyText.SetActive(true);
        yield return new WaitForSeconds(3f);
        SoundManager.instance.PlayBGM(backGround);
        currentState = State.PLAYING;
        seedPackets.shovelBox.SetActive(true);
        
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
        GameObject l= Instantiate(letter);
        l.transform.position = new Vector2(0, 0);
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }
    public IEnumerator QuitToMenu(){
        SoundManager.instance.BGM.Stop();
        SoundManager.instance.PlayClip(winSound);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}