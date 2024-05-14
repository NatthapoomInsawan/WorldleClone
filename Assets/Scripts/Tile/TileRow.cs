using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WordleClone 
{
    public class TileRow : MonoBehaviour
    {
        public bool IsTileCompletelyFilled { get; private set; }

        [SerializeField] private int currentIndex;
        [SerializeField] private List<CharacterTile> tiles;

        public void UpdateRowText(string _text)
        {
            if (_text == "Delete")
            {
                if (currentIndex > 0)
                    currentIndex--;

                tiles[currentIndex].UpdateCharacterTileText("");
                IsTileCompletelyFilled = false;

                return;
            }
            else if (currentIndex > tiles.Count - 1)
                return;

            tiles[currentIndex].UpdateCharacterTileText(_text);
            currentIndex++;

            if (currentIndex >= tiles.Count)
                IsTileCompletelyFilled = true;

        }

    }
}
