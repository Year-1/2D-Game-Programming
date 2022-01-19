using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject simpleEnemy;
    public GameObject boss;
    public GameObject[] spikes;

    Vector2[] enemySpawnPos = new Vector2[5]
    {
        new Vector2(9, -3),
        new Vector2(9, -2),
        new Vector2(9, -1),
        new Vector2(9, 0),
        new Vector2(9, 1),
    };

    Vector2[] spikeSpawnPos = new Vector2[2]{
        new Vector2(9, 2.2f),
        new Vector2(9, -4.2f),
    };

    Quaternion[] spikeRotation = new Quaternion[2]
    {
        new Quaternion(0,0,0, 1),
        new Quaternion(0,0, 180, 1),
    };

    private int specialIterations = 0;
    private int simpleIterations = 0;

    private IEnumerator Waves;
    private IEnumerator SpecialWave;
    private IEnumerator BossWave;
    private IEnumerator SpikesTemp;

    private void Start()
    {
        Waves = SpawnWaves();
        SpecialWave = SpawnSpecial();
        BossWave = SpawnBoss();
        SpikesTemp = SpawnSpikes();
        StartCoroutine(Waves);
        StartCoroutine(SpikesTemp);
        StartCoroutine(SpecialWave);
        StartCoroutine(BossWave);
    }

    // All enemies start at a randomly chosen time and repeat others spawn once at a random time

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        while (simpleIterations <= 12) {
            for (int i = 0; i < 6; i++) {
                for (int a = 0; a < 1; a++) {
                    Instantiate(simpleEnemy, enemySpawnPos[Random.Range(0, enemySpawnPos.Length)], Quaternion.identity);
                    simpleEnemy.name = "SimpleEnemy";
                }
                yield return new WaitForSeconds(Random.Range(0f, 3f));
            }
            simpleIterations++;
            yield return new WaitForSeconds(Random.Range(0f, 4f));
        }
    }

    private IEnumerator SpawnSpecial()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        while (specialIterations < 6) {
            for (int i = 0; i < 6; i++) {
                for (int a = 0; a < 1; a++) {
                    Instantiate(enemy, new Vector2(Random.Range(0f, 8f), Random.Range(-4f, 2f)), Quaternion.identity);
                    enemy.name = "Enemy";
                }
                yield return new WaitForSeconds(Random.Range(2f, 10f));
            }
            specialIterations++;
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
    }

    private IEnumerator SpawnBoss()
    {
        int a = 0;
        yield return new WaitForSeconds(Random.Range(35, 45));
        if (a == 0) {
            Instantiate(boss, new Vector2(9, -2), Quaternion.identity);
            a++;
        }
    }

    private IEnumerator SpawnSpikes()
    {
        yield return new WaitForSeconds(Random.Range(2f, 3f));
        for (int a = 0; a < 30; a++) {
            for (int i = 0; i < 1; i++) {
                int whichToSpawn = Random.Range(0, spikeSpawnPos.Length);
                Instantiate(spikes[whichToSpawn], spikeSpawnPos[whichToSpawn], Quaternion.identity);
            }
            yield return new WaitForSeconds(4f);
        }
        yield return new WaitForSeconds(3f);
    }
}
