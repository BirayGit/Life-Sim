using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Game Manager instance is null");
            }
            return instance;
        }
    }
    public Medicine_Major medicine;
    public LawSchool_Major law;
    public ComputerScience_Major cS;
    public Education_Major edu;
    public CulinaryArts_Major cula;

    private void Awake()
    {
        instance = this;

        medicine.AssignMyMedicineSavedData();
        medicine.degreeLevelMed = medicine.AssignDegreeLevel(medicine.daysTrainedMed);
        medicine.degreeLevelNameMed = medicine.AssignDegreeLevelName(medicine.daysTrainedMed);
        medicine.AssignMedicalDegree(medicine.degreeLevelMed);
        EducationUI.Instance.PrintDegreeLevelNameMed();

        law.AssignMyLawSavedData();
        law.degreeLevelLaw = law.AssignDegreeLevel(law.daysTrainedLaw);
        law.degreeLevelNameLaw = law.AssignDegreeLevelName(law.daysTrainedLaw);
        law.AssignLawDegree(law.degreeLevelLaw);
        EducationUI.Instance.PrintDegreeLevelNameLaw();

        cS.AssignMyCSSavedData();
        cS.degreeLevelCS = cS.AssignDegreeLevel(cS.daysTrainedCS);
        cS.degreeLevelNameCS = cS.AssignDegreeLevelName(cS.daysTrainedCS);
        cS.AssignCSDegree(cS.degreeLevelCS);
        EducationUI.Instance.PrintDegreeLevelNameCS();

        edu.AssignMyEduSavedData();
        edu.degreeLevelEdu = edu.AssignDegreeLevel(edu.daysTrainedEdu);
        edu.degreeLevelNameEdu = edu.AssignDegreeLevelName(edu.daysTrainedEdu);
        edu.AssignEduDegree(edu.degreeLevelEdu);
        EducationUI.Instance.PrintDegreeLevelNameEdu();

        cula.AssignMyCulaSavedData();
        cula.degreeLevelCula = cula.AssignDegreeLevel(cula.daysTrainedCula);
        cula.degreeLevelNameCula = cula.AssignDegreeLevelName(cula.daysTrainedCula);
        cula.AssignCulaDegree(cula.degreeLevelCula);
        EducationUI.Instance.PrintDegreeLevelNameCula();
    }
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
