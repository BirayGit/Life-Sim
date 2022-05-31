using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationData
{
    public int degreeCost;
    public int daysTrainedMed;
    public int daysTrainedLaw;
    public string degreeLevelMed;
    public string degreeLevelLaw;

    public EducationData (Education education)
    {
        degreeCost = education.degreeCost;
        daysTrainedMed = education.daysTrained;
        
    }
}
