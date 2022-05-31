using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScience_Major : Education
{
    public int daysTrainedCS;
    public int degreeLevelCS;
    public string degreeLevelNameCS;

    public CSData myCSData;

    private void Start()
    {
        
    }

    public override void onClickStartEducation()
    {
        base.onClickStartEducation();
        message.text = "Current Degree: " + degreeLevelNameCS + "\n" + "Days trained: " + daysTrainedCS;
        confirmButtonText.text = degreeCost.ToString();
        AssignMyCSData();
        AssignCSDegree(degreeLevelCS);
    }

    public override void onClickEducation()
    {
        Debug.Log("education clicked");
        PurchaseEducation(degreeCost);
        degreeLevelCS = AssignDegreeLevel(daysTrainedCS);
        degreeLevelNameCS = AssignDegreeLevelName(daysTrainedCS);
        #region Test logs
        //Debug.Log("law school days trained: " + daysTrainedLaw);
        //Debug.Log("degree level name in onclick education for law is:" + degreeLevelName);
        //Debug.Log("degree level in onclick education for law is:" + degreeLevel);
        #endregion
        uIPurchaseEducation.PurchaseEducation(degreeLevelNameCS, daysTrainedCS);
        message.text = "Current Degree: " + degreeLevelNameCS + "\n" + "Days trained: " + daysTrainedCS;
        AssignMyCSData();
        AssignCSDegree(degreeLevelCS);
    }

    public override void AddDaystoEducation()
    {
        daysTrainedCS++;
        Debug.Log("Days trained on law school: " + daysTrainedCS);
    }

    public void AssignMyCSData()
    {
        myCSData.daysTrainedCS = daysTrainedCS;
        myCSData.degreeCostCS = degreeCost;
        myCSData.degreeLevelCS = degreeLevelCS;
        myCSData.degreeLevelNameCS = degreeLevelNameCS;
    }

    public void AssignMyCSSavedData()
    {
        daysTrainedCS = myCSData.daysTrainedCS;
        if (myCSData.degreeCostCS == 0)
        {
            myCSData.degreeCostCS = degreeCost;
        }
        else
        {
            degreeCost = myCSData.degreeCostCS;
        }
        degreeLevelCS = myCSData.degreeLevelCS;
        degreeLevelNameCS = myCSData.degreeLevelNameCS;
    }

    #region IDegrees
    //public void AddDegreeLevel(List<string> myList)
    //{
    //    myList.Add("Medicine Degree: " + degreeLevelNameCS);
    //    Debug.Log(degreeLevelNameCS + " added.");
    //}

    //public void PrintDegreeLevels(string degree)
    //{
    //    degree = degreeLevelNameCS;
    //    Debug.Log(degreeLevelNameCS);
    //}
    #endregion

    public void AssignCSDegree(int degreeLevelCS)
    {
        switch (degreeLevelCS)
        {
            case 1:
                BachelorCS = true;
                break;
            case 2:
                MasterCS = true;
                break;
            case 3:
                PHDCS = true;
                break;
            default:
                break;
        }
    }
}
