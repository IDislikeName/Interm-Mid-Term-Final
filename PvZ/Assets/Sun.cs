using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public AudioClip collectSound;
    public bool collected;
    public Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            if(Vector2.Distance(transform.position,target)>=0.1f)
                transform.position = Vector2.MoveTowards(transform.position, target, 10 * Time.deltaTime);
            else
            {
                Destroy(gameObject,0.3f);
            }
        }
    }
    private void OnMouseDown()
    {
        if (!collected)
        {
            collected = true;
            SoundManager.instance.PlayClip(collectSound);
            GameManager.instance.sun += 25;
            
        }
        
    }
}
