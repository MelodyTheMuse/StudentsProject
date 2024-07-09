using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Scenelist", menuName = "ScriptableObjects/SceneList", order = 2)]
public class SceneList : ScriptableObject
{

    public List<SceneAsset> scenesToUse;
    private List<SceneAsset> toSchuffle;
}
    
   
    
       
    

    
