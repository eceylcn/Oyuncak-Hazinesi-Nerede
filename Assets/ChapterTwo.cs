using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterTwo : MonoBehaviour
{
    private bool _isPlayed;
    public GameObject[] _arrows;
    void Start()
    {
        if(_isPlayed) return;
        _isPlayed = true;

        foreach (var arrow in _arrows)
        {
            arrow.SetActive(true);
        }
    }
}
