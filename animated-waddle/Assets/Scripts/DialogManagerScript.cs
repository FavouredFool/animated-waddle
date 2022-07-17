using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManagerScript : MonoBehaviour
{
    [SerializeField]
    GameLogic _gameLogic;

    [SerializeField]
    RollManager _rollManager;

    [SerializeField]
    DeathTimeManager _deathTimeManager;

    [SerializeField]
    DialogCanvasScript _dialogCanvas;

    [SerializeField]
    float _maxWaitTime = 10;

    int answer;
    int result;

    AudioManager _manager;

    float _startTime;

    void Start()
    {
        _manager = FindObjectOfType<AudioManager>();
        StartCoroutine("InitialDialog");
    }

    public void StartStage1Dialog()
    {
        StopAllDialog();

        StartCoroutine("Stage1Dialog");
    }

    public void StartStage2Dialog()
    {
        StopAllDialog();
        StartCoroutine("Stage2Dialog");
    }

    public void StartStage3Dialog()
    {
        StopAllDialog();
        StartCoroutine("Stage3Dialog");
    }

    public void StartStage4Dialog()
    {
        StopAllDialog();
        StartCoroutine("Stage4Dialog");
    }

    public void StartFinalDialog()
    {
        StopAllDialog();
        StartCoroutine("FinalDialog");
    }

    public void StartCongratz1Dialog()
    {
        StopAllDialog();
        StartCoroutine("Contratz1Dialog");
    }

    public void StartCongratz2Dialog()
    {
        StopAllDialog();
        StartCoroutine("Contratz2Dialog");
    }

    public void StopAllDialog()
    {
        StopAllCoroutines();
    }

    IEnumerator FinalDialog()
    {
        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.SetGMText("");

        yield return new WaitForSeconds(2);

        _manager.Play("talksound3s");
        _dialogCanvas.SetGMText("This is it.");
        yield return new WaitForSeconds(3);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1.5f);

        _manager.Play("talksound2s");
        _dialogCanvas.SetGMText("Death.");
        yield return new WaitForSeconds(2);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(3f);

        _manager.Play("talksound5s");
        _dialogCanvas.SetGMText("I wish we had more time, but");
        yield return new WaitForSeconds(5);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1.5f);

        _manager.Play("talksound3s");
        _dialogCanvas.SetGMText("...");
        yield return new WaitForSeconds(3);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(3f);

        _manager.Play("talksound4s");
        _dialogCanvas.SetGMText("I loved being a part of you.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1f);

        _manager.Play("talksound3s");
        _dialogCanvas.SetGMText("In fact...");
        yield return new WaitForSeconds(3);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(2f);

        _manager.Play("talksound4s");
        _dialogCanvas.SetGMText("I love you. Dearly.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(2f);

        _dialogCanvas.SetAnswerOptions("...", "I love you too.");

        _startTime = Time.time;
        // So lange warten bis Answer zurück kommt
        while (_dialogCanvas.GetAnswer() == -1)
        {
            yield return new WaitForSeconds(0.1f);
        }

        answer = _dialogCanvas.GetAnswer();

        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.ResetAnswer();

        yield return new WaitForSeconds(2);

        _gameLogic.StartEnding();


    }

    IEnumerator Contratz1Dialog()
    {
        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.SetGMText("");

        yield return new WaitForSeconds(1);

        _manager.Play("talksound3s");
        _dialogCanvas.SetGMText("Good.");
        yield return new WaitForSeconds(3);

        _dialogCanvas.SetGMText("");
    }

    IEnumerator Contratz2Dialog()
    {
        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.SetGMText("");

        yield return new WaitForSeconds(1);

        _manager.Play("talksound4s");
        _dialogCanvas.SetGMText("Another two. Very well done.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");

    }

    IEnumerator Stage4Dialog()
    {
        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.SetGMText("");

        // Initial Wait
        yield return new WaitForSeconds(2);

        _manager.Play("talksound2s");
        _dialogCanvas.SetGMText("Look up.");
        yield return new WaitForSeconds(2);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound4s");
        _dialogCanvas.SetGMText("Our time together is nearly at an end.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound4s");
        _dialogCanvas.SetGMText("Soon we will have to say our goodbyes.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound5s");
        _dialogCanvas.SetGMText("Do not bother rolling. We are beyond the veil");
        yield return new WaitForSeconds(5);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(3);

        _manager.Play("talksound2s");
        _dialogCanvas.SetGMText("I am");
        yield return new WaitForSeconds(2);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1.5f);

        _manager.Play("talksound2s");
        _dialogCanvas.SetGMText("scared.");
        yield return new WaitForSeconds(2);

        _dialogCanvas.SetGMText("");
    }


    IEnumerator Stage3Dialog()
    {
        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.SetGMText("");

        // Initial Wait
        yield return new WaitForSeconds(1);

        _manager.Play("talksound4s");
        _dialogCanvas.SetGMText("The pendulum is getting faster.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
    }


    IEnumerator Stage2Dialog()
    {
        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.SetGMText("");

        // Initial Wait
        yield return new WaitForSeconds(3);

        _manager.Play("talksound3s");
        _dialogCanvas.SetGMText("You always respected yourself.");
        yield return new WaitForSeconds(3);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound5s");
        _dialogCanvas.SetGMText("Being a part of you, I always apprechiated that immensely.");
        yield return new WaitForSeconds(5);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound5s");
        _dialogCanvas.SetGMText("It made me feel seen. Even through you did not know of me.");
        yield return new WaitForSeconds(5);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound3s");
        _dialogCanvas.SetGMText("But I know you.");
        yield return new WaitForSeconds(3);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound4s");
        _dialogCanvas.SetGMText("And I know that you will be missed.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");

    }

    IEnumerator Stage1Dialog()
    {
        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.SetGMText("");

        // Initial Wait
        yield return new WaitForSeconds(4);

        _manager.Play("talksound3s");
        _dialogCanvas.SetGMText("Our time is depleting.");
        yield return new WaitForSeconds(3);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound2s");
        _dialogCanvas.SetGMText("Keep at it.");
        yield return new WaitForSeconds(2);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);



        _dialogCanvas.SetAnswerOptions("I am trying.", "I am sorry.");

        _startTime = Time.time;
        // So lange warten bis Answer zurück kommt
        while (_dialogCanvas.GetAnswer() == -1 && Time.time - _startTime < _maxWaitTime)
        {
            yield return new WaitForSeconds(0.1f);
        }

        answer = _dialogCanvas.GetAnswer();

        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.ResetAnswer();

        yield return new WaitForSeconds(1);

        if (answer == 0)
        {
            _manager.Play("talksound3s");
            _dialogCanvas.SetGMText("I know. Concentrate.");
            yield return new WaitForSeconds(3);
        }
        else if (answer == 1)
        {
            _manager.Play("talksound3s");
            _dialogCanvas.SetGMText("Don't be. Concentrate.");
            yield return new WaitForSeconds(3);
        }

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);



        _manager.Play("talksound3s");
        _dialogCanvas.SetGMText("You can do this.");
        yield return new WaitForSeconds(3);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound2s");
        _dialogCanvas.SetGMText("You have to.");
        yield return new WaitForSeconds(2);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);




        _dialogCanvas.SetAnswerOptions("Tell me what happend to me.", "I will concentrate.");

        _startTime = Time.time;
        // So lange warten bis Answer zurück kommt
        while (_dialogCanvas.GetAnswer() == -1 && Time.time - _startTime < _maxWaitTime)
        {
            yield return new WaitForSeconds(0.1f);
        }

        answer = _dialogCanvas.GetAnswer();

        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.ResetAnswer();

        yield return new WaitForSeconds(1);

        if (answer == 0)
        {
            _manager.Play("talksound3s");
            _dialogCanvas.SetGMText("Drunk driving.");
            yield return new WaitForSeconds(3);

            _dialogCanvas.SetGMText("");
            yield return new WaitForSeconds(1);

            _manager.Play("talksound3s");
            _dialogCanvas.SetGMText("Not you. Someone.");
            yield return new WaitForSeconds(3);

            _dialogCanvas.SetGMText("");
            yield return new WaitForSeconds(1);

            _manager.Play("talksound4s");
            _dialogCanvas.SetGMText("You were just walking your dogs.");
            yield return new WaitForSeconds(4);

        }
        else if (answer == 1)
        {
            _manager.Play("talksound3s");
            _dialogCanvas.SetGMText("Thank you. Good luck.");
            yield return new WaitForSeconds(3);
        }

        _dialogCanvas.SetGMText("");

    }

    IEnumerator InitialDialog()
    {
        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.SetGMText("");

        yield return new WaitForSeconds(2);


        _manager.Play("talksound3s");
        _dialogCanvas.SetGMText("Hello.");
        yield return new WaitForSeconds(3);


        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound45s");
        _dialogCanvas.SetGMText("It is time to roll our destiny.");
        yield return new WaitForSeconds(4.5f);


        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _dialogCanvas.SetAnswerOptions("Where am I?", "Who are you?");

        _startTime = Time.time;
        // So lange warten bis Answer zurück kommt
        while (_dialogCanvas.GetAnswer() == -1 && Time.time - _startTime < _maxWaitTime)
        {
            yield return new WaitForSeconds(0.1f);
        }

        answer = _dialogCanvas.GetAnswer();

        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.ResetAnswer();

        yield return new WaitForSeconds(1);

        if (answer == 0)
        {
            _manager.Play("talksound75s");
            _dialogCanvas.SetGMText("You are looking inside yourself. You lost the ability to look anywhere else.");
            yield return new WaitForSeconds(7.5f);
        }
        else if (answer == 1)
        {
            _manager.Play("talksound45s");
            _dialogCanvas.SetGMText("I am part of you.");
            yield return new WaitForSeconds(4.5f);

            _dialogCanvas.SetGMText("");
            yield return new WaitForSeconds(1);

            _manager.Play("talksound6s");
            _dialogCanvas.SetGMText("You were not meant to see me so soon.");
            yield return new WaitForSeconds(6f);
        }

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound3s");
        _dialogCanvas.SetGMText("You have to roll twos. Many of them.");
        yield return new WaitForSeconds(3);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound4s");
        _dialogCanvas.SetGMText("You have some control over the dice.\nUse it.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound3s");
        _dialogCanvas.SetGMText("You can find the dice on the table.");

        // Unlock dice roll option
        _rollManager.SetCanThrowFlag(true);

        yield return new WaitForSeconds(3);
        _dialogCanvas.SetGMText("");


        // So lange warten bis Answer zurück kommt
        while (_rollManager.GetLatestResult() == -1)
        {
            yield return new WaitForSeconds(0.1f);
        }

        _rollManager.SetCanThrowFlag(false);
        result = _rollManager.GetLatestResult();
        yield return new WaitForSeconds(1);

        _manager.Play("talksound2s");

        if (result != 2)
        {
            _dialogCanvas.SetGMText("You did not roll a two.");
        }
        else
        {
            _dialogCanvas.SetGMText("You rolled a two. Good.");
        }

        yield return new WaitForSeconds(2);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound3s");
        _dialogCanvas.SetGMText("Do you see the clock above us?");
        yield return new WaitForSeconds(3);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound4s");
        _dialogCanvas.SetGMText("Everytime the pendulum passes, we lose time.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound4s");
        _dialogCanvas.SetGMText("Everytime you roll a two, we gain time.");
        yield return new WaitForSeconds(4);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _manager.Play("talksound5s");
        _dialogCanvas.SetGMText("It is vital that we never hear the midnight bell.");
        yield return new WaitForSeconds(5);

        _dialogCanvas.SetGMText("");
        yield return new WaitForSeconds(1);

        _dialogCanvas.SetAnswerOptions("Why? What is going on?", "Then we should stop talking at once.");

        _startTime = Time.time;
        // So lange warten bis Answer zurück kommt
        while (_dialogCanvas.GetAnswer() == -1 && Time.time - _startTime < _maxWaitTime)
        {
            yield return new WaitForSeconds(0.1f);
        }

        answer = _dialogCanvas.GetAnswer();

        _dialogCanvas.RemoveAnswerOptions();
        _dialogCanvas.ResetAnswer();

        yield return new WaitForSeconds(1);

        if (answer == 0)
        {
            _manager.Play("talksound3s");
            _dialogCanvas.SetGMText("It was an accident. A bad one.");
            yield return new WaitForSeconds(3);

            _dialogCanvas.SetGMText("");
            yield return new WaitForSeconds(1);

            _manager.Play("talksound4s");
            _dialogCanvas.SetGMText("We are not expected to get through this. We can try anyway.");
            yield return new WaitForSeconds(4);

            _dialogCanvas.SetGMText("");
            yield return new WaitForSeconds(1);

            _manager.Play("talksound2s");
            _dialogCanvas.SetGMText("Now. Roll.");
            _rollManager.SetCanThrowFlag(true);

            yield return new WaitForSeconds(2);
        }
        else if (answer == 1)
        {
            _manager.Play("talksound2s");
            _dialogCanvas.SetGMText("Correct.");
            _rollManager.SetCanThrowFlag(true);
            yield return new WaitForSeconds(2);
        }
        else
        {
            _manager.Play("talksound4s");
            _dialogCanvas.SetGMText("Not one for many words? Good. Roll the dice.");
            _rollManager.SetCanThrowFlag(true);
            yield return new WaitForSeconds(4);
        }

        _dialogCanvas.SetGMText("");

        yield return new WaitForSeconds(5);
        _deathTimeManager.InitialDialogOver();

    }

}
