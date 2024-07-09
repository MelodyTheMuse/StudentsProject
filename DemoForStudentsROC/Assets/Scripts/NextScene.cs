using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public bool picturePuzzleFinished = false;
    public bool allPuzzlesFinished; // to be used later when more puzzels are introduced
    [SerializeField] ListKeeper ss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (picturePuzzleFinished)
        {
            ListKeeper.Instance.NextScene();
        }
    }
}
