using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPictureToHangingPoint : MonoBehaviour
{
    [SerializeField] Rigidbody hangingPoint;
    [SerializeField] FixedJoint fixedJoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
   
  
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "HaningPoint" && collision.gameObject.GetComponent<WhichPicture>().picture == this.gameObject &&collision.gameObject.layer == this.gameObject.layer)
        {
            
            fixedJoint =this.gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = collision.rigidbody;
            collision.gameObject.GetComponent<SwitchCaseHandler>().passed = true;
            collision.gameObject.GetComponent<SwitchCaseHandler>().activeLevel = 3;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "HaningPoint")
        {
            fixedJoint = this.gameObject.GetComponent<FixedJoint>();
            Destroy(fixedJoint);
            Debug.Log("I AM OUTTA HERE");
        }
    }
}
