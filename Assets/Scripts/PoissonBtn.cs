using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoissonBtn : MonoBehaviour
{
    public Button button;
    private ElementsScript elementsScript;


    // Start is called before the first frame update
    void Start()
    {
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        elementsScript = GameObject.Find("Elements").GetComponent<ElementsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
	{
		//elementsScript.setPoissonDistribution();
    }
}
