using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private bool powerOn = false;
    private int deflectionScore = 100;
    private float shieldPowerMax = 2.0f;
    private float shieldPower;

    public GameManager gameManager;
    private Material material;

    public void Awake()
    {
        shieldPower = shieldPowerMax;
        material = GetComponent<Renderer>().material;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (powerOn)
        {
            if (shieldPower < shieldPowerMax)
            {
                shieldPower += Time.deltaTime;
                material.color = new Color(material.color.r, material.color.g, material.color.b, shieldPower / shieldPowerMax);
            }
        } else
        {
            if (shieldPower > 0)
            {
                shieldPower -= Time.deltaTime;
                material.color = new Color(material.color.r, material.color.g, material.color.b, shieldPower / shieldPowerMax);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mouseCollider")) powerOn = true;

        if (other.CompareTag("missile") && shieldPower > shieldPower / 2)
        {
            gameManager.UpdateScore(deflectionScore);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("mouseCollider")) powerOn = false;
    }

    public void SetShieldPowerMax(float value)
    {
        shieldPowerMax = value;
    }
}