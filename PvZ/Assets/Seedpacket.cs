using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Seedpacket : MonoBehaviour, IPointerClickHandler
{
    public GameObject plant;
    public bool selected = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        selected = !selected;
        if (selected)
        {
            GameManager.instance.selectedPlant = plant;
        }
        else
        {
            GameManager.instance.selectedPlant = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
