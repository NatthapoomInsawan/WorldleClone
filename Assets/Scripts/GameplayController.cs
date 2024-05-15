using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WordleClone 
{
    public class GameplayController : MonoBehaviour, INeedInitialization
    {
        [Header("Controller References")]
        [SerializeField] private VirtualKeyboardController virtualKeyboardController;
        [SerializeField] private GameplayUIController gameplayUIController;
        [SerializeField] private TileController tileController;

        private string randomWord;
        private int guessCount = 0;
        private bool isGameOver;

        private void Start()
        {
            Init();
        }

        private void OnDisable()
        {
            foreach (var key in virtualKeyboardController.KeyboardButtons)
                key.Value.OnKeyboardClick -= UpdateTileController;
        }
        public void Init()
        {
            virtualKeyboardController.Init();

            foreach (var key in virtualKeyboardController.KeyboardButtons)
                key.Value.OnKeyboardClick += UpdateTileController;

            randomWord = RandomWord();
            gameplayUIController.SetRandomWordText(randomWord);
        }

        private void UpdateTileController(string _text) 
        {
            if (_text == "Enter") 
            {
                if (!tileController.IsCurrentRowCompletelyFilled()) 
                {
                    gameplayUIController.OpenNotifyPanelUI("WARNING", "Current row is not completely fill!");
                    return;
                }

                isGameOver = tileController.CalculateCurrentRowValue(randomWord);

                tileController.CurrentIndex++;
                guessCount++;

                if (guessCount == 6 || isGameOver) 
                {
                    NotifyButtonStruct[] notifyButtons = { new NotifyButtonStruct("Yes", () => { SceneManager.LoadScene("Gameplay"); }),
                                                           new NotifyButtonStruct("No", () => { gameplayUIController.CloseNotifyPanelUI(); Application.Quit(); }) };

                    gameplayUIController.OpenNotifyPanelUI("GAMEOVER",
                                                            $"The word is {randomWord} \n Guess count: {guessCount} \n Play agian?",
                                                            notifyButtons);
                }

            }
            else
                tileController.UpdateCurrentRowText(_text);
        }

        private string RandomWord() 
        {
            List<char> alphabets = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 
                                                    'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 
                                                    'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 
                                                    'Y', 'Z'};
            StringBuilder stringBuilder = new();

            for (int i = 0; i < 5; i++) 
            {
                int alphabetIndex = Random.Range(0, alphabets.Count);
                stringBuilder.Append(alphabets[alphabetIndex]);
                alphabets.RemoveAt(alphabetIndex);
            }

            return stringBuilder.ToString();
        }

    }
}
