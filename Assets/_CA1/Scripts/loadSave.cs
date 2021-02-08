using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("gameManager").GetComponent<DataManager>().Read();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
