using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedpackets : MonoBehaviour
{
    public GameObject shovelBox;
    public List<GameObject> packets;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < packets.Count; i++)
        {
            packets[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(i*60-145,-2.5f,0);
        }
    }
    public void DeselectAll()
    {
        for(int i = 0; i < packets.Count; i++)
        {
            packets[i].GetComponent<Seedpacket>().Deselect();
        }
        shovelBox.GetComponent<Shovel>().Deselect();
        GameManager.instance.selectedPacket = null;        
    }
}
