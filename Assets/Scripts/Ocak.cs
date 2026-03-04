using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocak : MonoBehaviour
{
    [SerializeField] private GameObject _kazan;
    [SerializeField] private GameObject _warning;

    public void OpenWarning()
    {
        if (_kazan.activeInHierarchy == false)
        {
            _warning.SetActive(true);
        }
    }
}
