using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;

    public float gameAreaX = 16;
    private float missileSpawnRateStart = 3.0f;
    private float missileSpawnRate;
    private float missileSpawnTimer;
    private float gameTime;
    private float difficultyTimeIncrement = 0.25f;
    private float difficultyIncreaseTreshold = 10.0f;

    public int numberOfCities = 4;
    private int score = 0;
    private int highScore = 0;
    private int citiesAlive;
    private int missilesDeflected = 0;
    private int difficultyLevel = 0;
    private int difficultyTimeLevel = 0;
    private int missileDeflectTreshold = 5;

    public GameObject City;
    public GameObject Missile;
    public GameObject GameOverScreen;
    public Text scoreText;

    void Awake()
    {
        gameAreaX = gameAreaX - gameAreaX % numberOfCities;

        missileSpawnRate = missileSpawnRateStart;
        missileSpawnTimer = missileSpawnRate;

        for (int i = 0; i < 4; i++)
        {
            Instantiate(City, new Vector3(-gameAreaX / 2 + Random.Range(0 + 1, gameAreaX / numberOfCities - 1) + i * (gameAreaX / numberOfCities), 0, 0), transform.rotation);
        }

        citiesAlive = numberOfCities;
        gameTime = 0.0f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            gameTime += Time.deltaTime;

            difficultyTimeLevel = (int) (gameTime / difficultyIncreaseTreshold);

            if (missileSpawnTimer > 0)
            {
                missileSpawnTimer -= Time.deltaTime;
            } else
            {
                Instantiate(Missile, new Vector3(Random.Range(-gameAreaX / 2, gameAreaX / 2), 10, 0), transform.rotation);

                missileSpawnRate = difficultyTimeIncrement >= missileSpawnRateStart - difficultyTimeIncrement * (difficultyLevel + difficultyTimeLevel)
                    ? difficultyTimeIncrement
                    : missileSpawnRateStart - difficultyTimeIncrement * (difficultyLevel + difficultyTimeLevel);

                missileSpawnTimer = missileSpawnRate;
            }
        }
    }

    public void UpdateScore(int value)
    {
        score += value / ((numberOfCities - citiesAlive) == 0 ? (numberOfCities - citiesAlive) : 1);
        scoreText.text = "Score: " + score;
    }

    public void OnCityDeath()
    {
        citiesAlive -= 1;

        if (citiesAlive <= 0)
        {
            isGameOver = true;
            scoreText.gameObject.SetActive(false);

            if (highScore < score)
            {
                highScore = score;
                MainManager.Instance.highScore = score;
                MainManager.Instance.SaveHighScore();
            }

            GameOverScreen.GetComponentInChildren<Text>().text = "Score:" + "\n" + score + "\nHigh Score:\n" + highScore;
            GameOverScreen.SetActive(true);
        }
    }

    public void OnMissileDeflect()
    {
        missilesDeflected++;

        if (missilesDeflected % missileDeflectTreshold == 0)
        {
            difficultyLevel++;
        }
    }
}
