using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimeManager : MonoBehaviour
{

    [SerializeField]
    DialogManagerScript _dialogManager;

    [SerializeField]
    GameLogic _gameLogic;

    int _deathTime = 2;

    bool _initialDialogOver = false;

    bool _firstCongratzhappend = false;
    bool _secondCongratzhappend = false;

    bool stage1happend = false;
    bool stage2happend = false;
    bool stage3happend = false;
    bool stage4happend = false;
    bool stage5happend = false;

    public void Update()
    {
        

        if (_deathTime >= 12 && !stage1happend)
        {
            stage1happend = true;
            _dialogManager.StartStage1Dialog();
        }

        if (_deathTime >= 18 && !stage2happend)
        {
            stage2happend = true;
            _dialogManager.StartStage2Dialog();
        }

        if (_deathTime >= 24 && !stage3happend)
        {
            stage3happend = true;
            _dialogManager.StartStage3Dialog();
        }

        if (_deathTime >= 26 && !stage4happend)
        {
            stage4happend = true;
            _dialogManager.StartStage4Dialog();
        }

        if (_deathTime >= 32 && !stage5happend)
        {
            _deathTime = 32;
            stage5happend = true;
            StartFinale();
            
        }
    }

    public void RolledTwo()
    {
        if (_deathTime < 24)
        {
            if (_initialDialogOver && !stage1happend)
            {
                if (!_firstCongratzhappend)
                {
                    _firstCongratzhappend = true;
                    _dialogManager.StartCongratz1Dialog();
                }
                else if (!_secondCongratzhappend)
                {
                    _secondCongratzhappend = true;
                    _dialogManager.StartCongratz2Dialog();
                }

            }
        }
    }

    public void InitialDialogOver()
    {
        _initialDialogOver = true;
    }

    public void StartFinale()
    {
        _gameLogic.StartEnding();
        _dialogManager.StartFinalDialog();
    }

    public int GetDeathTime()
    {
        return _deathTime;
    }

    public void SetDeathTime(int deathTime)
    {
        _deathTime = deathTime;
    }

    public void IncreaseDeathTime()
    {
        _deathTime += 2;
    }

    public void DecreaseDeathTime()
    {
        if (_deathTime > 1)
        {
            _deathTime -= 1;
        }

        RolledTwo();
        
    }
}
