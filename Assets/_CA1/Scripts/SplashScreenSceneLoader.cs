using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//-----------------------------------------------------------------------------------------------------
//Author: Mallvin Rajamohan
//Description of code: To Make the splash screen appear with a delay of 5 seconds when the application is launched. This should be set to index 0 during build
//-----------------------------------------------------------------------------------------------------

public class SplashScreenSceneLoader : MonoBehaviour
{
    #region PUBLIC_MEMBERS
    public float loadingDelay = 5.0F;//delay before the splash screen dissapears
    #endregion //PUBLIC_MEMBERS


    #region MONOBEHAVIOUR_METHODS
    void Start()
    {
        StartCoroutine(LoadNextSceneAfter(loadingDelay));
    }
    #endregion //MONOBEHAVIOUR_METHODS


    #region PRIVATE_METHODS
    private IEnumerator LoadNextSceneAfter(float seconds)//Next scene in index 1 position in build is launched after the set delay
    {
        yield return new WaitForSeconds(seconds);

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion //PRIVATE_METHODS
}
