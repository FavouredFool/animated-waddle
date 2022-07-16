using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumHeadSound : MonoBehaviour
{
    AudioManager _manager;

    void Start()
    {
        _manager = FindObjectOfType<AudioManager>();
        _manager.Play("wind");
    }

    public void PlaySound(string name)
    {
        _manager.Play(name);
    }


}
