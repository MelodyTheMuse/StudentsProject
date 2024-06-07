using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FixPictureToHangingPoint : MonoBehaviour
{
     FixedJoint fixedJoint;
    GameObject globalCol = null;
    [SerializeField] int LayerNumber= 0;
    int interactionLayer = 6;
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.layer = interactionLayer;
    }

    // Update is called once per frame
    void Update()
    {
        
   
  
    }
    private void OnCollisionEnter(Collision collision)
    {
        //This if checks if the object the picture collided with is a hanging point  and is the one it is connected t0.
        if(collision.transform.tag == "HaningPoint" && collision.gameObject.GetComponent<WhichPicture>().picture == this.gameObject &&collision.gameObject.layer != LayerNumber)
        {
            //It will make sure that the picture gets a fixed joint, which I use to make the picture float at the hanging points location.    
            globalCol = collision.gameObject;
            fixedJoint =this.gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = collision.rigidbody;
            
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "HaningPoint" && collision.gameObject.GetComponent<WhichPicture>().picture == this.gameObject && collision.gameObject.layer != LayerNumber)
        {
            globalCol.GetComponent<SwitchCaseHandler>().passed = true;
            globalCol.GetComponent<SwitchCaseHandler>().activeLevel = 3;
            //this.GetComponent<XRGrabInteractable>().enabled = false;



        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //When the picture exits the collision it will remove the fixed joint so that the picutre is able to move freely again.
        if (collision.gameObject.tag == "HaningPoint")
        {
           
            fixedJoint = this.gameObject.GetComponent<FixedJoint>();
            this.GetComponent<XRGrabInteractable>().enabled = true;
            Destroy(fixedJoint);
        }
    }
     IEnumerator SetNonInteractive()
    {
     
        yield return new WaitForSeconds(3f);
       


    }

    


}
