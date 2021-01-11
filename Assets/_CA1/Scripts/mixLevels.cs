using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//-----------------------------------------------------------------------------------------------------
//Author: Mallvin Rajamohan
//Description of code: To adjust audio mixer levels through menu with exposed params
//-----------------------------------------------------------------------------------------------------

public class mixLevels : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetMasterLvl(float masterlvl) {
        masterMixer.SetFloat("MasterVol", masterlvl);//set master vol to value of slider
    }

    public void SetBGMLvl(float bgmlvl) {
        masterMixer.SetFloat("BGMVol", bgmlvl);//set background music vol to value of slider
    }
}
