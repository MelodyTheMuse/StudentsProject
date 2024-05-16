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
        if(collision.transform.tag == "HaningPoint" && collision.gameObject.GetComponent<WhichPicture>().picture == this.gameObject)
        {
            
            fixedJoint =this.gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = collision.rigidbody;
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
