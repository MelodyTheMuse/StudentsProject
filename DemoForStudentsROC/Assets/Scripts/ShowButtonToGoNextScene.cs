using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtonToGoNextScene : MonoBehaviour
{

    [SerializeField] GameObject Button;
    [SerializeField] List<bool>puzzlebools = new List<bool>();
    [SerializeField] List<GameObject> puzzles = new List<GameObject>();
    public static ShowButtonToGoNextScene Instance;
    // Start is called before the first frame update
    void Start()
    {
        int value = puzzles.Count;
        puzzlebools.Clear ();
        for (int i = 0; i < value; i++)
        {
            puzzlebools.Add (false);
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        if (CheckBools())
        {
            Button.SetActive (true);
        }
    }
    public  void EnablePuzzleBool(int index) => puzzlebools[index] = true;
    public  int FindIndex(GameObject NameOfPuzzle)
    {
        for(int i = 0; i >= puzzles.Count; i++)
        {
            if (puzzles[i] == NameOfPuzzle)
            {
                return i;
            }
        }
        return -1;
    }

    private bool CheckBools()
    {
        int I = 0;
        foreach(bool puzzle in puzzlebools) 
        {

            if (I == puzzlebools.Count)
            {
                return true;
            }
            if(puzzle == true)
            {
                I++;
            }
           
        }
       
        return false;
    }
    
      
    
}
