using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

    [SerializeField]
    Image _crossfade;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //StartEnding();
    }


    public void StartEnding()
    {
        StartCoroutine(Ending());
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    IEnumerator Ending()
    {

        yield return new WaitForSeconds(21.5f);
        FindObjectOfType<AudioManager>().Play("Flatline");

        yield return new WaitForSeconds(16f);

        for (int i = 0; i <= 100; i++)
        {
            _crossfade.color = new Color(1, 1, 1, i/100f);
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(5f);

        QuitApplication();

    }

}
