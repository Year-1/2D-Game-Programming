using System.Collections;
using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    public GameObject coin;

    public int simpleIterations;
    private IEnumerator CoinWave;


    private void Start()
    {
        CoinWave = SpawnWaves();
        StartCoroutine(CoinWave);
    }

    // Spawns the coins for the player to pick up.
    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        while (simpleIterations <= 20) {
            for (int i = 0; i < 6; i++) {
                for (int a = 0; a < 1; a++) {
                    float randomNumber = Random.Range(2f, -4f);
                    Instantiate(coin, new Vector2(9, randomNumber), Quaternion.identity);
                    coin.name = "Coin";
                }
                yield return new WaitForSeconds(Random.Range(0f, 2f));
            }
            // this number makes it so 13 runs of this code takes 175seconds
            simpleIterations++;
            yield return new WaitForSeconds(Random.Range(0f, 2f));
        }
    }
}
