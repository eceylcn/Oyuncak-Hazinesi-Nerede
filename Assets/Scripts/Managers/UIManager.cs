using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;
using System.ComponentModel;

public class UIManager : MonoBehaviour
{
    [Space(40)]
    [Header("UI Buttons")]
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _phoneButton;
    [SerializeField] private Button _phoneCloseButton;
    [SerializeField] private Button _helpButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _exitGameButton;

    [Space(40)]
    [Header("Window References")]
    [SerializeField] GameObject _helpWindow;
    [SerializeField] TMP_Text _helpText;
    [SerializeField] private GameObject _exitPopUpWindow;

    [Space(10)]
    [SerializeField] GameObject _phoneWindow;
    [SerializeField] TMP_Text _phoneText;
    [SerializeField] GameObject _phoneNotification;

    [Space(10)]
    [SerializeField] GameObject _tabletWindow;
    [SerializeField] GameObject _defaultTabletContent;

    [Space(10)]
    [SerializeField] GameObject WrongInputWindow;

    [Space(10)] 
    [SerializeField] private ContainerValidation _containerValidation;
    [SerializeField] private DragableAnswerFeedback _dragableAnswerFeedback;
    [Space(10)]
    [SerializeField] GameObject ContainerRef;
    [SerializeField] Sprite ContainerTrueImage;
    [SerializeField] Sprite ContainerFalseImage;
    [SerializeField] string ContainerTrueString;
    [SerializeField] string ContainerFalseString;
    [SerializeField] Button ContainerButtonRef;
    [SerializeField] Sprite ContainerFalseButtonImage;
    [SerializeField] Sprite ContainerTrueButtonImage;

    #region Events

    public Action OnGameQuit { get; set; }

    #endregion

    private void Awake()
    {
        GameEvents.PageLoaded += OnPageLoad;
        GameEvents.showContainerState += ShowContainerState;
        GameEvents.ReceivePhoneNotification += OnReceivePhoneNotification;
        GameEvents.inspectItem += InspectItemOnTablet;
        GameEvents.SoftCheckWrong += OnSoftCheckWrong;

        _helpButton.onClick.AddListener(OnHelpButtonClick);
        _phoneButton.onClick.AddListener(OnPhoneButtonClick);
        
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _exitGameButton.onClick.AddListener(OnExitGameButtonClick);
        _resumeButton.onClick.AddListener(OnResumeGameButtonClick);

        GameEvents.ChapterTwoCheckAnswer += _containerValidation.OpenValidation;
        GameEvents.CheckAnswer += _dragableAnswerFeedback.OpenValidation;
    }

    public void OnPhoneButtonClick()
    {
        _phoneWindow.SetActive(!_phoneWindow.activeSelf);
        _phoneNotification.SetActive(false);
        GameEvents.phoneOpened?.Invoke();
    }

    public void OnHelpButtonClick()
    { 
        _helpWindow.SetActive(!_helpWindow.activeSelf); 
        GameEvents.helpOpened?.Invoke();
    }
    private void OnExitButtonClick()
    {
        _exitPopUpWindow.SetActive(true);
    }
    private void OnExitGameButtonClick()
    {
        OnGameQuit.Invoke();
    }
    private void OnResumeGameButtonClick()
    {
        _exitPopUpWindow.SetActive(false);
    }
    private void OnReceivePhoneNotification()
    {
        _phoneNotification.SetActive(true);
    }

    private void InspectItemOnTablet(InspectItem item)
    {
        item.InspectContent.SetActive(true);
        _defaultTabletContent.SetActive(false);

        _tabletWindow.SetActive(true);
    }
    private void ShowContainerState(ItemContainer container, bool torf)
    {
        Debug.Log("Showing container stateee");

        if (torf)
        {
            ContainerButtonRef.onClick.RemoveAllListeners();
            ContainerButtonRef.image.sprite = ContainerTrueButtonImage;
            ContainerButtonRef.image.SetNativeSize();
            ContainerButtonRef.onClick.AddListener(() => { ContainerButtonRef.transform.parent.gameObject.SetActive(false); });
        }

        else
        {
            ContainerButtonRef.onClick.RemoveAllListeners();
            ContainerButtonRef.image.sprite = ContainerFalseButtonImage;
            ContainerButtonRef.image.SetNativeSize();
            ContainerButtonRef.onClick.AddListener(() => { GameEvents.RestartLevel?.Invoke(); ContainerButtonRef.transform.parent.gameObject.SetActive(false); });
        }

        foreach (Image tempimage in ContainerRef.GetComponentsInChildren<Image>())
        {
            if (tempimage.gameObject.name == "bg") 
            { 
                if (torf) 
                { tempimage.sprite = ContainerTrueImage; } 
                else { tempimage.sprite = ContainerFalseImage; }
                break;
            } 
        }

        foreach (TMP_Text text in ContainerRef.GetComponentsInChildren<TMP_Text>()) 
        {
            if (text.name == "validateText")
            {
                if (torf)
                {
                    text.text = ContainerTrueString.Replace("{itemtype}", container.m_ItemType.ToString());
                }
                else
                {
                    text.text = ContainerFalseString.Replace("{itemtype}", container.m_ItemType.ToString());
                }
            }
        }

        ContainerRef.SetActive(true);
    }

    public void AllowNext(bool complete)
    {
        if (complete) { _nextButton.interactable = true; }
        else { _nextButton.interactable = false; }
    }



    // UI Manager's page load is only for texts and visuals.
    public void OnPageLoad(Page page)
    {
        if (GameFunctions.GetCurrentPage?.Invoke() == 1) _previousButton.interactable = false;
        else _previousButton.interactable = true;

        _helpText.text = page.helpString;
        page.LoadPhoneContent();
    }

    private void OnSoftCheckWrong()
    {
        WrongInputWindow.SetActive(true);
    }

}
