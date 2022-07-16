using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RKeyCanvasScript : MonoBehaviour
{
    [SerializeField]
    private Image _RKeyImage;

    [SerializeField]
    private Transform _cameraTransform;

    [SerializeField]
    private RollManager _rollManager;

    private void Awake()
    {
        _RKeyImage.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + _cameraTransform.forward);

        _RKeyImage.gameObject.SetActive(_rollManager.GetCanThrowFlag());

    }


}
