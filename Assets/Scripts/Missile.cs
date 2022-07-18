using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private int damage;

    void Awake()
    {
        damage = 50;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("city"))
        {
            Debug.Log("missile hit a city!");
            collision.gameObject.GetComponent<City>().SubtractHealth(damage);
            //TODO - spawn explosion particle effect
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("mouseCollider"))
        {
            Debug.Log("You tickled a missile!");
        } else
        {
            if (collision.gameObject.CompareTag("missile"))
            {
                Debug.Log("missile on missile!");

            } else if (collision.gameObject.CompareTag("shield"))
            {
                Debug.Log("missile hit a shield!");

            } else {
                Debug.Log("missile hit something else!");
                //TODO - spawn explosion particle effect
                Destroy(gameObject);
            }
        }
    }
}
