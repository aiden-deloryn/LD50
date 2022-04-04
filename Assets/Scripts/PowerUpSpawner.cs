using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public bool spawnEnemies = true;
    public GameObject[] powerUpDrop;
    public GameObject gunPrefab;
    public Transform plrPos;
    public float spawnDelay, minSpawnRange, xMin, xMax, yMin, yMax, mutationTime;
    private float timePassed;
    private int enemyRank = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginSpawning());
    }
    void Update()
    {
        timePassed += Time.deltaTime;
        //Debug.Log(timePassed);
    }
    IEnumerator BeginSpawning()
    {
        while (spawnEnemies)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        float randintX = Random.Range(xMin, xMax);
        float randinty = Random.Range(yMin, yMax);
        float distFromPlr = Mathf.Sqrt((randintX - plrPos.position.x) * (randintX - plrPos.position.x) + (randinty - plrPos.position.y) * (randinty - plrPos.position.y));

        while (distFromPlr < minSpawnRange)
        {
            randintX = Random.Range(xMin, xMax);
            randinty = Random.Range(yMin, yMax);
            distFromPlr = Mathf.Sqrt(Mathf.Pow((randintX - plrPos.position.x), 2) + Mathf.Pow((randinty - plrPos.position.y), 2));
        }
        Instantiate(powerUpDrop[ChooseRandomEnemy()], new Vector2(randintX, randinty), Quaternion.identity);
    }
    int ChooseRandomEnemy()
    {
        if ((enemyRank < powerUpDrop.Length - 1) && (mutationTime * (enemyRank + 1) < timePassed))
        {
            enemyRank += 1;
            //Debug.Log(enemyRank);
        }
        int enemyIndex = Random.Range(0, enemyRank + 1);
        //Debug.Log(enemyIndex);

        return enemyIndex;
    }
}
