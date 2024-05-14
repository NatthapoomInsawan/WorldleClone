using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WordleClone 
{
    public class KeyboardButton : MonoBehaviour, INeedInitialization
    {
        public event Action<string> OnKeyboardClick;

        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI textMeshPro;

        public void Init()
        {
            var textSignal = textMeshPro.text;

            button.onClick.AddListener(() =>
            {
                OnKeyboardClick?.Invoke(textSignal);
            });
        }

    }
}
