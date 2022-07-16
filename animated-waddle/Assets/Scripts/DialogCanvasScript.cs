using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogCanvasScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text GMText;

    [SerializeField]
    private Image answerOption1;

    [SerializeField]
    private Image answerOption2;

    [SerializeField]
    private Image answerOptionImage1;

    [SerializeField]
    private Image answerOptionImage2;

    bool _canChooseOptions = true;

    int _answer = -1;

    private void Update()
    {
        if (_canChooseOptions)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _answer = 0;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _answer = 1;
            }
        }
    }

    public void SetGMText(string text)
    {
        GMText.text = text;
    }

    public void SetAnswerOptions(string answerText1, string answerText2)
    {
        _canChooseOptions = true;

        answerOption1.gameObject.SetActive(true);
        answerOption2.gameObject.SetActive(true);
        answerOptionImage1.gameObject.SetActive(true);
        answerOptionImage2.gameObject.SetActive(true);

        answerOption1.transform.GetChild(0).GetComponent<TMP_Text>().text = answerText1;
        answerOption2.transform.GetChild(0).GetComponent<TMP_Text>().text = answerText2;
    }

    public void RemoveAnswerOptions()
    {
        _canChooseOptions = false;

        answerOption1.gameObject.SetActive(false);
        answerOption2.gameObject.SetActive(false);
        answerOptionImage1.gameObject.SetActive(false);
        answerOptionImage2.gameObject.SetActive(false);
    }

    public int GetAnswer()
    {
        return _answer;
    }

    public void ResetAnswer()
    {
        _answer = -1;
    }
}
