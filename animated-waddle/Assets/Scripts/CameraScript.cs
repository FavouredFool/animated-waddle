using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Transform _egoTransform;

    [SerializeField]
    RollManager _rollManager;

    [SerializeField, Range(1f, 20f)]
    float _distance = 5f;

    [SerializeField, Range(0f, 1f)]
    float _focusCentering = 0.5f;

    Transform _focus;
    Camera _regularCamera;
    Vector3 _focusPoint;
    Vector3 _previousFocusPoint;
    float _focusRadius;

    void Start()
    {
        _regularCamera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (_rollManager.gameState == RollManager.GameState.EGO)
        {
            transform.SetPositionAndRotation(_egoTransform.position, _egoTransform.rotation);
        }
        else if (_rollManager.gameState == RollManager.GameState.ROLLING)
        {
            UpdateFocusPoint();

            Vector2 orbitAngles = new Vector2(55f, 90f);
            Quaternion lookRotation = Quaternion.Euler(orbitAngles);

            Vector3 lookDirection = lookRotation * Vector3.forward;
            Vector3 lookPosition = _focusPoint - lookDirection * _distance;

            transform.SetPositionAndRotation(lookPosition, lookRotation);
        }
        
    }

    public void SetFocus(Transform focus)
    {
        _focus = focus;
        _focusPoint = focus.position;
    }


    void UpdateFocusPoint()
    {
        if (_focus == null)
        {
            return;
        }

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
