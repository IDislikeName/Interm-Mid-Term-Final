using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shovel : MonoBehaviour, IPointerClickHandler , IPointerEnterHandler, IPointerExitHandler
{
    public GameObject shovel;
    public bool selected = false;
    public AudioClip shovelSound;
    public AudioClip clickSound;
    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.instance.PlayClip(clickSound);
        if (!selected)
        {
            Select();

        }
        else
        {
            GameManager.instance.DeselectAll();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        shovel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            shovel.transform.position =  new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,1);
        }
    }
    public void Select()
    {

        GameManager.instance.DeselectAll();
        selected = true;
    }
    public void Deselect()
    {
        selected = false;

        shovel.transform.position = new Vector3(1.23f, 2.65f, 10);
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.instance.onUI = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.instance.onUI = true;
    }
    public void Remove(GameObject cell)
    {
        SoundManager.instance.PlayClip(shovelSound);
        Destroy(cell.GetComponent<Cell>().plant);
        cell.GetComponent<Cell>().plant = null;
    }
}
