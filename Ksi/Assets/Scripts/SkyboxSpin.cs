using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxSpin : MonoBehaviour
{
    public float speed_multiplier = 10.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Sets the float value of "_Rotation", adjust it by Time.time and a multiplier.
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed_multiplier);
    }
}
