using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    public int rows = 5;
    public int cols = 9;
    public GameObject cell;
    public GameObject[,] map;
    public float cellx = 0.8f;
    public float celly = 1f;
    public GameObject mouseHoverCell;
    private void Start()
    {
        GenerateMap();
    }
    public void GenerateMap()
    {
        map = new GameObject[rows, cols];
        for (int i=0; i<rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject c = Instantiate(cell,transform);
                c.transform.position = new Vector2(transform.position.x+j*cellx, transform.position.y + i * celly);
                c.GetComponent<Cell>().mapX = i;
                c.GetComponent<Cell>().mapY = j;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (mouseHoverCell != null)
            {
                if (GameManager.instance.selectedPacket == null)
                {

                }
                else
                {
                    if (mouseHoverCell.GetComponent<Cell>().plant == null)
                    {
                        GameManager.instance.selectedPacket.Plant(mouseHoverCell);
                    }
                }
                GameManager.instance.DeselectAll();
            }
            else
            {
                if(!GameManager.instance.onUI)
                    GameManager.instance.DeselectAll();
            }
        }

    }
}
