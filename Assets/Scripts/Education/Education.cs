using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Education : MonoBehaviour
{
    private static Education instance;
    public static Education Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Education instance is null");
            }
            return instance;
        }
    }

    #region IDegrees
    //private IDegrees degreeLevelMed;
    //private IDegrees degreeLevelLaw;
    //private IDegrees degreeLevelCS;
    //private IDegrees degreeLevelEdu;
    //private IDegrees degreeLevelCula;


    List<IDegrees> supportedDegrees = new List<IDegrees>();
    #endregion

    protected Player player;
    protected int playerMoney;
    [SerializeField]
    protected List<int> Degrees = new List<int>() { 0, 0, 0, 0, 0 };
    public List<int> CombinedDegrees = new List<int>() { 0, 0, 0, 0, 0 };


    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<Player>();
        playerMoney = player.GetMoney();

        degreeBMed = "Medicine: Bachelor's Degree";
        degreeMMed = "Medicine: Master's Degree";
        degreePHDMed = "Medicine: PHD";

        degreeBLaw = "Law: Bachelor's Degree";
        degreeMLaw = "Law: Master's Degree";
        degreePHDLaw = "Law: PHD";

        degreeBCS = "Computer Science: Bachelor's Degree";
        degreeMCS = "Computer Science: Master's Degree";
        degreePHDCS = "Computer Science: PHD";

        degreeBEdu = "Education: Bachelor's Degree";
        degreeMEdu = "Education: Master's Degree";
        degreePHDEdu = "Education: PHD";

        degreeBCula = "Culinary: Bachelor's Degree";
        degreeMCula = "Culinary: Master's Degree";
        degreePHDCula = "Culinary: PHD";


        #region IDegrees
        //Medicine_Major degreeLevelMed = new Medicine_Major();
        //supportedDegrees.Add(degreeLevelMed);

        //LawSchool_Major degreeLevelLaw = new LawSchool_Major();
        //supportedDegrees.Add(degreeLevelLaw);

        //ComputerScience_Major degreeLevelCS = new ComputerScience_Major();
        //supportedDegrees.Add(degreeLevelCS);

        //Education_Major degreeLevelEdu = new Education_Major();
        //supportedDegrees.Add(degreeLevelEdu);

        //CulinaryArts_Major degreeLevelCula = new CulinaryArts_Major();
        //supportedDegrees.Add(degreeLevelCula);


        //foreach (var supportedDegree in supportedDegrees)
        //{
        //    supportedDegree.PrintDegreeLevels(supportedDegree.ToString());
        //}
        #endregion
    }

    //protected int multiplier = 1; 

    protected int daysToComplete;
    [HideInInspector]
    public int daysTrained;
    protected bool isCompleted;

    public int degreeCost;
    protected int degreeLevel, degreeLevelMedInEducation, degreeLevelLawInEducation;
    public string degreeLevelName { get; set; }
    protected int degreeType;
    public string degreeTypeName;

    public string degreeBMed, degreeMMed, degreePHDMed,
        degreeBLaw, degreeMLaw, degreePHDLaw,
        degreeBCS, degreeMCS, degreePHDCS,
        degreeBEdu, degreeMEdu, degreePHDEdu,
        degreeBCula, degreeMCula, degreePHDCula;

    public bool BachelorMed, MasterMed, PHDMed,
       BachelorLaw, MasterLaw, PHDLaw,
       BachelorCS, MasterCS, PHDCS,
       BachelorEdu, MasterEdu, PHDEdu,
       BachelorCula, MasterCula, PHDCula;

    public List<Education> Requirements;

    public UIPurchaseEducation uIPurchaseEducation;

    public GameObject educationDialog;
    public Vector3 panelVector;
    public TextMeshProUGUI Title, confirmButtonText, message;

    
    private void Start()
    {
        
        
    }

    public void PurchaseEducation(int degreeCost)
    {
        //AssignEducationType(degreeType);
        Debug.Log("Degree type is: " + degreeType);
        Debug.Log("Player money is:" + playerMoney);
        Debug.Log("Degree cost is: " + degreeCost);
        if (playerMoney >= degreeCost)
        {
            Debug.Log("Degree level name inside purchase education method is: " + degreeLevelName);
            //Debug.Log("Education type : " + degreeType +  "purchased");
            Debug.Log("Money cost is: " + degreeCost);
            player.SetMoney(degreeCost);
            playerMoney = player.GetMoney();
            UIManager.Instance.UpdateMoney(playerMoney);
            Debug.Log("player money is set as: " + playerMoney + " after purchase.");
            Debug.Log("Player money is:" + playerMoney);
            AddDaystoEducation();

            if (daysToComplete == 0)
            {
                isCompleted = true;
            }
        }
        else
        {
            Debug.Log("Not enough money");
        }

    }

    #region AssignEducationType
    //public void AssignEducationType(int ItemID)
    //{
    //    if (ItemID == 0)
    //    {
    //        degreeCost = 200;
    //        degreeType = 0;
    //        degreeTypeName = "Medicine";
    //        Debug.Log("Degree type name is: " + degreeTypeName);
    //        uIPurchaseEducation.Title.text = degreeTypeName;
    //        uIPurchaseEducation.OpenEducationDialog();
    //    }
    //    else if (ItemID == 1)
    //    {
    //        degreeCost = 150;
    //        degreeType = 1;
    //        degreeTypeName = "Law School";
    //        Debug.Log("Degree type name is: " + degreeTypeName);
    //        uIPurchaseEducation.Title.text = degreeTypeName;
    //        uIPurchaseEducation.OpenEducationDialog();
    //    }
    //    else if (ItemID == 2)
    //    {
    //        degreeCost = 100;
    //        degreeType = 2;
    //        degreeTypeName = "Computer Science";
    //        Debug.Log("Degree type name is: " + degreeTypeName);
    //        uIPurchaseEducation.Title.text = degreeTypeName;
    //        uIPurchaseEducation.OpenEducationDialog();
    //    }
    //    else if (ItemID == 3)
    //    {
    //        degreeCost = 100;
    //        degreeType = 3;
    //        degreeTypeName = "Education";
    //        Debug.Log("Degree type name is: " + degreeTypeName);
    //        uIPurchaseEducation.Title.text = degreeTypeName;
    //        uIPurchaseEducation.OpenEducationDialog();
    //    }
    //    else if (ItemID == 4)
    //    {
    //        degreeCost = 100;
    //        degreeType = 4;
    //        degreeTypeName = "Culinary Arts";
    //        Debug.Log("Degree type name is: " + degreeTypeName);
    //        uIPurchaseEducation.Title.text = degreeTypeName;
    //        uIPurchaseEducation.OpenEducationDialog();
    //    }
    //    else
    //    {
    //        Debug.Log("Assign education type again");
    //    }
    //}
    #endregion

    #region AssignEducationType switch
    //public void AssignEducationType(int ItemID)
    //{
    //    Debug.Log("Degree type on AssingEducationType is: " + ItemID);
    //    // 0 = Medicine, 1 = Law School, 2 = Computer Science, 3 = Education, 4 = Culinary Arts
    //    switch (ItemID)
    //    {
    //        case 0:
    //            degreeCost = 200;
    //            degreeType = 0;
    //            degreeTypeName = "Medicine";
    //            Debug.Log("Degree type name is: " + degreeTypeName);
    //            uIPurchaseEducation.Title.text = degreeTypeName;
    //            uIPurchaseEducation.OpenEducationDialog();
    //            break;
    //        case 1:
    //            degreeCost = 150;
    //            degreeType = 1;
    //            degreeTypeName = "Law School";
    //            Debug.Log("Degree type name is: " + degreeTypeName);
    //            uIPurchaseEducation.Title.text = degreeTypeName;
    //            uIPurchaseEducation.OpenEducationDialog();
    //            break;
    //        case 2:
    //            degreeCost = 100;
    //            degreeType = 2;
    //            degreeTypeName = "Computer Science";
    //            Debug.Log("Degree type name is: " + degreeTypeName);
    //            uIPurchaseEducation.Title.text = degreeTypeName;
    //            uIPurchaseEducation.OpenEducationDialog();
    //            break;
    //        case 3:
    //            degreeCost = 100;
    //            degreeType = 3;
    //            degreeTypeName = "Education";
    //            Debug.Log("Degree type name is: " + degreeTypeName);
    //            uIPurchaseEducation.Title.text = degreeTypeName;
    //            uIPurchaseEducation.OpenEducationDialog();
    //            break;
    //        case 4:
    //            degreeCost = 100;
    //            degreeType = 4;
    //            degreeTypeName = "Culinary Arts";
    //            Debug.Log("Degree type name is: " + degreeTypeName);
    //            uIPurchaseEducation.Title.text = degreeTypeName;
    //            uIPurchaseEducation.OpenEducationDialog();
    //            break;
    //        default:
    //            Debug.Log("assign degree type again");
    //            break;
    //    }
    //}
    #endregion

    public string AssignDegreeLevelName(int daysTrained)
    {
        if (daysTrained < 400)
        {
            degreeLevelName = "No degree";
        }
        else if ((400 <= daysTrained) && (daysTrained < 600))
        {
            degreeLevelName = "Bachelor's Degree";
        }
        else if ((600 <= daysTrained) && (daysTrained < 900))
        {
            degreeLevelName = "Master's Degree";
        }
        else if (900 <= daysTrained)
        {
            degreeLevelName = "PhD";
        }
        return degreeLevelName;
    }

    public int AssignDegreeLevel(int daysTrained)
    {
        if (daysTrained < 400)
        {
            degreeLevel = 0;
        }
        else if ((400 <= daysTrained) && (daysTrained < 600))
        {
            degreeLevel = 1;
        }
        else if ((600 <= daysTrained) && (daysTrained < 900))
        {
            degreeLevel = 2;
        }
        else if (900 <= daysTrained)
        {
            degreeLevel = 3;
        }
        return degreeLevel;
    }

    public virtual int DaysLeftToNextDegree(int degreeLevel, int daysTrained)
    {
        switch (degreeLevel)
        {
            case 0:
                daysToComplete = 400 - daysTrained;
                return daysToComplete;
            case 1:
                daysToComplete = 600 - daysTrained;
                return daysToComplete;
            case 2:
                daysToComplete = 900 - daysTrained;
                return daysToComplete;
            default:
                Debug.Log("Max degree level");
                return daysToComplete = 0;
        }
    }

    #region AssignDegreeLevel
    //public void AssignDegreeLevel(int daysTrained)
    //{
    //    switch (daysTrained)
    //    {
    //        case 0:
    //            degreeLevel = 0;
    //            degreeLevelName = "No degree";
    //            Debug.Log("No degree");
    //            Debug.Log(degreeLevelName);
    //            break;
    //        case 200:
    //            degreeLevel = 1;
    //            degreeLevelName = "Associate Degree";
    //            Debug.Log("Associate Degree");
    //            Debug.Log(degreeLevelName);
    //            break;
    //        case 400:
    //            degreeLevel = 2;
    //            degreeLevelName = "Bachelor's Degree";
    //            Debug.Log("Bachelor's Degree");
    //            break;
    //        case 600:
    //            degreeLevel = 3;
    //            degreeLevelName = "Master's Degree";
    //            Debug.Log("Master's Degree");
    //            break;
    //        case 900:
    //            degreeLevel = 4;
    //            degreeLevelName = "PhD";
    //            Debug.Log("PhD");
    //            break;
    //        default:
    //            break;
    //    }
    //}
    #endregion

    public virtual void onClickStartEducation()
    {
        AssignDegreeLevelName(daysTrained);
        Title.text = degreeTypeName;
        confirmButtonText.text = degreeCost.ToString();
        educationDialog.SetActive(true);
    }

    public virtual void onClickEducation()
    {
        uIPurchaseEducation.PurchaseEducation(degreeLevelName, daysTrained);
        PrintDegreeLevel();
    }

    public virtual void AddDaystoEducation()
    {
        daysTrained++;
        Debug.Log("Days trained: " + daysTrained);
    }

    public virtual List<int> AddDegree(int degreeLevel, int i)
    {
        Degrees[i] = degreeLevel;
        return Degrees;
    }

    public virtual void PrintDegreeLevel()
    {
        foreach (var degree in CombinedDegrees)
        {
            Debug.Log("Degrees: " + degree);
        }
    }
   
}
