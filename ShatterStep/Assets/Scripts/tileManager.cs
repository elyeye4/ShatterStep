using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private Tile tilePrefab;

    [SerializeField] private Transform MainCamera;
    [SerializeField] private GameObject lvlElementsFolder;

    private Dictionary<Vector2, Tile> tileDictionary; //Stores the tiles in a dictionary with their position as the key
    void Awake() //Quickly declares the new position of the camera
    {

    }
    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        tileDictionary = new Dictionary<Vector2, Tile>(); //Creates a new dictionary to store the tiles each time the grid is generated
        for (int x = 0; x < width; x++) //X axis
        {
            for (int y = 0; y < height; y++) //Y axis
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity); // Creates the tile prefab in the position of the grid based on X and Y from for
                spawnedTile.transform.SetParent(lvlElementsFolder.transform); // Sets the parent of the tile to the tile manager
                spawnedTile.name = $"Tile {x} {y}"; // Provides a name to the tile based on its position
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0); // Checks if the tile position is even or odd to set the color
                spawnedTile.Init(isOffset);

                tileDictionary[new Vector2(x, y)] = spawnedTile; // Adds the tile to the dictionary with its position as the key
            }
        }
        MainCamera.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }

    public Tile GetTileAtPosition(Vector2 pos) // Returns the tile at the given position to manage the tiles on other codes
    {
        if (tileDictionary.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}
