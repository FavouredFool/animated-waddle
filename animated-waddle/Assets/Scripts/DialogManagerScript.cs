using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManagerScript : MonoBehaviour
{
    [SerializeField]
    RollManager _rollManager;

    [SerializeField]
    DeathTimeManager _deathTimeManager;

    [SerializeField]
    DialogCanvasScript _dialogCanvas;

    int answer;
    int result;

    void Start()
    {
        StartCoroutine("InitialDialog");
    }

    IEnumerator InitialDialog()
    {
        _dialogCanvas.RemoveAnswerOptions();


        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(2);

        _dialogCanvas.SetGMText("Hello.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _dialogCanvas.SetGMText("It is time to roll dice.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _dialogCanvas.SetAnswerOptions("Where am I?", "Who are you?");

        // So lange warten bis Answer zur�ck kommt
        while (_dialogCanvas.GetAnswer() == -1)
        {
            yield return new WaitForSeconds(0.1f);
        }

        answer = _dialogCanvas.GetAnswer();

        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.ResetAnswer();

        yield return new WaitForSeconds(1);

        if (answer == 0)
        {
            _dialogCanvas.SetGMText("You are looking inside yourself. You lost the ability to look anywhere else.");
        }
        else if (answer == 1)
        {
            _dialogCanvas.SetGMText("I am part of you. You were never meant to see me.");
        }

        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _dialogCanvas.SetGMText("You have to roll ones now. Many of them.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _dialogCanvas.SetGMText("You have some control over the dice. Use it to roll ones.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _dialogCanvas.SetGMText("You can find the dice on the table.");
        yield return new WaitForSeconds(4);
        _dialogCanvas.SetGMText("");


        // Unlock dice roll option
        _rollManager.SetCanThrowFlag(true);


        // So lange warten bis Answer zur�ck kommt
        while (_rollManager.GetLatestResult() == -1)
        {
            yield return new WaitForSeconds(0.1f);
        }

        _rollManager.SetCanThrowFlag(false);
        result = _rollManager.GetLatestResult();
        yield return new WaitForSeconds(1);

        if (result != 1)
        {
            _dialogCanvas.SetGMText("You did not roll a one. That is bad.");
        }
        else
        {
            _dialogCanvas.SetGMText("You rolled a one. That is good.");
        }

        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _dialogCanvas.SetGMText("Do you see this clock above us?");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _dialogCanvas.SetGMText("Everytime the pendulum passes me, we lose time.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _dialogCanvas.SetGMText("Everytime you roll a one, we gain time.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _dialogCanvas.SetGMText("It is vital, that we never hear the midnight bell.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _dialogCanvas.SetAnswerOptions("Why? What is going on?", "Then we should stop talking at once.");

        // So lange warten bis Answer zur�ck kommt
        while (_dialogCanvas.GetAnswer() == -1)
        {
            yield return new WaitForSeconds(0.1f);
        }

        answer = _dialogCanvas.GetAnswer();

        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.ResetAnswer();

        yield return new WaitForSeconds(1);

        if (answer == 0)
        {
            _dialogCanvas.SetGMText("It was an accident. A bad one. We will not make it. We can try anyway.");
            yield return new WaitForSeconds(4);

            _dialogCanvas.SetGMText("");
            yield return new WaitForSeconds(1);

            _dialogCanvas.SetGMText("Now. Roll.");
        }
        else if (answer == 1)
        {
            _dialogCanvas.SetGMText("Correct.");
        }

        _rollManager.SetCanThrowFlag(true);
        
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");

    }

}
