using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    public void SubtractHealth(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        } else
        {
            //TODO - spawn destroyed city prefab
            gameObject.SetActive(false);
        }
    }
}
