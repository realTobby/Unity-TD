using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject ENEMY_PREFAB;

    public float TimeBetweenWaves = 5f;

    private float Countdown = 5f;

    public int WaveIndex = 0;

    public Transform SpawnLocation;

    public bool IsSpawning = false;

    public TMPro.TMP_Text UI_CountDownText;

    // Update is called once per frame
    void Update()
    {
        UI_CountDownText.text = Mathf.Floor(Countdown).ToString();

        if (Countdown <= 0)
        {
            Countdown = TimeBetweenWaves;
            StartCoroutine(nameof(SpawnWave));
        }
        else
        {
            if(IsSpawning == false)
            {
                Countdown -= Time.deltaTime;
            }
            
        }
    }

    IEnumerator SpawnWave()
    {
        IsSpawning = true;

        WaveIndex += 1;

        int numOfEnemies = WaveIndex;

        for(int i = 0; i < numOfEnemies-1; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(.5f);
        }

        IsSpawning = false;
        
    }

    private void SpawnEnemy()
    {
        Instantiate(ENEMY_PREFAB, SpawnLocation.position, Quaternion.identity);
    }


}
