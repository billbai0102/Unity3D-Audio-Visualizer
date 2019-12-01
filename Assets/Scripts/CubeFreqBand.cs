﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFreqBand : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioVis.frequencyBands[band] * scaleMultiplier) + startScale, transform.localScale.z);
    }
}
