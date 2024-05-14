using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace WordleClone 
{
    public class VirtualKeyboardController : MonoBehaviour, INeedInitialization
    {
        public Dictionary<string, KeyboardButton> KeyboardButtons { get => keyboardButtons; }

        [SerializeField] private List<Transform> rowTransforms;

        private Dictionary<string, KeyboardButton> keyboardButtons = new();

        private System.IDisposable inputEventListenr;

        public void Init()
        {
            foreach (var transform in rowTransforms) 
            {
                var keyInRow = transform.GetComponentsInChildren<KeyboardButton>();

                foreach (var key in keyInRow)
                {
                    key.Init();
                    keyboardButtons.Add(key.TextSignal, key);
                }
            }

            inputEventListenr = InputSystem.onEvent.Where(e => e.HasButtonPress()).Call((_inputEventPtr) =>
            {
                foreach (var button in _inputEventPtr.GetAllButtonPresses())
                    KeyboardInput(button);
            });
        }

        private void KeyboardInput (InputControl _button)
        {
            if (_button.IsPressed())
                return;

            string inputName = _button.name.ToUpper();

            if (inputName == "DELETE" || inputName == "BACKSPACE")
            {
                keyboardButtons["DELETE"].ClickButton();
                return;
            }

            if (_button.device.name != "Keyboard" || !keyboardButtons.ContainsKey(inputName))
                return;

            keyboardButtons[inputName].ClickButton();
        }

        public void OnDisable()
        {
            inputEventListenr.Dispose();
        }
    }
}

