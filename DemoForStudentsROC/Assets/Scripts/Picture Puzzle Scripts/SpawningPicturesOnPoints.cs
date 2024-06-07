using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPicturesOnPoints : MonoBehaviour
{
    [SerializeField] List<GameObject> Pictures = new List<GameObject>();
    [SerializeField] List<GameObject> SpawnPoints = new List<GameObject>();
    List<int> hadpicture = new List<int>();
    int randompicture = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SpawnPointsSTart");
        if (SpawnPoints == null || SpawnPoints.Count == 0)
        {
            Debug.LogWarning("SpawnPoints list is empty or null.");
            return;
        }
        foreach (var item in SpawnPoints)
        {
            Debug.Log("SpawnPoints Foreach");
            if (Rando())
            {
                GameObject picture = Pictures[randompicture];


                picture.transform.position = item.transform.position;
                hadpicture.Add(randompicture);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool Rando()
    {
        randompicture = Random.Range(0, Pictures.Count);
        if (!hadpicture.Contains(randompicture))
        {

            return true;
        }
        else if (Rando())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
