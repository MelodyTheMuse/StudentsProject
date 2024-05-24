using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SwitchCaseHandler : MonoBehaviour
{
    [SerializeField] public int activeLevel = 1;
    [SerializeField]  bool interactable = false;
    [SerializeField] public bool passed = false;
    [SerializeField] GameObject nextHanger;
    int activeLayer = 3;
    int inactiveLayer = 9;
    int passedLayer = 10;
    [SerializeField] TextMeshPro hintText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActiveLevel();
    }

    void ActiveLevel()
    {
        switch (activeLevel)
        {
            case 3: print("Active Level set to passed");
                if (interactable && passed)
                {
                    
                        this.gameObject.layer = passedLayer;
                        this.GetComponent<WhichPicture>().picture.layer = passedLayer;
                        this.interactable = false;
                    if (nextHanger != null) { nextHanger.GetComponent<SwitchCaseHandler>().activeLevel = 2; }
                    
                    
                }
                break;
            case 2: print("ActiveLevel set to active");
                if (!interactable && !passed)
                {
                    this.gameObject.layer = activeLayer;
                    hintText.text = this.GetComponent<WhichPicture>().picture.GetComponent<Hint>().hint;
                    interactable = true;
                }
                break;
            case 1: print("ActiveLevel set to inactive");
                if (!interactable)
                {
                    this.gameObject.layer = inactiveLayer;
                }
                break;
            default:print("Incorrect ActiveLevel");
                break;
        }

    }
}
