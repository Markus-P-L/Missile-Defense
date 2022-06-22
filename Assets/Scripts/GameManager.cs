using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameAreaX = 16;
    public float numberOfCities = 4;
    private int score = 0;

    private float missileSpawnRate;
    private float missileSpawnTimer;
    public GameObject City;
    public GameObject Missile;
    public Text scoreText;

    void Awake()
    {
        gameAreaX = gameAreaX - gameAreaX % numberOfCities;

        missileSpawnRate = 3.0f;
        missileSpawnTimer = missileSpawnRate;

        for (int i = 0; i < 4; i++)
        {
            Instantiate(City, new Vector3(-gameAreaX / 2 + Random.Range(0 + 1, gameAreaX / numberOfCities - 1) + i * (gameAreaX / numberOfCities), 0, 0), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (missileSpawnTimer > 0)
        {
            missileSpawnTimer -= Time.deltaTime;
        } else
        {
            Instantiate(Missile, new Vector3(Random.Range(-gameAreaX / 2, gameAreaX / 2), 10, 0), transform.rotation);
            missileSpawnTimer = missileSpawnRate;
        }
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
}
