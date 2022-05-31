using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("UIManager instance is null");
            }
            return instance;
        }
    }

    public enum State
    {
        Main, Education, Jobs, Work
    }

    public enum JobState
    {
        Entry, Mid, High, Degree
    }

    public State currentState;
    public GameObject MainPanel;
    public GameObject EducationPanel;
    public GameObject JobsPanel;
    public GameObject WorkPanel;

    public JobState currentJobState;
    public GameObject EntryPanel, MidPanel, HighPanel, DegreePanel;

    public TextMeshProUGUI healthText, energyText, hungerText, moneyText;
    public Slider healthBar, energyBar, hungerBar;

    private Player player;
    private int playerHealth, playerEnergy, playerHunger, playerMaxHealth, playerMaxEnergy, playerMaxHunger, playerMoney;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<Player>();
        onClickMain();
    }

    private void Start()
    {
        playerHealth = player.GetHealth();
        playerMaxHealth = player.maxHealth;

        playerEnergy = player.GetEnergy();
        playerMaxEnergy = player.maxEnergy;

        playerHunger = player.GetHunger();
        playerMaxHunger = player.maxHunger;

        playerMoney = player.GetMoney();

        StartGame();

        Debug.Log("player health during start is: " + playerHealth);
    }

    public void StartGame()
    {
 
        healthText.text = playerHealth.ToString() + "/" + playerMaxHealth.ToString();
        energyText.text = playerEnergy.ToString() + "/" + playerMaxEnergy.ToString();
        hungerText.text = playerHunger.ToString() + "/" + playerMaxHunger.ToString();
        moneyText.text = playerMoney.ToString();

        healthBar.value = playerHealth;
        energyBar.value = playerEnergy;
        hungerBar.value = playerHunger;
    }

    public void UpdateMoney(int playerMoney)
    {
        playerMoney = player.GetMoney();
        moneyText.text = playerMoney.ToString();
    }

    public void UpdateDaysToComplete()
    {
       
    }

    public void UpdateHealth()
    {
        playerHealth = player.GetHealth();
        healthBar.value = playerHealth;
        healthText.text = playerHealth.ToString() + "/" + playerMaxHealth.ToString();
    }

    public void UpdateEnergy()
    {
        playerEnergy = player.GetEnergy();
        energyBar.value = playerEnergy;
        energyText.text = playerEnergy.ToString() + "/" + playerMaxEnergy.ToString();
    }

    public void UpdateHunger()
    {
        playerHunger = player.GetHunger();
        hungerBar.value = playerHunger;
        hungerText.text = playerHunger.ToString() + "/" + playerMaxHunger.ToString();
    }

    public void UpdateVitals()
    {
        UpdateHealth();
        UpdateEnergy();
        UpdateHunger();
    }

    void onShowMain()
    {
        currentState = State.Main;
        MainPanel.SetActive(true);
        EducationPanel.SetActive(false);
        JobsPanel.SetActive(false);
        WorkPanel.SetActive(false);
    }

    void onShowEducation()
    {
        currentState = State.Education;
        EducationPanel.SetActive(true);
        MainPanel.SetActive(false);
        JobsPanel.SetActive(false);
        WorkPanel.SetActive(false);
    }

    void onShowJobs()
    {
        currentState = State.Jobs;
        JobsPanel.SetActive(true);
        MainPanel.SetActive(false);
        EducationPanel.SetActive(false);
        WorkPanel.SetActive(false);
    }

    void onShowWork()
    {
        currentState = State.Work;
        WorkPanel.SetActive(true);
        MainPanel.SetActive(false);
        EducationPanel.SetActive(false);
        JobsPanel.SetActive(false);
    }

    void onShowEntry()
    {
        currentJobState = JobState.Entry;
        EntryPanel.SetActive(true);
        MidPanel.SetActive(false);
        HighPanel.SetActive(false);
        DegreePanel.SetActive(false);
    }

    void onShowMid()
    {
        currentJobState = JobState.Mid;
        MidPanel.SetActive(true);
        EntryPanel.SetActive(false);
        HighPanel.SetActive(false);
        DegreePanel.SetActive(false);
    }

    void onShowHigh()
    {
        currentJobState = JobState.High;
        HighPanel.SetActive(true);
        EntryPanel.SetActive(false);
        MidPanel.SetActive(false);
        DegreePanel.SetActive(false);
    }

    void onShowDegree()
    {
        currentJobState = JobState.Degree;
        DegreePanel.SetActive(true);
        EntryPanel.SetActive(false);
        MidPanel.SetActive(false);
        HighPanel.SetActive(false);
    }

    public void onClickMain()
    {
        onShowMain();
    }

    public void onClickEducation()
    {
        onShowEducation();
    }

    public void onClickJobs()
    {
        onShowJobs();
    }

    public void onClickWork()
    {
        onShowWork();
    }

    public void onClickEntry()
    {
        onShowEntry();
    }

    public void onClickMid()
    {
        onShowMid();
    }

    public void onClickHigh()
    {
        onShowHigh();
    }

    public void onClickDegree()
    {
        onShowDegree();
    }
}
