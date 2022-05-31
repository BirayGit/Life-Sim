using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine_Major : Education
{

    public int daysTrainedMed;
    [HideInInspector]
    public string degreeLevelNameMed;
    public int degreeLevelMed;
    
    
    public MedicineData myMedicineData;
   
    private void Start()
    {
       
    }

    public override void onClickStartEducation()
    {
        base.onClickStartEducation();
        message.text = "Current Degree: " + degreeLevelNameMed + "\n" + "Days trained: " + daysTrainedMed;
        confirmButtonText.text = degreeCost.ToString();
        AssignMyMedicineData();
        AssignMedicalDegree(degreeLevelMed);
       
    }

    public override void onClickEducation()
    {
        PurchaseEducation(degreeCost);
        degreeLevelMed = AssignDegreeLevel(daysTrainedMed);
        degreeLevelNameMed = AssignDegreeLevelName(daysTrainedMed);
        
        #region Test logs
        //Debug.Log("medicine days trained: " + daysTrainedMed);
        //Debug.Log("degree level name in onclick education for medicine is:" + degreeLevelNameMed);
        //Debug.Log("degree level in onclick education for medicine is:" + degreeLevel);
        #endregion
        uIPurchaseEducation.PurchaseEducation(degreeLevelNameMed, daysTrainedMed);
        message.text = "Current Degree: " + degreeLevelNameMed + "\n" + "Days trained: " + daysTrainedMed; //"Days to next degree: " + daysToCompleteMed
        AssignMyMedicineData();
        AssignMedicalDegree(degreeLevelMed);
    }

    public override void AddDaystoEducation()
    {
        daysTrainedMed++;
        Debug.Log("Days trained on medicine: " + daysTrainedMed);
    }

    public void AssignMyMedicineData()
    {
        myMedicineData.daysTrainedMed = daysTrainedMed;
        myMedicineData.degreeCostMed = degreeCost;
        myMedicineData.degreeLevelMed = degreeLevelMed;
        myMedicineData.degreeLevelNameMed = degreeLevelNameMed;
    }

    public void AssignMyMedicineSavedData()
    {
        daysTrainedMed = myMedicineData.daysTrainedMed;
        if (myMedicineData.degreeCostMed == 0)
        {
            myMedicineData.degreeCostMed = degreeCost;
        }
        else
        {
            degreeCost = myMedicineData.degreeCostMed;
        }
        degreeLevelMed = myMedicineData.degreeLevelMed;
        degreeLevelNameMed = myMedicineData.degreeLevelNameMed;
    }

    public void AssignMedicalDegree(int degreeLevelMed)
    {
        switch (degreeLevelMed)
        {
            case 1:
                BachelorMed = true;
                break;
            case 2:
                MasterMed = true;
                break;
            case 3:
                PHDMed = true;
                break;
            default:
                break;
        }
    }

    
    #region IDegrees
    //public void AddDegreeLevel(List<string> myList)
    //{
    //    myList.Add("Medicine Degree: " + degreeLevelNameMed);
    //    Debug.Log(degreeLevelNameMed + " added.");
    //}

    //public void PrintDegreeLevels(string degree)
    //{
    //    degree = degreeLevelNameMed;
    //    Debug.Log(degreeLevelNameMed);
    //}
    #endregion
  
}
