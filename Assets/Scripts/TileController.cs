using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WordleClone 
{
    public class TileController : MonoBehaviour
    {
        public int CurrentIndex 
        { 
            get => currentIndex;
            set 
            {
                if (value < tileRows.Count && value > 0)
                    currentIndex = value;
            }
        }

        [SerializeField] private int currentIndex;
        [SerializeField] private List<TileRow> tileRows;

        public void UpdateCurrentRowText(string _text)
        {
            tileRows[currentIndex].UpdateRowText(_text);
        }

        public bool CalculateCurrentRowValue(string _randomWord) 
        {
            char[] randomWordCharArray = _randomWord.ToCharArray();
            char[] currentRowCharArray = tileRows[currentIndex].GetWordFromRow().ToCharArray();
            int correctCount = 0;

            TileCorrectValue[] tileCorrectValues = new TileCorrectValue[_randomWord.Length];

            for (int i = 0; i < _randomWord.Length; i++) 
            {
                if (!randomWordCharArray.Contains(currentRowCharArray[i]))
                {
                    tileCorrectValues[i] = TileCorrectValue.NOTINWORD;
                }
                else if (randomWordCharArray[i] == currentRowCharArray[i])
                {
                    tileCorrectValues[i] = TileCorrectValue.CORRECT;
                    correctCount++;
                }
                else 
                {
                    tileCorrectValues[i] = TileCorrectValue.WRONGPOSITION;
                }
            }

            tileRows[currentIndex].UpdateRowBackground(tileCorrectValues);

            if (correctCount == _randomWord.Length)
                return true;
            else
                return false;
        }

        public bool IsCurrentRowCompletelyFilled() 
        {
            return tileRows[currentIndex].IsTileCompletelyFilled;
        }

    }
}
