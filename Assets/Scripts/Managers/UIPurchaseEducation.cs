using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPurchaseEducation: MonoBehaviour
{
    public GameObject educationDialog;

    public TextMeshProUGUI Title, confirmButtonText, message;

    public void OpenEducationDialog()
    {
        Education.Instance.AssignDegreeLevelName(Education.Instance.daysTrained);
        //Debug.Log("Current Degree type: " + Education.Instance.degreeTypeName);
        message.text = "Current Degree: " + Education.Instance.degreeLevelName + "\n" + "Days trained: " + Education.Instance.daysTrained;  
        //Debug.Log("current degree on ui: " + Education.Instance.degreeLevelName);
        educationDialog.SetActive(true);
    }

    public void CloseEducationDialogMed()
    {
        educationDialog.SetActive(false);
        EducationUI.Instance.PrintDegreeLevelNameMed();     
    }

    public void CloseEducationDialogLaw()
    {
        educationDialog.SetActive(false);
        EducationUI.Instance.PrintDegreeLevelNameLaw();
    }

   public void CloseEducationDialogCS()
    {
        educationDialog.SetActive(false);
        EducationUI.Instance.PrintDegreeLevelNameCS();
    }

    public void CloseEducationDialogEdu()
    {
        educationDialog.SetActive(false);
        EducationUI.Instance.PrintDegreeLevelNameEdu();
    }

    public void CloseEducationDialogCula()
    {
        educationDialog.SetActive(false);
        EducationUI.Instance.PrintDegreeLevelNameCula();
    }

    public void PurchaseEducation(string degreelevelname, int daystrained)
    {
        message.text = "Current Degree: " + degreelevelname + "\n" + "Days trained: " + daystrained;
    }

  
}
