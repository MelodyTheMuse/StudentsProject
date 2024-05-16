using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class WhichPicture : MonoBehaviour
{
    [SerializeField] public GameObject picture;
    List<GameObject> gameObjects = new List<GameObject>();
    bool colourChanged = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!colourChanged && picture != null)
        {
            Material mat = picture.GetComponentInChildren<MeshRenderer>().material;
            mat.color = this.GetComponentInChildren<MeshRenderer>().material.color;
        }
    }
}
