using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ShowButtonToGoNextScene : MonoBehaviour
{

    [SerializeField] GameObject Button;
    Dictionary<GameObject, bool> Puzzles = new Dictionary<GameObject, bool>();
    [SerializeField] List<GameObject> PuzzleObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        Puzzles.Clear();
        FillDictionary();

    }
   
    // Update is called once per frame
    void Update()
    {
        if (CheckBools())
        {
            Button.SetActive (true);
        }
    }
  
    public bool DictionarySetBoolToTrueForPuzzleObject(GameObject puzzle)
    {
        foreach (GameObject obj in Puzzles.Keys)
        {
            if (obj == puzzle)
            {
                Puzzles[obj] = true;
                return true;
            }
        }
        return false;
    }
    private bool CheckBools()
    {
      int i = 0;
        foreach (GameObject obj in Puzzles.Keys)
        {
 
         if (Puzzles[obj] == true)
         {
            i++;
         }
        }
        if (i == Puzzles.Count)
        {
            return true;
        }

        return false;
       
    }

    private void FillDictionary()
    {
        foreach (var k in PuzzleObjects) 
        { 
            Puzzles.Add(k, false);
        
        }
    }
    
      
    
}
