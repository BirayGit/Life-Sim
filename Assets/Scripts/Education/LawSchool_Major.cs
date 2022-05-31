using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawSchool_Major : Education
{
    public int daysTrainedLaw;
    public int degreeLevelLaw;
    public string degreeLevelNameLaw;

    public LawData myLawData;

    private void Start()
    {
        
    }

    public override void onClickStartEducation()
    {
        base.onClickStartEducation();
        message.text = "Current Degree: " + degreeLevelNameLaw + "\n" + "Days trained: " + daysTrainedLaw;
        confirmButtonText.text = degreeCost.ToString();
        AssignMyLawData();
        AssignLawDegree(degreeLevelLaw);
    }

    public override void onClickEducation()
    {
        PurchaseEducation(degreeCost);
        degreeLevelLaw = AssignDegreeLevel(daysTrainedLaw);
        degreeLevelNameLaw = AssignDegreeLevelName(daysTrainedLaw);
        #region Test logs
        //Debug.Log("law school days trained: " + daysTrainedLaw);
        //Debug.Log("degree level name in onclick education for law is:" + degreeLevelName);
        //Debug.Log("degree level in onclick education for law is:" + degreeLevel);
        #endregion
        uIPurchaseEducation.PurchaseEducation(degreeLevelNameLaw, daysTrainedLaw);
        message.text = "Current Degree: " + degreeLevelNameLaw + "\n" + "Days trained: " + daysTrainedLaw;
        AssignMyLawData();
        AssignLawDegree(degreeLevelLaw);
    }

    public override void AddDaystoEducation()
    {
        daysTrainedLaw++;
        Debug.Log("Days trained on law school: " + daysTrainedLaw);
    }

    public void AssignMyLawData()
    {
        myLawData.daysTrainedLaw = daysTrainedLaw;
        myLawData.degreeCostLaw = degreeCost;
        myLawData.degreeLevelLaw = degreeLevelLaw;
        myLawData.degreeLevelNameLaw = degreeLevelNameLaw;
    }

    public void AssignMyLawSavedData()
    {
        daysTrainedLaw = myLawData.daysTrainedLaw;
        if (myLawData.degreeCostLaw == 0)
        {
            myLawData.degreeCostLaw = degreeCost;
        }
        else
        {
            degreeCost = myLawData.degreeCostLaw;
        }
        degreeLevelLaw = myLawData.degreeLevelLaw;
        degreeLevelNameLaw = myLawData.degreeLevelNameLaw;
    }
    #region IDegrees
    //public void AddDegreeLevel(List<string> myList)
    //{
    //    myList.Add("Law Degree: " + degreeLevelNameLaw);
    //    Debug.Log(degreeLevelNameLaw + " added.");
    //}

    //public void PrintDegreeLevels(string degree)
    //{

    //    Debug.Log(degreeLevelNameLaw);
    //}
    #endregion
    public void AssignLawDegree(int degreeLevelLaw)
    {
        switch (degreeLevelLaw)
        {
           
            case 1:
                BachelorLaw = true;
                break;
            case 2:
                MasterLaw = true;
                break;
            case 3:
                PHDLaw = true;
                break;
            default:
                break;
        }
    }

}
