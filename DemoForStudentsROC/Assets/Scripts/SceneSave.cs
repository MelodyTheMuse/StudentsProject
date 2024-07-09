using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        ListKeeper.Instance.AddSceneToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
