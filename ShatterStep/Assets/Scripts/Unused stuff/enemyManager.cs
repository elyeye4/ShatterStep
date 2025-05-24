using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyFolder;
    bool spawnFlag = true;
    List<GameObject> enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Coroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count > 10)
        {
            spawnFlag = false;
        }
        else
        {
            spawnFlag = true;
        }
    }
    void generateEnemey()
    {
        // Generate a random position within the screen bounds
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);
        Vector2 randomPosition = new Vector2(x, y);

        // Instantiate the enemy prefab at the random position
        GameObject enemyPrefab = Resources.Load<GameObject>("Enemy"); // Load your enemy prefab from Resources folder
        var newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        // Set the enemy's parent to this object (optional)
        newEnemy.transform.parent = enemyFolder.transform;
        enemies.Add(newEnemy);
    }
    IEnumerator Coroutine()
    {
        while (true)
        {
            // Wait for 2 seconds before changing direction
            yield return new WaitForSeconds(0.5f);

            // Call the method 
            if (spawnFlag)
            { generateEnemey(); }
        }
    }
}
