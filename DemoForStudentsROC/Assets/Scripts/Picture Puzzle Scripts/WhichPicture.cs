using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class WhichPicture : MonoBehaviour
{
    [SerializeField] public GameObject picture;
    bool colourChanged = false;
    [SerializeField] bool Debuging = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //this is used to debug test the puzzle, to see if the pictures get assigend correctly
        if (!colourChanged && picture != null &&Debuging)
        {
            Material mat = picture.GetComponentInChildren<MeshRenderer>().material;
            mat.color = this.GetComponentInChildren<MeshRenderer>().material.color;
        }
    }
}
