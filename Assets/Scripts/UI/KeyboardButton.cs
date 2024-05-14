using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WordleClone 
{
    public class KeyboardButton : MonoBehaviour, INeedInitialization
    {
        public string TextSignal { get; private set; }
        public event Action<string> OnKeyboardClick;

        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI textMeshPro;

        public void Init()
        {
            TextSignal = textMeshPro.text.ToUpper();

            button.onClick.AddListener(() =>
            {
                OnKeyboardClick?.Invoke(textMeshPro.text);
            });
        }

        public void ClickButton() 
        {
            //button.onClick.Invoke();
            var pointerEvent = new PointerEventData(EventSystem.current); 
            ExecuteEvents.Execute(gameObject, pointerEvent, ExecuteEvents.pointerEnterHandler); 
            ExecuteEvents.Execute(gameObject, pointerEvent, ExecuteEvents.submitHandler);
        }

    }
}
