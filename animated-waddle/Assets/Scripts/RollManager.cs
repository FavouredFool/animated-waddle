using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollManager : MonoBehaviour
{
    [SerializeField]
    private PlayerDiceScript _playerDice;

    // flag
    bool _canThrowFlag = true;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_canThrowFlag)
            {
                RollPlayerDice(30f, 0.4f);
            }
            
        }

        int result = _playerDice.GetResult();
        if (result > 0)
        {
            Debug.Log("result: " + result);
        }
    }

    private void RollPlayerDice(float rollStrength, float rollHeight)
    {
        _canThrowFlag = false;

        _playerDice.GetRigidbody().isKinematic = false;

        float randomOffset = Random.Range(0f, 0.9f);
        Vector3 explosionPosition = _playerDice.transform.position - new Vector3(0.1f + randomOffset, 1, 0.1f + (0.9f-randomOffset));

        _playerDice.GetRigidbody().AddExplosionForce(rollStrength, explosionPosition, 0f, rollStrength * rollHeight, ForceMode.Impulse);
    }
}
