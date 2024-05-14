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
        if(collision.transform.tag == "HaningPoint")
        {
            fixedJoint =this.gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = collision.rigidbody;
        }
    }
}
