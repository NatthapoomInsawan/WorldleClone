using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WordleClone
{
    public struct NotifyButtonStruct 
    {
        public NotifyButtonStruct(string _buttonText, Action _action = null) 
        {
            ButtonText = _buttonText;
            ButtonAction = _action;
        }

        public string ButtonText { get; set; }
        public Action ButtonAction { get; set; }
    }

    public class NotifyButton : MonoBehaviour, IUIBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private Button button;

        public void SetNotifyButton(NotifyButtonStruct _notifyButtonStruct) 
        {
            buttonText.text = _notifyButtonStruct.ButtonText;
            button.onClick.AddListener(() =>
            {
                if (_notifyButtonStruct.ButtonAction != null)
                    _notifyButtonStruct.ButtonAction?.Invoke();
            });
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
