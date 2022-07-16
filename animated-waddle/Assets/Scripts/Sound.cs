using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;

    public GameObject sourceObject;

    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 10)]
    public float pitch;

    [Range(0, 1)]
    public float spacialBlend;

    [Range(0, 256)]
    public int priority;

    public bool loop;
}


