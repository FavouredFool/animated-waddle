using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiceScript : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField, Range(0f, 10f)]
    private float _rotationStrength;

    [SerializeField]
    private float _timeUntilResult;

    // Properties
    bool OnGround => _isOnGroundFlag;


    private int _result = -1;
    private float _lastContactTime = float.PositiveInfinity;

    private Vector3 _contactNormal;

    private bool _isOnGroundFlag = false;
    private Rigidbody _rb;

    private Vector2 _playerInput;


    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    private void Update()
    {
        if (!OnGround)
        {
            AirControls();
        }
        else
        {
            _playerInput.x = 0;
            _playerInput.y = 0;
        }

        if (Time.time - _lastContactTime > _timeUntilResult)
        {
            // Give Result
            _result = CalculateResult();

        }
    }

    private int CalculateResult()
    {
        Vector3 direction = Vector3.zero;
        float forward, back, right, left, up, down;

        forward = Vector3.Distance(_contactNormal, transform.forward);
        back = Vector3.Distance(_contactNormal, -transform.forward);
        right = Vector3.Distance(_contactNormal, transform.right);
        left = Vector3.Distance(_contactNormal, -transform.right);
        up = Vector3.Distance(_contactNormal, transform.up);
        down = Vector3.Distance(_contactNormal, -transform.up);

        float result = Mathf.Min(forward, back, right, left, up, down);

        if (result == forward)
        {
            direction = Vector3.forward;
        }
        else if (result == back)
        {
            direction = Vector3.back;
        }
        else if (result == right)
        {
            direction = Vector3.right;
        }
        else if (result == left)
        {
            direction = Vector3.left;
        }
        else if (result == up)
        {
            direction = Vector3.up;
        }
        else if (result == down)
        {
            direction = Vector3.down;
        }

        return DiceNumberFromDirection(direction);
    }

    private int DiceNumberFromDirection(Vector3 direction)
    {
        int number = -1;

        if (direction == Vector3.down)
        {
            number =  1;
        }
        else if (direction == Vector3.back)
        {
            number = 2;
        }
        else if (direction == Vector3.left)
        {
            number = 3;
        }
        else if (direction == Vector3.right)
        {
            number = 4;
        }
        else if (direction == Vector3.forward)
        {
            number = 5;
        }
        else if (direction == Vector3.up)
        {
            number = 6;
        }

        return number;

    }


    void FixedUpdate()
    {
        CalculateDiceRotation();
    }

    void CalculateDiceRotation()
    {
        // Add Torque relative to Camera Position (45°/45°)
        Vector3 rotationMovementY = -1 * _playerInput.x * _camera.transform.up;
        Vector3 rotationMovementX =  _playerInput.y * _camera.transform.right;

        Vector3 combined = rotationMovementX + rotationMovementY;
        combined.Normalize();

        Vector3 torque = combined * _rotationStrength;

        _rb.AddTorque(torque, ForceMode.Force);
    }


    void AirControls()
    {
        _playerInput.x = Input.GetAxis("Mouse X");
        _playerInput.y = Input.GetAxis("Mouse Y");

        _playerInput = Vector2.ClampMagnitude(_playerInput, 1f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        _isOnGroundFlag = true;
        _lastContactTime = Time.time;
        EvaluateCollision(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        _isOnGroundFlag = false;
        _lastContactTime = float.PositiveInfinity;
        EvaluateCollision(collision);
    }


    private void EvaluateCollision(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector3 normal = collision.GetContact(i).normal;
            _contactNormal += normal;
        }

        _contactNormal.Normalize();
    }


    public Rigidbody GetRigidbody()
    {
        return _rb;
    }

    public int GetResult()
    {
        return _result;
    }

}
