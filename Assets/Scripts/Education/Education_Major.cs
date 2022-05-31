using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Education_Major : Education
{
    public int daysTrainedEdu;
    public int daysToCompleteEdu;
    public int degreeLevelEdu;
    public string degreeLevelNameEdu;

    public EduData myEduData;

    private void Start()
    {
        
    }

    public override void onClickStartEducation()
    {
        base.onClickStartEducation();
        degreeLevelNameEdu = AssignDegreeLevelName(daysTrainedEdu);
        degreeLevelEdu = AssignDegreeLevel(daysTrainedEdu);
        daysToCompleteEdu = DaysLeftToNextDegree(degreeLevelEdu, daysTrainedEdu);
        message.text = "Current Degree: " + degreeLevelNameEdu + "\n" + "Days trained: " + daysTrainedEdu + "\n" +  "Days to next degree: " + daysToCompleteEdu;
        confirmButtonText.text = degreeCost.ToString();
        AssignMyEduData();
    }

    public override void onClickEducation()
    {
        Debug.Log("education clicked");
        PurchaseEducation(degreeCost);
        degreeLevelNameEdu = AssignDegreeLevelName(daysTrainedEdu);
        degreeLevelEdu = AssignDegreeLevel(daysTrainedEdu);
        daysToCompleteEdu = DaysLeftToNextDegree(degreeLevelEdu, daysTrainedEdu);
        #region Test logs
        //Debug.Log("law school days trained: " + daysTrainedLaw);
        //Debug.Log("degree level name in onclick education for law is:" + degreeLevelName);
        //Debug.Log("degree level in onclick education for law is:" + degreeLevel);
        #endregion
        uIPurchaseEducation.PurchaseEducation(degreeLevelNameEdu, daysTrainedEdu);
        message.text = "Current Degree: " + degreeLevelNameEdu 
            + "\n" + "Days trained: " + daysTrainedEdu 
            + "\n" + "Days to next degree: " + daysToCompleteEdu;
        AssignMyEduData();
    }

    public override void AddDaystoEducation()
    {
        daysTrainedEdu++;
        Debug.Log("Days trained on education degree: " + daysTrainedEdu);
    }

    public void AssignMyEduData()
    {
        myEduData.daysTrainedEdu = daysTrainedEdu;
        myEduData.degreeCostEdu = degreeCost;
        myEduData.degreeLevelEdu = degreeLevelEdu;
        myEduData.degreeLevelNameEdu = degreeLevelNameEdu;
    }

    public void AssignMyEduSavedData()
    {
        daysTrainedEdu = myEduData.daysTrainedEdu;
        if (myEduData.daysTrainedEdu == 0)
        {
            myEduData.degreeCostEdu = degreeCost;
        }
        else
        {
            degreeCost = myEduData.degreeCostEdu;
        }
        degreeLevelEdu = myEduData.degreeLevelEdu;
        degreeLevelNameEdu = myEduData.degreeLevelNameEdu;
    }

    public void AssignEduDegree(int degreeLevelEdu)
    {
        switch (degreeLevelEdu)
        {
            case 1:
                BachelorEdu = true;
                break;
            case 2:
                MasterEdu = true;
                break;
            case 3:
                PHDEdu = true;
                break;
            default:
                break;
        }
    }
    #region IDegrees
    //public void AddDegreeLevel(List<string> myList)
    //{
    //    myList.Add("Medicine Degree: " + degreeLevelNameEdu);
    //    Debug.Log(degreeLevelNameEdu + " added.");
    //}

    //public void PrintDegreeLevels(string degree)
    //{
    //    degree = degreeLevelNameEdu;
    //    Debug.Log(degreeLevelNameEdu);
    //}
    #endregion
}
