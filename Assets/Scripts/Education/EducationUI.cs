using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EducationUI : MonoBehaviour
{
    public GameObject degreePrefab;
    private GameObject medPrefab, lawPrefab, CSPrefab, eduPrefab, culaPrefab;

    public Transform panel;
    public TextMeshProUGUI degreePrefabText;
    private TextMeshProUGUI degreeText, degreeTextMed, degreeTextLaw, degreeTextCS, degreeTextEdu, degreeTextCula, degreeCloneTextMed;

    public bool medPrefabExists, lawPrefabExists, CSPrefabExists, eduPrefabExists, culaPrefabExists;

    public Medicine_Major medicine;
    public LawSchool_Major law;
    public ComputerScience_Major CS;
    public Education_Major edu;
    public CulinaryArts_Major cula;

    private static EducationUI instance;
    public static EducationUI Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("EducationUI instance is null");
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    private void Update()
    {
       
    }

    public string SetDegreeLevelNameMed()
    {
        if (medicine.PHDMed)
        {
            Debug.Log("phd of med");
            return medicine.degreePHDMed;
        }
        else if (medicine.MasterMed)
        {
            Debug.Log("masters of med");
            return medicine.degreeMMed;
        }
        else if (medicine.BachelorMed)
        {
            Debug.Log("bachelor of med");
            return medicine.degreeBMed;
        }
        else
        {
            Debug.Log("No action was taken on print degree med");
            return null;
        }
    }

    public void PrintDegreeLevelNameMed()
    {
        if (SetDegreeLevelNameMed() != null)
        {
            SetMedicinePrefab();
        }
    }

    public string SetDegreeLevelNameLaw()
    {
        if (law.PHDLaw)
        {
            Debug.Log("phd of law");
            return law.degreePHDLaw;
        }
        else if (law.MasterLaw)
        {
            Debug.Log("masters of law");
            return law.degreeMLaw;
        }
        else if (law.BachelorLaw)
        {
            Debug.Log("bachelor of law");
            return law.degreeBLaw;
        }
        else
        {
            Debug.Log("No action was taken on print degree law");
            return null;
        }
    }

    public void PrintDegreeLevelNameLaw()
    {
        if (SetDegreeLevelNameLaw() != null)
        {
            SetLawPrefab();
        }
    }

    public string SetDegreeLevelNameCS()
    {
        if (CS.PHDCS)
        {
            Debug.Log("phd of CS");
            return CS.degreePHDCS;
        }
        else if (CS.MasterCS)
        {
            Debug.Log("masters of CS");
            return CS.degreeMCS;
        }
        else if (CS.BachelorCS)
        {
            Debug.Log("bachelor of CS");
            return CS.degreeBCS;
        }
        else
        {
            Debug.Log("No action was taken on print degree CS");
            return null;
        }
    }

    public void PrintDegreeLevelNameCS()
    {
        if (SetDegreeLevelNameCS()!= null)
        {
            SetCSPrefab();
        }
    }

    public string SetDegreeLevelNameEdu()
    {
        if (edu.PHDEdu)
        {
            Debug.Log("phd of Edu");
            return edu.degreePHDEdu;
        }
        else if (edu.MasterEdu)
        {
            Debug.Log("masters of Edu");
            return edu.degreeMEdu;
        }
        else if (edu.BachelorEdu)
        {
            Debug.Log("bachelor of Edu");
            return edu.degreeBEdu;
        }
        else
        {
            Debug.Log("No action was taken on print degree Edu");
            return null;
        }
    }

    public void PrintDegreeLevelNameEdu()
    {
        if (SetDegreeLevelNameEdu() != null)
        {
            SetEduPrefab();
        }
    }

    public string SetDegreeLevelNameCula()
    {
        if (cula.PHDCula)
        {
            Debug.Log("phd of Cula");
            return cula.degreePHDCula;
        }
        else if (cula.MasterCula)
        {
            Debug.Log("masters of Cula");
            return cula.degreeMCula;
        }
        else if (cula.BachelorCula)
        {
            Debug.Log("bachelor of Cula");
            return cula.degreeBCula;
        }
        else
        {
            Debug.Log("No action was taken on print degree Cula");
            return null;
        }
    }

    public void PrintDegreeLevelNameCula()
    {
        if (SetDegreeLevelNameCula() != null)
        {
            SetCulaPrefab();
        }
       
    }

    private void SetMedicinePrefab()
    {
        if (medPrefabExists)
        {
            GetChild("medPrefab");
        }
        else
        {
            SetPrefab(medPrefab, "medPrefab");
            medPrefabExists = true;
        }
    }

    private void SetLawPrefab()
    {
        if (lawPrefabExists)
        {
            GetChild("lawPrefab");
        }
        else
        {
            SetPrefab(lawPrefab, "lawPrefab");
            lawPrefabExists = true; 
        }
    }

    private void SetCSPrefab()
    {
        if (CSPrefabExists)
        {
            GetChild("CSPrefab");
        }
        else
        {
            SetPrefab(CSPrefab, "CSPrefab");
            CSPrefabExists = true;
        }   
    }

    private void SetEduPrefab()
    {
        if (eduPrefabExists)
        {
            GetChild("eduPrefab");
        }
        else
        {
            SetPrefab(eduPrefab, "eduPrefab");
            eduPrefabExists = true;
        }
    }

    private void SetCulaPrefab()
    {
        if (culaPrefabExists)
        {
            GetChild("culaPrefab");
        }
        else
        {
            SetPrefab(culaPrefab, "culaPrefab");
            culaPrefabExists = true;
        }
    }

    private GameObject SetPrefab(GameObject prefab, string prefabName)
    {
        prefab = Instantiate(degreePrefab, panel.position, Quaternion.identity);
        prefab.transform.SetParent(panel.transform, false);
        prefab.transform.localScale = new Vector3(1, 1, 1);
        prefab.name = prefabName;
        prefab.tag = prefabName;
        SetText(prefab, prefabName);
        return prefab;
    }

    private string SetDegreeLevelName(string degreeType)
    {
        switch (degreeType)
        {
            case "medPrefab":
               return SetDegreeLevelNameMed();
            case "lawPrefab":
                return SetDegreeLevelNameLaw();
            case "CSPrefab":
                return SetDegreeLevelNameCS();
            case "eduPrefab":
                return SetDegreeLevelNameEdu();
            case "culaPrefab":
                return SetDegreeLevelNameCula();
            default:
                return "Invalid value";
        }
    }
    private void SetText(GameObject prefab, string prefabName)
    {
        degreeText = prefab.GetComponent<TextMeshProUGUI>();
        degreeText.text = SetDegreeLevelName(prefabName);
    }

    private void GetChild(string prefab)
    {
        foreach (Transform child in panel)
        {
            if (child.gameObject.CompareTag(prefab))
            {
                TextMeshProUGUI degreeText = child.GetComponent<TextMeshProUGUI>();
                degreeText.text = SetDegreeLevelName(prefab);
            }
        }
    }
}
