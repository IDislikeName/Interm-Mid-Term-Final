using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallnut : MonoBehaviour
{
    SpriteRenderer sr;
    Plant  p;
    public Sprite broken1;
    public Sprite broken2;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        p = GetComponent<Plant>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p.currentHp <=27)
        {
            sr.sprite = broken2;
        }
        else if (p.currentHp <=54)
        {
            sr.sprite = broken1;
        }
    }
}
