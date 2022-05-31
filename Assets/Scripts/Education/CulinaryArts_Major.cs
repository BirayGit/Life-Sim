using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CulinaryArts_Major : Education
{
    public int daysTrainedCula;
    public int degreeLevelCula;
    public string degreeLevelNameCula;

    public CulaData myCulaData;

    private void Start()
    {
        
    }

    public override void onClickStartEducation()
    {
        base.onClickStartEducation();
        message.text = "Current Degree: " + degreeLevelNameCula + "\n" + "Days trained: " + daysTrainedCula;
        confirmButtonText.text = degreeCost.ToString();
        AssignMyCulaData();
    }

    public override void onClickEducation()
    {
        Debug.Log("education clicked");
        PurchaseEducation(degreeCost);
        degreeLevelNameCula = AssignDegreeLevelName(daysTrainedCula);
        #region Test logs
        //Debug.Log("law school days trained: " + daysTrainedLaw);
        //Debug.Log("degree level name in onclick education for law is:" + degreeLevelName);
        //Debug.Log("degree level in onclick education for law is:" + degreeLevel);
        #endregion
        uIPurchaseEducation.PurchaseEducation(degreeLevelNameCula, daysTrainedCula);
        message.text = "Current Degree: " + degreeLevelNameCula + "\n" + "Days trained: " + daysTrainedCula;
        AssignMyCulaData();
        AddDegree(degreeLevelCula, 4);


    }

    public override void AddDaystoEducation()
    {
        daysTrainedCula++;
        Debug.Log("Days trained on law school: " + daysTrainedCula);
    }

    public void AssignMyCulaData()
    {
        myCulaData.daysTrainedCula = daysTrainedCula;
        myCulaData.degreeCostCula = degreeCost;
        myCulaData.degreeLevelCula = degreeLevelCula;
        myCulaData.degreeLevelNameCula = degreeLevelNameCula;
    }

    public void AssignMyCulaSavedData()
    {
        daysTrainedCula = myCulaData.daysTrainedCula;
        if (myCulaData.degreeCostCula == 0)
        {
            myCulaData.degreeCostCula = degreeCost;
        }
        else
        {
            degreeCost = myCulaData.degreeCostCula;
        }
        degreeLevelCula = myCulaData.degreeLevelCula;
        degreeLevelNameCula = myCulaData.degreeLevelNameCula;
    }

    public void AssignCulaDegree(int degreeLevelCula)
    {
        switch (degreeLevelCula)
        {
            case 1:
                BachelorCula = true;
                break;
            case 2:
                MasterCula = true;
                break;
            case 3:
                PHDCula = true;
                break;
            default:
                break;
        }
    }

    #region IDegrees
    //public void AddDegreeLevel(List<string> myList)
    //{
    //    myList.Add("Medicine Degree: " + degreeLevelNameCula);
    //    Debug.Log(degreeLevelNameCula + " added.");
    //}

    //public void PrintDegreeLevels(string degree)
    //{
    //    degree = degreeLevelNameCula;
    //    Debug.Log(degreeLevelNameCula);
    //}
    #endregion
}
