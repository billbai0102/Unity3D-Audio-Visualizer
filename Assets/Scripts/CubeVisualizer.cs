using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeVisualizer : MonoBehaviour
{
    public GameObject sampleCube;
    GameObject[] sampleCubesArray = new GameObject[512];
    GameObject[] innerCubes = new GameObject[512];
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 512; i++){
            GameObject sampleCubeInstance = (GameObject) Instantiate (sampleCube);
            sampleCubeInstance.transform.position = this.transform.position;
            sampleCubeInstance.transform.parent = this.transform;
            sampleCubeInstance.name = "Cube #" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            sampleCubeInstance.transform.position = Vector3.forward * 100;
            sampleCubesArray[i] = sampleCubeInstance; // reference to the sample cube instance
        }

        // for(int i = 0; i < 512; i++){
        //     GameObject sampleCubeInstance = (GameObject) Instantiate (sampleCube);
        //     sampleCubeInstance.transform.position = this.transform.position;
        //     sampleCubeInstance.transform.parent = this.transform;
        //     sampleCubeInstance.name = "Cube #" + i;
        //     this.transform.eulerAngles = new Vector3(0, 0.703125f * i, 0);
        //     sampleCubeInstance.transform.position = Vector3.forward * 50;
        //     innerCubes[i] = sampleCubeInstance; // reference to the sample cube instance
        // }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 512; i++){
            if(sampleCubesArray != null){
                // sampleCubesArray[i].GetComponent<Renderer>().material.color = Random.ColorHSV(); //<-- Epilepsy warning (serious)

                sampleCubesArray[i].transform.localScale = new Vector3(1, AudioVis.samples[i] * scale + 2, 1);
                // innerCubes[i].transform.localScale = new Vector3(1, AudioVis.samples[i] * scale/2 + 2, 1);
            }
        }
    }
}
