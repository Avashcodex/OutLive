using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatesky : MonoBehaviour
{
    public float Rotatespeed = 1.2f;
 
    void Update()
    {
       RenderSettings.skybox.SetFloat("_Rotation", Time.time * Rotatespeed);
        
    }
}
