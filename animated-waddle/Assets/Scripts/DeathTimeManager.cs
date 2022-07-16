using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimeManager : MonoBehaviour
{
    int _deathTime = 3;

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
        _deathTime += 1;
    }

    public void DecreaseDeathTime()
    {
        if (_deathTime > 1)
        {
            _deathTime -= 1;
        }
        
    }
}
