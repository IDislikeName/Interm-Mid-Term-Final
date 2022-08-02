using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public int sunCost;
    public float recharge;
    public Color ogcolor;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        ogcolor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage()
    {
        currentHp -= 1;
    }
}
