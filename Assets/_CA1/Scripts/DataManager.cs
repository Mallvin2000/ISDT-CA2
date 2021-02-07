using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

public class DataManager : MonoBehaviour
{
    //public ActData ActData;
    //saving game mechanic completion data
    public bool wetFloorSignCompleted = GameObject.Find("clipboard").GetComponent<TickChecker>().Check1;
    public bool safetyHarnessCompleted = GameObject.Find("clipboard").GetComponent<TickChecker>().Check2;
    public bool wiresCompleted = GameObject.Find("clipboard").GetComponent<TickChecker>().Check3;
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(ActData.wetFloorSignCompleted);
        //Save();
        Read();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        string path = "Assets/test.txt";
        string json = "{\"wetFloorSignCompleted\":\""+wetFloorSignCompleted+"\",\"safetyHarnessCompleted\":\""+safetyHarnessCompleted+"\",\"wiresCompleted\":\""+wiresCompleted+"\"}";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(JsonUtility.ToJson(this));
        writer.Close();
    }

    public void Read()
    {
          string path = "Assets/test.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path); 
        //Debug.Log(reader.ReadToEnd());
        string json = reader.ReadToEnd();
        //string[] words = json.Split(',');
        //string[] boolInfo;
        string[] toPush;
        List<string> boolInfo = new List<string>();
        boolInfo = json.Split(',').ToList();
        List<string> WetFloorRead = new List<string>();
        List<string> SafetyHarnessRead = new List<string>();
        List<string> WiresRead = new List<string>();
        
        WetFloorRead = boolInfo[0].Split(':').ToList();
        Debug.Log(WetFloorRead[1]);

        //JsonUtility.FromJson<ActData>(json);
        reader.Close();
        //Debug.Log(ActData.wetFloorSignCompleted);
    }
}


[System.Serializable]
public class ActData
{
    public bool wetFloorSignCompleted = true;
    public bool safetyHarnessCompleted;
    public bool wiresCompleted;
}
