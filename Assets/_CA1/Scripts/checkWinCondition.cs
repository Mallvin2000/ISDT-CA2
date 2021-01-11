using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------
//Author: Mallvin Rajamohan
//Description of code: To check if all taks are completed and then changes scene to the Win scene
//-----------------------------------------------------------------------------------------------------

public class checkWinCondition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkIfAllCompleted()
    {
        if (GameObject.Find("taskList").GetComponent<TickChecker>().Check1 == true)//if task completed
        {
            //Debug.Log(GameObject.Find("taskList").GetComponent<TickChecker>().Check1);
            Application.LoadLevel("Win");//change to win scene
        } else
        {
            Debug.Log("not completed yet");
        }
        
    }
}
