using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);

        var elements = GameObject.FindObjectsOfType(typeof(DontDestroy));
        if(elements.Length > 1)
        {
            Destroy(elements[1]);
        }
    }
}
