using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;

public class ButtonSctipt : MonoBehaviour
{
    [SerializeField] private float threshold = .1f;
    [SerializeField] private float deadZone = 0.025f;
    [SerializeField] bool _NextSceneBool = false;
    [SerializeField] GameObject GeneralAction;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;
    public  UnityEvent  onReleased, onPressed;
    UnityAction _Nextscene;
    
    // Start is called before the first frame update
    void Start()
    {
        
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();

    }

    // Update is called once per frame
    void Update()
    {
        if( !_isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if( _isPressed && GetValue() - threshold <=0) 
        {
            Release();
        }
    }

    public void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");

    }
    private void Release()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if(Math.Abs(value) < deadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, deadZone - 1f, 1f);
    }

    private void EventDifference()
    {
        if(_NextSceneBool)
        {
            _Nextscene = GameObject.FindWithTag("SceneManager").GetComponent<ListKeeper>().NextScene;
            onPressed.AddListener(_Nextscene);
        }
        
        
    }
}
