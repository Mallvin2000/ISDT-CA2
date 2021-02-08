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
    public bool wetFloorSignCompleted;
    public bool safetyHarnessCompleted;
    public bool wiresCompleted;
    // Start is called before the first frame update
    void Start()
    {
        
        // Debug.Log(ActData.wetFloorSignCompleted);
        //Save();
        //Read();
    }

    public void getDataToSave()
    {
        wetFloorSignCompleted = GameObject.Find("Clipboard").GetComponent<TickChecker>().Check1;
        safetyHarnessCompleted = GameObject.Find("Clipboard").GetComponent<TickChecker>().Check2;
        wiresCompleted = GameObject.Find("Clipboard").GetComponent<TickChecker>().Check3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        getDataToSave();
        string path = "Assets/test.txt";
        string json = "{\"wetFloorSignCompleted\":\""+wetFloorSignCompleted+"\",\"safetyHarnessCompleted\":\""+safetyHarnessCompleted+"\",\"wiresCompleted\":\""+wiresCompleted+"\"}";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine();
        writer.WriteLine(JsonUtility.ToJson(this));
        writer.Close();
    }

    public void Read()
    {
          string path = "Assets/test.txt";
           string line;
           List<string> Lines = new List<string>();

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        //string json = reader.ReadToEnd();

        //store all lines in txt file in list
        while ((line = reader.ReadLine()) != null)
        {
            //Debug.Log(line);
            Lines.Add(line);
        }
        //get last line in list for the latest save
        int i = Lines.Count - 1;
        string json = Lines[i];
        //Debug.Log(i);
        //Debug.Log(Lines[i]);

        string[] toPush;
        List<string> boolInfo = new List<string>();
        boolInfo = json.Split(',').ToList();
        List<string> WetFloorRead = new List<string>();
        List<string> SafetyHarnessRead = new List<string>();
        List<string> WiresRead = new List<string>();
        
        //read the key in the json file and convert to boolean
        WetFloorRead = boolInfo[0].Split(':').ToList();
        //converting to boolean
        string stringName = WetFloorRead[1];
        bool wetFloorBool = Convert.ToBoolean(stringName);
        //Debug.Log(wetFloorBool);

        SafetyHarnessRead = boolInfo[1].Split(':').ToList();
        //converting to boolean
        string stringName2 = SafetyHarnessRead[1];
        bool safteyHarnessBool = Convert.ToBoolean(stringName2);
        //Debug.Log(safteyHarnessBool);

        WiresRead = boolInfo[2].Split(':').ToList();
        List<string> WiresReadFinal = new List<string>();
        WiresReadFinal = WiresRead[1].Split('}').ToList();
        //converting to boolean
        string stringName3 = WiresReadFinal[0];
        //Debug.Log(stringName3);
        bool wiresBool = Convert.ToBoolean(stringName3);
        //Debug.Log(wiresBool);

        reader.Close();

        loadSavedData(wetFloorBool, safteyHarnessBool, wiresBool);

    }

   

    public void  loadSavedData(bool wetFloorBool, bool safteyHarnessBool, bool wiresBool)
    {
       //set the ticks on clipboard to what they were when the game was saved
        GameObject.Find("Clipboard").GetComponent<TickChecker>().Check1 = wetFloorBool;
        if (wetFloorBool == true)
        {
            GameObject.Find("Clipboard").GetComponent<TickChecker>().enableTick("wetFloorSign");
            GameObject.Find("gameManager").GetComponent<gameManager>().setWetFloorSignToPass();
        }

        GameObject.Find("Clipboard").GetComponent<TickChecker>().Check2 = safteyHarnessBool;
        if (safteyHarnessBool == true)
        {
            GameObject.Find("Clipboard").GetComponent<TickChecker>().enableTick("safetyHarness");
            GameObject.Find("gameManager").GetComponent<gameManager>().setSafteyHarnessToPass();
        }

        GameObject.Find("Clipboard").GetComponent<TickChecker>().Check3 = wiresBool;
        if (wiresBool == true)
        {
            GameObject.Find("Clipboard").GetComponent<TickChecker>().enableTick("wires");
            GameObject.Find("gameManager").GetComponent<gameManager>().setWiresToPass();
        }
    }
}

