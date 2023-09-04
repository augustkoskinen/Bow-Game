using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> spawnPointsStart;
    public List<Transform> spawnPoints; 
    public int numberOfSpawns;

    public List<Transform> borderSpawn; 
    public List<GameObject> border;

    public float timeBetweenSpawnsEasy;
    public float timeBetweenSpawnsHard;
    float nextSpawnTime;

    public float timeBetweenSpawnsBorder;
    float nextSpawnTimeBorder;

    public GameObject spikeBall;

    GameManager gm;

    public float timeUntilMaxDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

     if(Time.time > nextSpawnTime) {
        gm.score++;
        if(gm.score > PlayerPrefs.GetInt("Highscore")) {
            PlayerPrefs.SetInt("Highscore", gm.score);
        }
        for(int i = 0; i < numberOfSpawns; i++) {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Instantiate(spikeBall, randomSpawnPoint.position, randomSpawnPoint.rotation);
            spawnPoints.Remove(randomSpawnPoint);
            
            
        }

        spawnPoints.Clear();
        for(int i=0; i<spawnPointsStart.Count; i++) {
            spawnPoints.Add(spawnPointsStart[i]);
        }

        nextSpawnTime = Time.time + Mathf.Lerp(timeBetweenSpawnsEasy, timeBetweenSpawnsHard, GetDifficultyPercent());
     } 
    if(Time.time > nextSpawnTimeBorder) {
        for(int i = 0; i < 2; i++){
            GameObject randomBorder = border[Random.Range(0, border.Count)];
            Instantiate(randomBorder, borderSpawn[i].position, borderSpawn[i].rotation);
        }
        nextSpawnTimeBorder = Time.time + timeBetweenSpawnsBorder;
    }
    }

    public float GetDifficultyPercent() {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / timeUntilMaxDifficulty);
    }
    
}
