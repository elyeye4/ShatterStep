using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, alernativeColor;
    [SerializeField] private SpriteRenderer tileSprite;
    [SerializeField] private GameObject tileSpriteHighlight;
    public void Init(bool isOffset) //If the tile position is even or odd then the color varies
    {
        tileSprite.color = isOffset ? alernativeColor : baseColor;
    }

    void OnMouseEnter()
    {
        tileSpriteHighlight.SetActive(true); // Activates the highlight gameObject just over the tile
    }

    void OnMouseExit()
    {
        tileSpriteHighlight.SetActive(false);
    }
}
