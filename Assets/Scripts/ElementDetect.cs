using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.gameObject.transform.localPosition;
        pos.z = 1f;
        this.gameObject.transform.localPosition = pos;
    }

    void OnMouseDown(){
        Vector3 pos = this.gameObject.transform.localPosition;
        pos.z = 2f;
        this.gameObject.transform.localPosition = pos;
    }
}
