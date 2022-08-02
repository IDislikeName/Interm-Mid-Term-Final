using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public AudioClip collectSound;
    public bool collected;
    public Vector2 endTarget;
    public Vector2 target;
    public float fallspeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            if (Vector2.Distance(transform.position, endTarget) >= 0.1f)
                transform.position = Vector2.MoveTowards(transform.position, endTarget, 10 * Time.deltaTime);
            else
            {
                Destroy(gameObject, 0.3f);
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, target) >= 0.1f)
                transform.position = Vector2.MoveTowards(transform.position, target, fallspeed * Time.deltaTime);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
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
    private void OnMouseOver()
    {
        GameManager.instance.onUI = true;
    }
    private void OnMouseExit()
    {
        GameManager.instance.onUI = false;
    }
    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(10f);
        if (!collected)
        {
            Destroy(gameObject);
        }
    }
}
