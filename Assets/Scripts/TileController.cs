using System.Collections;
using System.Collections.Generic;
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

        public bool IsCurrentRowCompletelyFilled() 
        {
            return tileRows[currentIndex].IsTileCompletelyFilled;
        }

    }
}
