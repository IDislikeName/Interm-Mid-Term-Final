using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Seedpacket : MonoBehaviour, IPointerClickHandler
{
    public GameObject plant;
    public bool selected = false;
    public float currentCD = 0;
    public void OnPointerClick(PointerEventData eventData)
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
            GetComponentInParent<Seedpackets>().DeselectAll();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentCD -= Time.deltaTime;
        currentCD= Mathf.Max(0, currentCD);
    }
    public void Select()
    {
        
        GetComponentInParent<Seedpackets>().DeselectAll();
        selected = true;
        GameManager.instance.selectedPacket = this;
        GetComponent<Image>().color = Color.grey;
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
        plant = Instantiate(GameManager.instance.selectedPacket.plant);
        plant.transform.position = cell.transform.position;
        GameManager.instance.selectedPacket.Recharge();
        GameManager.instance.sun -= plant.GetComponent<Plant>().sunCost;
    }
}
