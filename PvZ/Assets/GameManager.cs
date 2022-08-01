using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    public void DeselectAll()
    {
        seedPackets.DeselectAll();
    }
    private void Update()
    {
        sunText.text  = sun + "";
    }
}