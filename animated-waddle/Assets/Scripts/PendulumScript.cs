using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumScript : MonoBehaviour
{
    [SerializeField]
    private PendulumHeadSound _pendulumHeadSound;

    [SerializeField]
    private DeathTimeManager _deathTimeManager;

    [SerializeField]
    private Transform _pendulumHead;

    [SerializeField, Range(0f, 90f)]
    private float _maximumSwingAngle;

    [SerializeField]
    private float _startSpeed;

    [SerializeField]
    private float _speedIncrease;

    private float _speed;

    private float _t = 0;

    private int _sign = 1;

    private bool _hasBonked = false;

    private bool _swinging = true;


    private void Awake()
    {
        _speed = _startSpeed;
    }

    private void Update()
    {
        if (!_swinging)
        {
            return;
        }

        _t = Mathf.Clamp01(_t + _speed * _sign * Time.deltaTime);

        if (_t == 1 || _t == 0)
        {
            _speed += _speedIncrease;
            _hasBonked = false;
            _sign *= -1;
        }

        float angle = Mathf.SmoothStep(-_maximumSwingAngle, _maximumSwingAngle, _t);

        transform.rotation = Quaternion.Euler(angle, 0, 0);

        if (_sign > 0)
        {
            if (_t >= 0.50f && !_hasBonked)
            {
                _deathTimeManager.IncreaseDeathTime();
                _hasBonked = true;
                
                if (_deathTimeManager.GetDeathTime() >= 32)
                {
                    _pendulumHeadSound.PlaySound("midnightGong");
                    _swinging = false;
                }
                else
                {
                    _pendulumHeadSound.PlaySound("gong");
                }
            }
        }
        else
        {
            if (_t <= 0.50f && !_hasBonked)
            {
                _deathTimeManager.IncreaseDeathTime();
                _hasBonked = true;
                

                if (_deathTimeManager.GetDeathTime() >= 32)
                {
                    FindObjectOfType<AudioManager>().StopPlaying("ClockTicking");
                    _pendulumHeadSound.PlaySound("midnightGong");
                    _swinging = false;
                }
                else
                {
                    _pendulumHeadSound.PlaySound("gong");
                }
            }
        }

        
    }

}
