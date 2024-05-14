using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WordleClone 
{
    public class VirtualKeyboardController : MonoBehaviour, INeedInitialization
    {
        public List<KeyboardButton> KeyboardButtons { get => keyboardButtons; }

        [SerializeField] private List<Transform> rowTransforms;

        private List<KeyboardButton> keyboardButtons = new();

        public void Init()
        {
            foreach (var transform in rowTransforms) 
            {
                var keyInRow = transform.GetComponentsInChildren<KeyboardButton>();
                keyboardButtons.AddRange(keyInRow);

                foreach (var key in keyInRow)
                    key.Init();
            }
        }
    }
}

