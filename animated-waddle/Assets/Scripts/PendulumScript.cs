using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumScript : MonoBehaviour
{
    [SerializeField]
    private Transform _pendulumHead;

    [SerializeField, Range(0f, 90f)]
    private float _maximumSwingAngle;

    [SerializeField]
    private float _speed;

    private float _currentSwingAngle = 0f;
    private float _t = 0;

    private int _sign = 1;


    private void Update()
    {
        _t = Mathf.Clamp01(_t + _speed * _sign * Time.deltaTime);

        if (_t == 1 || _t == 0)
        {
            _sign *= -1;
        }

        float angle = Mathf.SmoothStep(-_maximumSwingAngle, _maximumSwingAngle, _t);

        transform.rotation = Quaternion.Euler(angle, 0, 0);


        
    }
}
