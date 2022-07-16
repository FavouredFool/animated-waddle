using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManagerScript : MonoBehaviour
{

    [SerializeField]
    DeathTimeManager _deathTimeManager;

    [SerializeField]
    DialogCanvasScript _dialogCanvas;

    void Start()
    {
        StartCoroutine("InitialDialog");
    }

    IEnumerator InitialDialog()
    {
        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(2);
        _dialogCanvas.SetGMText("Hello. It is time to roll dice.");
        yield return new WaitForSeconds(4);
        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);
        _dialogCanvas.SetAnswerOptions("Where am I?", "Who are you?");
        yield return new WaitForSeconds(4);
        _dialogCanvas.RemoveAnswerOptions();
    }
}
