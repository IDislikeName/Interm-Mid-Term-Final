using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Seedpacket : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject plant;
    public bool selected = false;
    public float currentCD = 0;
    public AudioClip plantSound;
    public AudioClip clickSound;
    public bool chosen = false;
    public Vector3 ogpos;
    public Transform ogparent;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.instance.currentState == GameManager.State.SELECTING&&Camera.main.transform.position.x==3)
        {
            ToggleChoose();
        }
        else if (GameManager.instance.currentState == GameManager.State.PLAYING)
        {
            if (!selected)
            {
                if (GameManager.instance.sun >= plant.GetComponent<Plant>().sunCost && currentCD <= 0)
                {
                    Select();
                }
            }
            else
            {
                SoundManager.instance.PlayClip(SoundManager.instance.uiSound);
                GetComponentInParent<Seedpackets>().DeselectAll();
            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        ogpos = GetComponent<RectTransform>().localPosition;
        ogparent = transform.parent;
        if (plant.GetComponent<Plant>().recharge > 10f)
        {
            Recharge();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currentState == GameManager.State.PLAYING)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            currentCD -= Time.deltaTime;
            currentCD = Mathf.Max(0, currentCD);
            if(currentCD>0)
                transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, currentCD / plant.GetComponent<Plant>().recharge, 1);
            else
                transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 0, 1);
            if (!selected)
            {
                if (GameManager.instance.sun < plant.GetComponent<Plant>().sunCost||currentCD>0)
                {
                    GetComponent<Image>().color = Color.gray;
                }
                else
                {
                    GetComponent<Image>().color = Color.white;
                }
            }           
        }
    }
    public void Select()
    {
        
        GetComponentInParent<Seedpackets>().DeselectAll();
        selected = true;
        GameManager.instance.selectedPacket = this;
        GetComponent<Image>().color = Color.gray;
        SoundManager.instance.PlayClip(clickSound);
    }
    public void Deselect()
    {
        selected = false;
        GetComponent<Image>().color = Color.white;

    }
    public void Recharge()
    {
        currentCD = plant.GetComponent<Plant>().recharge;
    }
    public void Plant(GameObject cell)
    {
        SoundManager.instance.PlayClip(plantSound);
        cell.GetComponent<Cell>().plant = Instantiate(plant);
        cell.GetComponent<Cell>().plant.transform.position = cell.transform.position;
        GameManager.instance.selectedPacket.Recharge();
        GameManager.instance.sun -= plant.GetComponent<Plant>().sunCost;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.instance.onUI = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.instance.onUI = true;
    }
    public void ToggleChoose()
    {
        if (!chosen)
        {
            chosen = true;
            if (GameManager.instance.seedPackets.packets.Count < 6)
            {
                GameManager.instance.seedPackets.packets.Add(gameObject);
                transform.SetParent(GameManager.instance.seedPackets.transform);
            }
        }
        else
        {
            chosen = false;
            
            GameManager.instance.seedPackets.packets.Remove(gameObject);
            transform.SetParent(ogparent);
            GetComponent<RectTransform>().anchoredPosition = ogpos;
        }
        SoundManager.instance.PlayClip(SoundManager.instance.uiSound);
    }
}
