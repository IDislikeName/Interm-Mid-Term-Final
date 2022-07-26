using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedpackets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeselectAll()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Seedpacket>().Deselect();
        }
        GameManager.instance.selectedPacket = null;
    }
}
