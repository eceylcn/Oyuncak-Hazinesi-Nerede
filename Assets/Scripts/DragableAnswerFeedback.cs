using System.Collections;
using System.Collections.Generic;
using OyuncakHazinesiNerede.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragableAnswerFeedback : MonoBehaviour
{
    [SerializeField] private Image _validationBG;
    [SerializeField] private Sprite _bgCorrect;
    [SerializeField] private Sprite _bgFalse;
    [SerializeField] private TMP_Text _tmpText;

    [SerializeField] private Image _buttonImage;
    [SerializeField] private Sprite _buttonCorrect;
    [SerializeField] private Sprite _buttonFalse;
    
    public void OpenValidation(bool isCorrect, string text)
    {
        
        gameObject.SetActive(true);
        _validationBG.sprite = isCorrect ? _bgCorrect : _bgFalse;
        _buttonImage.sprite = isCorrect ? _buttonCorrect : _buttonFalse;

        _tmpText.text = text;
    }
    public void CloseValidation()
    {
        gameObject.SetActive(false);
    }
}
