using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Loader<Manager>
{   public GameObject spawnPoints;
    public GameObject[] enemy;
    public int maxEnemesOnScreen;
    public int totalEnemies;
    public int enemiesPerSpawn;
   
    private int enemiesOnScreen = 0;
    private const float spawnDelay = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        if (enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if (enemiesOnScreen < maxEnemesOnScreen)
                {
                    GameObject newEnemy = Instantiate(enemy[1]) as GameObject;
                    newEnemy.transform.position = spawnPoints.transform.position;
                    enemiesOnScreen += 1;
                }
            }
            
            yield return new WaitForSeconds(spawnDelay);
            StartCoroutine(Spawn());
        }
        

    }

    public void RemoveEnemyFromScrenn()
    {
        if (enemiesOnScreen > 0)
        {
            enemiesOnScreen -= 0;
        }
    }

}
