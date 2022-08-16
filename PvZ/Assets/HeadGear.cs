using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGear : MonoBehaviour
{
    public float hp;
    public float threshold1;
    public float threshold2;
    public float threshold3;
    public Sprite broken1;
    public Sprite broken2;
    SpriteRenderer sr;
    Zombie zom;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        zom = GetComponentInParent<Zombie>();
    }

    // Update is called once per frame
    void Update()
    {
        if(zom.currentHp<= threshold3)
        {
            Destroy(gameObject);
        }
        else if (zom.currentHp <= threshold2)
        {
            sr.sprite = broken2;
        }
        else if (zom.currentHp <= threshold1)
        {
            sr.sprite = broken1;
        }
    }
}
