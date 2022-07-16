using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    [SerializeField]
    DeathTimeManager _deathTimeManager;

    [SerializeField]
    Transform _armPivot;

    [SerializeField]
    float _clockSpeed;

    int _deathStage;

    float _activeArmAngle;
    float _desiredArmAngle;
    
    float _maxDeathStage = 16f;

    private void Start()
    {
        _deathStage = _deathTimeManager.GetDeathTime();
        _activeArmAngle = _deathStage / _maxDeathStage * 360f;
        _desiredArmAngle = _deathStage / _maxDeathStage * 360f;
    }

    private void Update()
    {
        _deathStage = _deathTimeManager.GetDeathTime();

        if (Input.GetKeyDown(KeyCode.E))
        {
            _deathStage++;
        } else if (Input.GetKeyDown(KeyCode.W))
        {
            _deathStage--;
        }

        _desiredArmAngle = _deathStage / _maxDeathStage * 360f;
        _activeArmAngle = Mathf.MoveTowardsAngle(_activeArmAngle, _desiredArmAngle, _clockSpeed);


        _armPivot.rotation = Quaternion.Euler(new Vector3(-_activeArmAngle, 0, 0));

        
    }
}
