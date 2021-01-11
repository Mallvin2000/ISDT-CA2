using UnityEngine;
using UnityEngine.SceneManagement;

//-----------------------------------------------------------------------------------------------------
//Author: Mallvin Rajamohan
//Description of code: Scene is launched when method is run. This script should be attatched to the play button
//-----------------------------------------------------------------------------------------------------
public class AppPlay : MonoBehaviour
{
   public void PlayScene(string scenename)//used to launch scene when method is called
   {
       Application.LoadLevel (scenename);//name of scene to be launched is put into scenename
   }
}