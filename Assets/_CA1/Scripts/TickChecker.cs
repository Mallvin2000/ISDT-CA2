using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//-----------------------------------------------------------------------------------------------------
//Author: Arrashi
//Description of code: When a object enters a snapzone, this script is called to enable the tick on the clipboard
//-----------------------------------------------------------------------------------------------------

public class TickChecker : MonoBehaviour
{

    public Material CompleteMaterial;
    public GameObject Tick1;
    public GameObject Tick2;
    public GameObject Tick3;

    public bool Check1 = false;
    public bool Check2 = false;
    public bool Check3 = false;


    public void enableTick(string zoneName)// enable tick when object enters snapzone
    {
        if (zoneName == "wetFloorSign")
        {
            Debug.Log(zoneName);
            Tick1.GetComponent<MeshRenderer>().material = CompleteMaterial;
            Check1 = true;
        }
    }

    public void checkIfComplete()//when submit button is pressed, check to see if all tasks are completed
    {
        if (Check1 == true)
        {
            Debug.Log("win");
            //Application.LoadLevel("Win");
        }
    }


    private void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
       // checkIfComplete();
    }
}
