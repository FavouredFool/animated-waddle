using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Transform _egoTransform;

    [SerializeField]
    RollManager _rollManager;

    [SerializeField, Range(1f, 200f)]
    float _mouseSensitivity;

    [SerializeField, Range(1f, 20f)]
    float _distance = 5f;

    [SerializeField, Range(0f, 1f)]
    float _focusCentering = 0.5f;

    [SerializeField, Range(10f, 90f)]
    float _maxVerticalEgoRotation = 45f;

    [SerializeField, Range(10f, 90f)]
    float _maxHorizontalEgoRotation = 45f;

    Transform _focus;
    Camera _regularCamera;
    Vector3 _focusPoint;
    Vector3 _previousFocusPoint;
    float _focusRadius;

    Vector2 currentLook;

    void Start()
    {
        _regularCamera = GetComponent<Camera>();
        currentLook.y = 0;
        currentLook.x = 0;

    }

    void LateUpdate()
    {
        if (_rollManager.gameState == RollManager.GameState.EGO)
        {

            // i hope this doesnt fuck me
            if (Time.deltaTime > 0.1f)
            {
                return;
            }

            Vector2 playerInput;
            playerInput.x = Input.GetAxis("Mouse X");
            playerInput.y = Input.GetAxis("Mouse Y");

            //playerInput = Vector2.ClampMagnitude(playerInput, 1f);

            playerInput.x *= (_mouseSensitivity * Time.deltaTime);
            playerInput.y *= (_mouseSensitivity * Time.deltaTime);

            currentLook.x = Mathf.Clamp(currentLook.x += playerInput.x, -_maxHorizontalEgoRotation, _maxHorizontalEgoRotation);
            currentLook.y = Mathf.Clamp(currentLook.y += playerInput.y, -_maxVerticalEgoRotation, _maxVerticalEgoRotation);

            transform.localRotation = Quaternion.AngleAxis(currentLook.y, Vector3.forward) * Quaternion.AngleAxis(currentLook.x, Vector3.up) * _egoTransform.rotation;

            transform.position = _egoTransform.position;
            //transform.SetPositionAndRotation(_egoTransform.position, _egoTransform.rotation);
        }
        else if (_rollManager.gameState == RollManager.GameState.ROLLING)
        {
            // reset ego
            currentLook = new Vector2(0, 0);

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
