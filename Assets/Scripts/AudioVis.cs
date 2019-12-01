using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVis : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] samples = new float[512];
    public static float[] frequencyBands = new float[8]; // 8 frequency bands

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MakeFrequencyBands();
        GetSpectrumAudioSource();
    }

    void GetSpectrumAudioSource(){
        audioSource.GetSpectrumData(
            samples,
            0,
            FFTWindow.Blackman // window function
        );

    }

    void MakeFrequencyBands(){
        int count = 0;
        for(int i = 0; i < 8; i++){
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            float avg = 0;
            
            if(i == 7){
                sampleCount += 2; // 510 -> 512
            }

            for(int j = 0; j < sampleCount; j++){
                avg += samples[count] * (count + 1); count++;
            }

            avg /= count;

            frequencyBands[i] = avg * 10;

        }
    }
}
