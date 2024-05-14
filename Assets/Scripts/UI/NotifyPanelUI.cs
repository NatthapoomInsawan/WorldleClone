using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WordleClone
{
    public class NotifyPanelUI : MonoBehaviour, IUIBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI paragraphText;
        [SerializeField] private Transform buttonTransform;
        [SerializeField] private NotifyButton defaultButton;

        [Header("Button Prefab")]
        [SerializeField] private GameObject buttonPrefab;

        public void SetNotifyPanel(string _title, string _paragraph, NotifyButtonStruct[] _notifyButtonStructs = null) 
        {
            titleText.text = _title;
            paragraphText.text = _paragraph;

            if (_notifyButtonStructs is null)
            {
                defaultButton.Open();
            }
            else 
            {
                for (int i = 0; i < _notifyButtonStructs.Length; i++) 
                {
                    NotifyButton newButton = Instantiate(buttonPrefab, buttonTransform).GetComponent<NotifyButton>();
                    newButton.SetNotifyButton(_notifyButtonStructs[i]);
                }
                
            }

            Open();
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
