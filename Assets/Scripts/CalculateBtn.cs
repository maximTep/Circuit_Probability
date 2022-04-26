using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CalculateBtn : MonoBehaviour
{
	public Button button;
    private CircuitGraph globalCircGraph;
    private Text answerField;


    // Start is called before the first frame update
    void Start()
    {
        globalCircGraph = GameObject.Find("CircuitGraph").GetComponent<CircuitGraph>();
        answerField = GameObject.Find("AnswerField").transform.GetChild(1).GetComponent<Text>();
        Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
	{
		answerField.text = "Success probability: " + globalCircGraph.calculateProbability().ToString();
    }
}
