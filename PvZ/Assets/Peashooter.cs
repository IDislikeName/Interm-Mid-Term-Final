using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : MonoBehaviour
{
    public GameObject projectile;
    public float attackCD;
    public float currentCD;
    public float range;
    public LayerMask layer;
    public Vector3 offset;
    public AudioClip shootSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.right, range,layer);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Zombie"))
            {
                currentCD -= Time.deltaTime;
                if (currentCD <= 0)
                {
                    currentCD = attackCD;
                    Shoot();
                }
            }       
        }
    }
    public void Shoot()
    {
        SoundManager.instance.PlayClip(shootSound);
        GameObject proj = Instantiate(projectile);
        proj.transform.position = transform.position + offset;
    }
}
