using System;
using OyuncakHazinesiNerede.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContainerValidation : MonoBehaviour
{
    [SerializeField] private Image _validationBG;
    [SerializeField] private Sprite _bgCorrect;
    [SerializeField] private Sprite _bgFalse;
    [SerializeField] private TMP_Text _tmpText;

    [SerializeField] private Image _buttonImage;
    [SerializeField] private Sprite _buttonCorrect;
    [SerializeField] private Sprite _buttonFalse;

    public void OpenValidation(ItemType itemType, bool isCorrect, ItemType wantedItemType)
    {
        if(FindObjectOfType<GameManager>().currentChapter != 2) return;
        gameObject.SetActive(true);
        _validationBG.sprite = isCorrect ? _bgCorrect : _bgFalse;
        _buttonImage.sprite = isCorrect ? _buttonCorrect : _buttonFalse;

        _tmpText.text = isCorrect ? GetRightQuote(itemType) : GetWrongQuote(wantedItemType);
    }
    public void CloseValidation()
    {
        gameObject.SetActive(false);
    }

    private string GetWrongQuote(ItemType itemType)
    {
        return $"<b>Bu madde {itemType.ToString().ToLower()} değil.</b> \n Not: Eğer bir eşyanın hangi formda olduğuna karar veremediysen eşyanın içerisinde bulunduğu maddenin formunu düşünerek yerleştir.";
    }
    private string GetRightQuote(ItemType itemType)
    {
        string reversePrefix = itemType == ItemType.Gaz ? "dı" : "ydı";
        return $"<b>Tebrikler! </b> \n Bu madde bir {itemType.ToString().ToLower()}{reversePrefix}!";
    }
}
