using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool spawnEnemies = true;
    public GameObject[] enemyPrefab;
    public Transform plrPos;
    public float spawnDelay, minSpawnRange, xMin, xMax, yMin, yMax;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginSpawning());
    }
    IEnumerator BeginSpawning(){
        while (spawnEnemies){
            yield return new WaitForSeconds(spawnDelay);
            SpawnEnemy();
        }
    }
    void SpawnEnemy(){
        int enemyRank = 0;
        float randintX = Random.Range(xMin, xMax);
        float randinty = Random.Range(yMin, yMax);
        float distFromPlr = Mathf.Sqrt((randintX - plrPos.position.x)*(randintX - plrPos.position.x) + (randinty - plrPos.position.y)*(randinty - plrPos.position.y));

        while (distFromPlr < minSpawnRange){
            randintX = Random.Range(xMin, xMax);
            randinty = Random.Range(yMin, yMax);
            distFromPlr = Mathf.Sqrt(Mathf.Pow((randintX - plrPos.position.x), 2) + Mathf.Pow((randinty - plrPos.position.y), 2));
        }
        Instantiate(enemyPrefab[enemyRank], new Vector2(randintX, randinty), Quaternion.identity);
    }
}
