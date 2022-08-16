using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        GameManager.instance.StartCoroutine(GameManager.instance.QuitToMenu());
    }
}
