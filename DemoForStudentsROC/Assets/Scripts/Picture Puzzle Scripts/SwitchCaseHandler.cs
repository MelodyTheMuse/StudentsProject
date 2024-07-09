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
    [SerializeField] GameObject SBTGNS;
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
            case 3: print("Active Level set to passed");
                if (interactable && passed)
                {
                    //When the script gets into this case it means that the puzzle for this hanger was solved.It set's the layers to the pass layer, and makes it so that the next hanger is set to active.
                    this.gameObject.layer = passedLayer;
                    this.GetComponent<WhichPicture>().picture.layer = passedLayer;
                    this.interactable = false;
                    if (nextHanger != null) { nextHanger.GetComponent<SwitchCaseHandler>().activeLevel = 2; }
                    else
                    {
                        Debug.Log($"SBTGNS: {SBTGNS.name}");
                        Debug.Log($"PuzzleObj: {PuzzleObj.name}");
                        Debug.Log($"Component: {SBTGNS.GetComponent<ShowButtonToGoNextScene>().name}");
                        BtnIndexList = SBTGNS.GetComponent<ShowButtonToGoNextScene>().FindIndex(PuzzleObj.gameObject) -1;
                        SBTGNS.GetComponent<ShowButtonToGoNextScene>().EnablePuzzleBool(BtnIndexList);
                    }
                    
                    
                }
                break;
            case 2: print("ActiveLevel set to active");
                if (!interactable && !passed)
                {
                    //this case make sure that the handler is active, meaning it is able to interacted with and solved. 
                    this.gameObject.layer = activeLayer;
                    hintText.text = this.GetComponent<WhichPicture>().picture.GetComponent<Hint>().hint;
                    interactable = true;
                }
                break;
            case 1: print("ActiveLevel set to inactive");
                if (!interactable)
                {
                    // this makes sure that the hanger is set inactive when it has not yet been it's turn.
                    this.gameObject.layer = inactiveLayer;
                }
                break;
            default:print("Incorrect ActiveLevel");
                break;
        }

        

    }
  
}
