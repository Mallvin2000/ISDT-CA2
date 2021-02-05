using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


//---------------------------------------------------------------------------------
// Author		: Mallvin Rajamohan
// Date  		: 5/2/2021
// Description	: Game manager to manage handling of results and exporting to excel
//---------------------------------------------------------------------------------


public class gameManager : MonoBehaviour
{
    /*private bool wetFloorSignHasPassed = false;
    private bool safteyHarnessHasPassed = false;
    private bool wiresHasPassed = false;*/

    private string wetFloorSignResult = "Fail";
    private string safteyHarnessResult = "Fail";
    private string wiresResult = "Fail";
    public List<string> results = new List<string>();


    public void setWetFloorSignToPass()//when dropzone detects on select enter, set the result to true as the item has entered the snapzone 
    {
        wetFloorSignResult = "Pass";
    }

     public void setSafteyHarnessToPass() 
    {
        safteyHarnessResult = "Pass";
    }

     public void setWiresToPass() 
    {
        wiresResult = "Pass";
    }


    public void compileResults()//run when the user presses the submit button.
    {
        results.Add(wetFloorSignResult);
        results.Add(safteyHarnessResult);
        results.Add(wiresResult);

        GameObject.Find("gameManager").GetComponent<runtimetest2>().endTime = DateTime.Now.ToString("hh:mm:ss tt");
        GameObject.Find("gameManager").GetComponent<runtimetest2>().writeToSheet(results);

         Application.LoadLevel ("Win");
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
