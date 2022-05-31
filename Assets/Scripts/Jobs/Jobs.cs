using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jobs : MonoBehaviour
{
    private Player player;
    private UIManager uIManager;
    protected int playerMoney, playerEnergy, playerHunger;
    [SerializeField]
    protected int energyCost, hungerCost, salary, experience, jobID;
    [SerializeField]
    protected List<Jobs> Requirements;
    protected bool requirementsMet;


    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        uIManager = GameObject.FindObjectOfType<UIManager>();
        playerMoney = player.GetMoney();
        playerEnergy = player.GetEnergy();
        playerHunger = player.GetHunger();
        experience = 0;
    }

    public virtual void Work()
    {
        if (player.isDead)
        {
            Debug.Log("Not enough health to work.");
            return;
        }
        else if (player.isStarving)
        {
            Debug.Log("Too hungry to work.");
            return;
        }
        else if (player.isTired)
        {
            Debug.Log("Not enough energy to work.");
            return;
        }
        else
        {
            player.GiveSalary(salary);
            player.SetEnergy(-energyCost);
            player.SetHunger(-hungerCost);
            experience++;
            uIManager.UpdateMoney(playerMoney);
            uIManager.UpdateVitals();
        }
        
    }

    public virtual void ApplyToJob()
    {
        CheckRequirementsList();
        Debug.Log("Requirements list count is: " + Requirements.Count);
        if (requirementsMet)
        {
            player.job = ConvertJobID(jobID);
            Debug.Log("You got the job: " + player.job);
        }
    }

    public string ConvertJobID(int jobID)
    {
        switch (jobID)
        {
            case 01:
                return "Dishwasher";
            case 02:
                return "Waiter";
            default:
                return "Unemployed";
        }
    }

    public void CheckRequirementsList()
    {
        if (Requirements.Count == 0)
        {
            requirementsMet = true;
        }
        else if (Requirements.Count != 0)
        {
            Debug.Log("Checking requirements.");
            CheckRequirements();
            
        }
    }

    public void CheckRequirements()
    {
        Debug.Log(Requirements[0].ToString());
    }
}
