using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReadyText : MonoBehaviour
{
    public Sprite set;
    public Sprite go;
    private void OnEnable()
    {
        StartCoroutine(Stuff());
    }
    IEnumerator Stuff()
    {
        yield return new WaitForSeconds(0.8f);
        GetComponent<Image>().sprite = set;
        GetComponent<Image>().SetNativeSize();
        yield return new WaitForSeconds(0.8f);
        GetComponent<Image>().sprite = go;
        GetComponent<Image>().SetNativeSize();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
