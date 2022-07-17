using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollManager : MonoBehaviour
{
    [SerializeField]
    private DeathTimeManager _deathTimeManager;

    [SerializeField]
    private PlayerDiceScript _playerDiceBlueprint;

    [SerializeField]
    private Transform _playerDiceSpawnPosition;

    [SerializeField]
    private CameraScript _cameraScript;

    [SerializeField]
    private DiceStackScript _diceStack;


    public enum GameState { EGO, ROLLING }

    public GameState gameState = GameState.EGO;

    // flag
    bool _canThrowFlag;

    int _latestResult = -1;

    PlayerDiceScript _playerDice = null;

    AudioManager _audioManager;


    private void Awake()
    {
        _canThrowFlag = false;
    }

    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_canThrowFlag)
            {
                gameState = GameState.ROLLING;
                _diceStack.RemoveDice();

                float strength = Random.Range(35f, 50f);
                float height = Random.Range(0.1f, 0.35f);
                float randomOffset = Random.Range(-1f, 1f);

                Debug.Log("strength: " + strength + " height: " + height + " randomOffset: " + randomOffset);

                RollPlayerDice(strength, height, randomOffset);
            }
            
        }

        if (gameState == GameState.ROLLING)
        {
            int result = _playerDice.GetResult();
            if (result > 0)
            {

                _latestResult = result;
                gameState = GameState.EGO;
                _canThrowFlag = true;

                if (result == 2)
                {
                    _audioManager.Play("heartbeat");
                    _deathTimeManager.DecreaseDeathTime();
                }

            }
        }
    }


    private void RollPlayerDice(float rollStrength, float rollHeight, float randomOffset)
    {
        _playerDice = Instantiate(_playerDiceBlueprint, _playerDiceSpawnPosition.position, _playerDiceSpawnPosition.rotation);
        _playerDice.Init(_cameraScript.GetComponent<Camera>());


        _cameraScript.SetFocus(_playerDice.transform);

        _canThrowFlag = false;

        _playerDice.GetRigidbody().isKinematic = false;

        Vector3 explosionPosition = _playerDice.transform.position - new Vector3(1, 1, randomOffset);

        _playerDice.GetRigidbody().AddExplosionForce(rollStrength, explosionPosition, 0f, rollStrength * rollHeight, ForceMode.Impulse);
    }

    public bool GetCanThrowFlag()
    {
        return _canThrowFlag;
    }

    public void SetCanThrowFlag(bool canThrow)
    {
        _canThrowFlag = canThrow;
    }

    public int GetLatestResult()
    {
        return _latestResult;
    }

    public void ResetResult()
    {
        _latestResult = -1;
    }
}


