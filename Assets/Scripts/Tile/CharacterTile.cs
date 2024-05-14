using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WordleClone 
{
    public enum TileCorrectValue 
    {
        CORRECT, WRONGPOSITION, NOTINWORD
    }

    public class CharacterTile : MonoBehaviour
    {
        public char Character { get => textMeshPro.text.ToCharArray()[0]; }

        [SerializeField] private TextMeshProUGUI textMeshPro;
        [SerializeField] private Image bgImage;

        [Header("Color")]
        [SerializeField] private Color correctColor;
        [SerializeField] private Color wrongPositionColor;
        [SerializeField] private Color notInWordColor;

        public void UpdateCharacterTileText(string _text)
        {
            textMeshPro.text = _text;
        }

        public void UpdateCharacterTileBackground(TileCorrectValue _tileCorrectValue) 
        {
            switch (_tileCorrectValue)
            {
                case TileCorrectValue.CORRECT:
                    bgImage.color = correctColor;
                    break;
                case TileCorrectValue.WRONGPOSITION:
                    bgImage.color = wrongPositionColor;
                    break;
                case TileCorrectValue.NOTINWORD:
                    bgImage.color = notInWordColor;
                    break;
            }
        }

    }
}
