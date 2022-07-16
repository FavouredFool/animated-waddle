using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManagerScript : MonoBehaviour
{

    [SerializeField]
    DeathTimeManager _deathTimeManager;

    void Start()
    {
        StartCoroutine("InitialDialog");
    }

    IEnumerator InitialDialog()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Hey. It's time to roll dice.");
    }
}
