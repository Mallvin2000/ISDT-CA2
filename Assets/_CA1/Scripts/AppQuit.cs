using UnityEngine;

//-----------------------------------------------------------------------------------------------------
//Author: Mallvin Rajamohan
//Description of code: To exit the application when the method is called. This script is to be attatched to the quit button
//-----------------------------------------------------------------------------------------------------

public class AppQuit : MonoBehaviour {

	public void Exit()//applicatiom is closed when method is called
	{
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
	}
}
