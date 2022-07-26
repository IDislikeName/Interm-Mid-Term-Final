using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int mapX;
    public int mapY;
    public GameObject plant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (GameManager.instance.selectedPacket == null)
        {

        }
        else
        {
            if (plant == null)
            {
                GameManager.instance.selectedPacket.Plant(gameObject);
            }            
        }
        GameManager.instance.DeselectAll();
    }
}
