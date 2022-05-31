using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveManager : MonoBehaviour
{
    private Medicine_Major medicine;
    private LawSchool_Major law;
    private ComputerScience_Major cS;
    private Education_Major edu;
    private CulinaryArts_Major cula;

    // TODO : Check if the save file exists, if not create a file first.

    private void Awake()
    {
        medicine = GameObject.FindObjectOfType<Medicine_Major>();
        law = GameObject.FindObjectOfType<LawSchool_Major>();
        cS = GameObject.FindObjectOfType<ComputerScience_Major>();
        edu = GameObject.FindObjectOfType<Education_Major>();
        cula = GameObject.FindObjectOfType<CulinaryArts_Major>();
        Load();
    }
    public void Save()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Education.dat", FileMode.OpenOrCreate);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, medicine.myMedicineData);
            formatter.Serialize(file, law.myLawData);
            formatter.Serialize(file, cS.myCSData);
            formatter.Serialize(file, edu.myEduData);
            formatter.Serialize(file, cula.myCulaData);
        }
        catch (SerializationException e)
        {
            Debug.LogError("There was an error serializing this data: " + e.Message);
        }
        finally
        {
            file.Close();
            Debug.Log("Saved!");
        }
    }

    public void Load()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Education.dat", FileMode.OpenOrCreate);
        string fileString = Application.persistentDataPath + "/Education.dat";

        Debug.Log("file exists: " + (File.Exists(fileString)));
        Debug.Log("file length is: " + file.Length);

        if (file.Length != 0)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                medicine.myMedicineData = formatter.Deserialize(file) as MedicineData;
                law.myLawData = formatter.Deserialize(file) as LawData;
                cS.myCSData = formatter.Deserialize(file) as CSData;
                edu.myEduData = formatter.Deserialize(file) as EduData;
                cula.myCulaData = formatter.Deserialize(file) as CulaData;
            }
            catch (SerializationException e)
            {
                Debug.LogError("There was an error deserializing this data: " + e.Message);
            }
            finally
            {
                file.Close();
            }
        }
        else
        {
            file.Close();
            Debug.Log("File is empty. Making a new save.");
            Save();
        }

    }

}


