using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Player instance is null");
            }
            return instance;
        }
    }


    public int maxHealth, maxEnergy, maxHunger;
    [SerializeField]
    private int money, health, energy, hunger;
    [HideInInspector]
    public bool isDead, isStarving, isTired;
    public string job;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth = 100;
        energy = maxEnergy = 100;
        hunger = maxHunger = 100;
        Debug.Log("Player money at start is:" + money);
    }

    public int GetMoney()
    {
        return money;
    }

    public void SetMoney(int ammount)
    {
        money -= ammount;
        Debug.Log("money ammount inside set money is: " + money);
    }

    public void GiveSalary(int ammount)
    {
        money += ammount;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int ammount)
    {
        if (health == 0)
        {
            Debug.Log("Not enough health");
            isDead = true;
            return;
        }
        else
        {
            if (health + ammount >= maxHealth)
            {
                health = maxHealth;
            }
            else if (health + ammount <= 0)
            {
                health = 0;
                isDead = true;
            }
            else
            {
                health += ammount;
            }
        }
    }

    public int GetEnergy()
    {
        return energy;
    }

    public void SetEnergy(int ammount)
    {
        if (energy == 0)
        {
            Debug.Log("Not enough energy.");
            isTired = true;
            return;
        }
        else
        {
            if (energy + ammount >= maxEnergy)
            {
                energy = maxEnergy;
            }
            else if (energy + ammount <= 0)
            {
                energy = 0;
                isTired = true;
            }
            else
            {
                energy += ammount;
            }
        } 
    }

    public int GetHunger()
    {
        return hunger;
    }

    public void SetHunger(int ammount)
    {
        if (hunger == 0)
        {
            Debug.Log("Too hungry to work.");
            isStarving = true;
            return;
        }
        else
        {
            if (hunger + ammount >= maxHunger)
            {
                hunger = maxHunger;
            }
            else if (hunger + ammount <= 0)
            {
                hunger = 0;
                isStarving = true;
            }
            else
            {
                hunger += ammount;
            }
        }
        
    }
}
