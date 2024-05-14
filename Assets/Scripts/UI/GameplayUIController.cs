using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace WordleClone
{
    public class GameplayUIController : MonoBehaviour
    {
        [Header("UI Reference")]
        [SerializeField] private TextMeshProUGUI randomWordText;
        [SerializeField] private NotifyPanelUI notifyPanelUI;

        public void SetRandomWordText(string _text) 
        {
            randomWordText.text = _text;
        }

        public void OpenNotifyPanelUI(string _title, string _paragraph, NotifyButtonStruct[] _notifyButtonStructs = null) 
        {
            notifyPanelUI.SetNotifyPanel(_title, _paragraph, _notifyButtonStructs);
        }

        public void CloseNotifyPanelUI() 
        {
            notifyPanelUI.Close();
        }
    }
}
