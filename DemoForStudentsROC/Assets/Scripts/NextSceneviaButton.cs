using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;

public class NextSceneviaButton : MonoBehaviour
{
    GameObject _SceneManager;
    bool thereISNow = false;
    [SerializeField] ButtonSctipt buttonSctipt; 

    

    // Start is called before the first frame update
    void Start()
    {
       
        if (buttonSctipt != null) {

            buttonSctipt.onPressed.AddListener(Pressing);
        }
        else
        {
            Debug.Log("buttonscript null");
        }
    }

    // Update is called once per frame
    void Update()
    {if (!thereISNow)
        {
            if (_SceneManager == null)
            {
                if (GameObject.FindWithTag("SceneManager"))
                {
                    _SceneManager = GameObject.FindWithTag("SceneManager");
                    thereISNow = true;
                }
                else
                {
                    Debug.Log("No SceneManager");
                }
            }
            else
            {
                Debug.Log("SceneManger null");
            }
        }
    }

    private void OnEnable()
    {
       
    }

    public void Pressing()
    {
        _SceneManager.GetComponent<ListKeeper>().NextScene();
    }
}
