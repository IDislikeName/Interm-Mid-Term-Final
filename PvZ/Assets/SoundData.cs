using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundData : MonoBehaviour
{
    public static float mus = 0.5f;
    public static float f = 0.5f;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
