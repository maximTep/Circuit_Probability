using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenManual : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openManual()
    {
        Application.OpenURL(System.Environment.CurrentDirectory + "/CircuitProbability_Manual.chm");
    }

}
