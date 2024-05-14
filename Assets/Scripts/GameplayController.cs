using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WordleClone 
{
    public class GameplayController : MonoBehaviour, INeedInitialization
    {
        [Header("Controller References")]
        [SerializeField] private VirtualKeyboardController virtualKeyboardController;
        [SerializeField] private TileController tileController;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            virtualKeyboardController.Init();

            foreach (var key in virtualKeyboardController.KeyboardButtons)
                key.OnKeyboardClick += UpdateTileController;
        }

        private void OnDisable()
        {
            foreach (var key in virtualKeyboardController.KeyboardButtons)
                key.OnKeyboardClick -= UpdateTileController;
        }

        private void UpdateTileController(string _text) 
        {
            if (_text == "Enter") 
            {
                if (!tileController.IsCurrentRowCompletelyFilled()) 
                {
                    Debug.Log("Current row is not completely fill!");
                    return;
                }

                tileController.CurrentIndex++;
            }
            else
                tileController.UpdateCurrentRowText(_text);
        }

    }
}
