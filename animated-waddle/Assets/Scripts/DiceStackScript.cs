using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceStackScript : MonoBehaviour
{
    public List<GameObject> _diceList;

    public void RemoveDice()
    {
        GameObject dice = null;
        if (_diceList.Count > 0)
        {
            dice = _diceList[_diceList.Count - 1];
            _diceList.RemoveAt(_diceList.Count - 1);
            
        }
        else
        {
            dice = transform.GetChild(0).gameObject;
        }

        if (dice != null)
        {
            Destroy(dice);
        }
        

    }
}
