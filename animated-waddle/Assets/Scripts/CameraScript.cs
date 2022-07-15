using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Transform _focus = default;

    [SerializeField, Range(1f, 20f)]
    float _distance = 5f;

    [SerializeField, Range(0f, 1f)]
    float _focusCentering = 0.5f;


    Camera _regularCamera;
    Vector3 _focusPoint;
    Vector3 _previousFocusPoint;
    float _focusRadius;

    void Start()
    {
        _regularCamera = GetComponent<Camera>();
        _focusPoint = _focus.position;
    }

    void LateUpdate()
    {
        UpdateFocusPoint();

        Vector2 orbitAngles = new Vector2(45f, 45f);
        Quaternion lookRotation = Quaternion.Euler(orbitAngles);

        Vector3 lookDirection = lookRotation * Vector3.forward;
        Vector3 lookPosition = _focusPoint - lookDirection * _distance;


        transform.SetPositionAndRotation(lookPosition, lookRotation);
    }


    void UpdateFocusPoint()
    {
        _previousFocusPoint = _focusPoint;
        Vector3 targetPoint = _focus.position;
        if (_focusRadius > 0f)
        {
            float distance = Vector3.Distance(targetPoint, _focusPoint);
            float t = 1f;

            if (distance > 0.01f && _focusCentering > 0f)
            {
                t = Mathf.Pow(1f - _focusCentering, Time.unscaledDeltaTime);
            }
            if (distance > _focusRadius)
            {
                t = Mathf.Min(t, _focusRadius / distance);
            }

            _focusPoint = Vector3.Lerp(targetPoint, _focusPoint, t);
        }
        else
        {
            _focusPoint = targetPoint;
        }
    }
}
