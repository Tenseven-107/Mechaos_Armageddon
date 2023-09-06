using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetcicleEffect : MonoBehaviour
{
    [SerializeField] float reticleSpeed = 120f;


    private void FixedUpdate()
    {
        Quaternion newRot = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + reticleSpeed * Time.deltaTime);
        transform.rotation = newRot;
    }
}
