using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Sceneswitching : MonoBehaviour
{
    public SceneList sceneList;
    SceneAsset scene = null;
    bool gotIt = false;
    WaitForSeconds wfs = new WaitForSeconds(3f);
    // Start is called before the first frame update
    void Start()
    {
        
        
    }



   

    private IEnumerator Wait()
    {
        while (gotIt == true) {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(scene.name);
            yield return null;
        }
        
    }

}

