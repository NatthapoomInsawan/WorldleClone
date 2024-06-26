using System.Collections;
using System.Collections.Generic;
using System.Text;
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

        public void UpdateRowBackground(TileCorrectValue[] tileCorrectValues) 
        {
            for (int i = 0; i < tileCorrectValues.Length; i++) 
            {
                tiles[i].UpdateCharacterTileBackground(tileCorrectValues[i]);
            }
        }

        public string GetWordFromRow() 
        {
            StringBuilder stringBuilder = new();

            foreach (var tile in tiles) 
                stringBuilder.Append(tile.Character);

            return stringBuilder.ToString();
        }

    }
}
