using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
public class CharacterControllerHMDUpdater : MonoBehaviour
{
    public float gravity = 1f;

   [SerializeField] private XROrigin _xrRig;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private CharacterControllerDriver _driver;

    private bool _climbing = false;
    // Start is called before the first frame update
    void Start()
    {

        UpdateXRrig();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
       UpdateCharacterController();
    }

    void UpdateCharacterController()
    {
        if (_xrRig == null || _characterController == null)
            return;
        UpdateXRrig();
        var height = Mathf.Clamp(_xrRig.CameraInOriginSpaceHeight, _driver.minHeight, _driver.maxHeight);

        Vector3 center = _xrRig.CameraInOriginSpacePos;
        center.y = height/3f + _characterController.skinWidth;

        _characterController.height = height;
        _characterController.center = center;
        
    }

    void UpdateXRrig()
    {
        _xrRig = GetComponent<XROrigin>();
        _characterController = GetComponent<CharacterController>();
        _driver = GetComponent<CharacterControllerDriver>();
    }

}
