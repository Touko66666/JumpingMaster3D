using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;

    public Rigidbody2D player;

    //private bool gameIsOn = true;
    private int spawnPosY;
    private int spawnPosMax;
    private float maxPlatformSpawnEdge = 6.8f;
    private float maxPlatformSpawnCenter = 4.5f;
    private float difficulty;
    private float difficultyCounter;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosY = 3;
        spawnPosMax = 9;
    }
    void Update()
    {
        difficultyCounter = 1f;
        difficulty += difficultyCounter * Time.deltaTime;

        if (player.transform.position.y > spawnPosY - 7)
        {
            spawnPlatforms(spawnPosY, spawnPosMax);
        }

    }

    private void spawnPlatforms(int y, int max)
    {
        if (Time.timeScale == 1)
        {
            while (y <= max)
            {
                if (difficulty < 30)
                {
                    GameObject b = Instantiate(platformPrefab) as GameObject;
                    b.transform.position = new Vector3(Random.Range(-2, 2), y - Random.Range(0, 2) * 0.4f, 1);
                }
                else
                {
                    maxPlatformSpawnEdge = 6;
                    maxPlatformSpawnCenter = 2;
                }

                if (difficulty < 70)
                {
                    GameObject a = Instantiate(platformPrefab) as GameObject;
                    a.transform.position = new Vector3(Random.Range(-maxPlatformSpawnEdge, -maxPlatformSpawnCenter), y - Random.Range(0, 2) * 0.4f, 1);
                }
                else
                {
                    maxPlatformSpawnEdge = 6;
                    maxPlatformSpawnCenter = -6;
                }

                GameObject c = Instantiate(platformPrefab) as GameObject;
                c.transform.position = new Vector3(Random.Range(maxPlatformSpawnEdge, maxPlatformSpawnCenter), y - Random.Range(0, 2) * 0.4f, 1);

                y = y + 3;
                spawnPosY = y;
            }
            spawnPosMax = spawnPosY + 9;
        }
    }
}