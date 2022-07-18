using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    private int health;

    public GameManager gameManager;

    public void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        health = 100;
    }

    public void SubtractHealth(int damage)
    {
        if (health > 0)
        {
            health -= damage;

            if (health <= 0)
            {
                gameManager.OnCityDeath();
                gameObject.SetActive(false);
            }
        } 
    }
}
