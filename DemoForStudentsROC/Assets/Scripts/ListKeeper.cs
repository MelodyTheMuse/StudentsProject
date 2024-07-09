 using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListKeeper : MonoBehaviour
{
    public static ListKeeper Instance;
    public List<SceneAsset> scenes;
    public List<SceneAsset> Done;
    public SceneList sceneList;
    private Scene scene;
    private SceneAsset sceneAsset;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        UpdateList();
    }

    private void Start()
    {
        
    }


    public void AddSceneToList()
    {
        scene = SceneManager.GetActiveScene();
        foreach (SceneAsset scen in sceneList.scenesToUse)
        {
            if(scen.name == scene.name)
            {
                Done.Add(scen);
            }
        }
    }

    public void NextScene()
    {

        Debug.Log("Loading Next scene");

        if (scenes.Count != 0){ 
        int index = Random.Range(0, scenes.Count);
        sceneAsset = scenes[index];
        scenes.RemoveAt(index);
        SceneManager.LoadScene(sceneAsset.name);
        }
        else
        {
            Done.Clear();
            UpdateList();
            NextScene();

        }

    }

    private void UpdateList()
    {
        IListExtensions.Shuffle(sceneList.scenesToUse);
        foreach(SceneAsset scene in sceneList.scenesToUse)
        {
            scenes.Add(scene);
        }
    }

}
