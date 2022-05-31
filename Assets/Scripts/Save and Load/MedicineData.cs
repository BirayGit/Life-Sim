using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Example Vector 3 struct
//public struct SerializableVector3
//{
//    public float x;
//    public float y;
//    public float z;

//    public Vector3 GetPos()
//    {
//        return new Vector3(x, y, z);
//    }
//}

[System.Serializable]
public class MedicineData
{
    public int degreeCostMed;
    public int daysTrainedMed;
    public int degreeLevelMed;
    public string degreeLevelNameMed;
    
}
