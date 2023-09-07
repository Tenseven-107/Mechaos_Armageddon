using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOff : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
