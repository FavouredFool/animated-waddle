using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollManager : MonoBehaviour
{
    [SerializeField]
    private PlayerDiceScript _playerDiceBlueprint;

    [SerializeField]
    private Transform _playerDiceSpawnPosition;

    [SerializeField]
    private CameraScript _cameraScript;


    public enum GameState { EGO, ROLLING }

    public GameState gameState = GameState.EGO;

    // flag
    bool _canThrowFlag = true;

    int _latestResult = -1;

    PlayerDiceScript _playerDice = null;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            

            if (_canThrowFlag)
            {
                gameState = GameState.ROLLING;
                
                RollPlayerDice(40f, 0.2f);
            }
            
        }

        if (gameState == GameState.ROLLING)
        {
            

            int result = _playerDice.GetResult();
            if (result > 0)
            {
                Debug.Log("result: " + result);
                _latestResult = result;
                gameState = GameState.EGO;
            }
        }

        
        
    }

    private void RollPlayerDice(float rollStrength, float rollHeight)
    {
        _playerDice = Instantiate(_playerDiceBlueprint, _playerDiceSpawnPosition.position, _playerDiceSpawnPosition.rotation);
        _playerDice.Init(_cameraScript.GetComponent<Camera>());


        _cameraScript.SetFocus(_playerDice.transform);

        _canThrowFlag = false;

        _playerDice.GetRigidbody().isKinematic = false;

        float randomOffset = Random.Range(-0.5f, 0.5f);

        Vector3 explosionPosition = _playerDice.transform.position - new Vector3(1, 1, randomOffset);

        _playerDice.GetRigidbody().AddExplosionForce(rollStrength, explosionPosition, 0f, rollStrength * rollHeight, ForceMode.Impulse);
    }
}
