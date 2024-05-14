using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WordleClone 
{
    public class CharacterTile : MonoBehaviour
    {
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

    }
}
