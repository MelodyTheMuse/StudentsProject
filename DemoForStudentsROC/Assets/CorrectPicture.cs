using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CorrectPicture : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> pictures = new List<GameObject>();
    [SerializeField] List<GameObject> hangers = new List<GameObject>();
    WhichPicture p;
    List<int> hadhanger = new List<int>();
    List<int> hadpicture = new List<int>();
    //int randomhanger;
    //int randompicture;
    int i = 0;
    int max = 0;
    int randompicture = 0;


    void Start()
    {
        Debug.Log("Start method entered");
        if (hangers == null || hangers.Count == 0)
        {
            Debug.LogWarning("Hangers list is empty or null.");
            return;
        }
        foreach (var item in hangers)
        {
            Debug.Log("Foreach");
            if (Rando())
            {
                GameObject picture = pictures[randompicture];


                item.GetComponent<WhichPicture>().picture = picture;
                hadpicture.Add(randompicture);
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void Randomizer()
    //{
    //    Debug.Log("RandomStart");
    //    int randomhanger;
    //    int randompicture;
    //    int attempts = 0;
    //    int maxAttempts = 100;  // Limit the number of attempts to prevent infinite loop

    //    while (attempts < maxAttempts)
    //    {
    //        randomhanger = Random.Range(0, 3);
    //        randompicture = Random.Range(0, 3);

    //        if (!hadpicture.Contains(randompicture) && !hadhanger.Contains(randomhanger))
    //        {
    //            Debug.Log("Entered IF");
    //            GameObject picture = this.pictures[randompicture];
    //            GameObject hanger = this.hanger[randomhanger];

    //            hanger.GetComponent<WhichPicture>().picture = picture;
    //            hadhanger.Add(randomhanger);
    //            hadpicture.Add(randompicture);
    //            return;  // Exit the method once a valid combination is found
    //        }

    //        attempts++;
    //        Debug.Log("Looping");
    //    }

    //    Debug.Log("STOP YOU HAVE VIOLATED THE LAW");
    //}

    void StartRandom()
    {
        Debug.Log("We started");
        int maxPictures = pictures.Count;
        int maxHangers = hangers.Count;

        if (maxPictures < maxHangers)
        {
            Debug.LogError("Not enough pictures to fill all hangers.");
            return;
        }

        while (i < maxHangers)
        {
            Debug.Log("Inside the while");
            Randomizer();
            i++;
        }
    }

    void Randomizer()
    {
        Debug.Log("RandomStart");
    


    }
    bool Rando()
    {
        randompicture = Random.Range(0, pictures.Count);
        if (!hadpicture.Contains(randompicture)) 
        {

            return true;
        }
        else if(Rando())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

    //void StartRandom()
    //{
    //    Debug.Log("We started");
    //    int max = pictures.Count();
    //    while (i < 4)
    //    {
    //        Debug.Log("Inside the while");
    //        Randomizer();
    //        i++;
    //    }
    //}


