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
    int activeLayer = 6;
    int inactiveLayer = 9;
    int passedLayer = 3;
    [SerializeField] TextMeshPro hintText;
    [SerializeField] GameObject PuzzleObj;
    int BtnIndexList =0;
    [SerializeField] GameObject GameController;
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
    { // This method is the switch case, it will make sure that when the hanger is set to an active level, or when it passes, a set of instructions is run. These instructions can be setting the interaction layer to a simple bool from false to true. 
        switch (activeLevel)
        {
            case 3: ;
                if (interactable && passed)
                {
                    //When the script gets into this case it means that the puzzle for this hanger was solved.It set's the layers to the pass layer, and makes it so that the next hanger is set to active.
                    this.gameObject.layer = passedLayer;
                    this.GetComponent<WhichPicture>().picture.layer = passedLayer;
                    this.interactable = false;
                    if (nextHanger != null) { nextHanger.GetComponent<SwitchCaseHandler>().activeLevel = 2; }
                    else
                    {
                        if (GameController.GetComponent<ShowButtonToGoNextScene>().DictionarySetBoolToTrueForPuzzleObject(PuzzleObj))
                        {
                            //add something to debug or a soundfile so the player knows the scene switched.
                        }
                    }
                    
                    
                }
                break;
            case 2: ;
                if (!interactable && !passed)
                {
                    //this case make sure that the handler is active, meaning it is able to interacted with and solved. 
                    this.gameObject.layer = activeLayer;
                    hintText.text = this.GetComponent<WhichPicture>().picture.GetComponent<Hint>().hint;
                    interactable = true;
                }
                break;
            case 1: ;
                if (!interactable)
                {
                    // this makes sure that the hanger is set inactive when it has not yet been it's turn.
                    this.gameObject.layer = inactiveLayer;
                }
                break;
            default:;
                break;
        }

        

    }
  
}
