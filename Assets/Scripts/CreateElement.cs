using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class CreateElement : MonoBehaviour
{
	public Button button;
	public GameObject elementPrefab;
	public GameObject elements;
	private SetStartBtn startButton;
	private SetEndBtn endButton;
	private bool isBtnClicked = false;

	void Start()
	{
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		startButton = GameObject.Find("SetStartBtn").GetComponent<SetStartBtn>();
		endButton = GameObject.Find("SetEndBtn").GetComponent<SetEndBtn>();
	}

	void Update()
	{
		mouseCheck();
	}

	void TaskOnClick()
	{
		isBtnClicked = true;
    }

	private void createEl(float x, float y){
        GameObject newElement = Instantiate(elementPrefab) as GameObject;
        newElement.transform.position = new Vector3(x, y, 1);
		newElement.transform.SetParent(elements.transform, false);
		newElement.transform.GetChild(2).GetComponent<Text>().text = "" + (elements.transform.childCount - 1);
		if (elements.transform.childCount == 1) startButton.setStartEl(0);
		else if(elements.transform.childCount > 1) endButton.setEndEl(elements.transform.childCount - 1);
    }

	private void mouseCheck(){
		if(!Input.GetMouseButtonDown(0)) return;
		if(!isBtnClicked) return;
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		createEl(worldPos.x / elements.transform.parent.transform.localScale.x, worldPos.y / elements.transform.parent.transform.localScale.y);
		isBtnClicked = false;
	}

}
