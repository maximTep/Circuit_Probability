using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class CreateElement : MonoBehaviour
{
	public Button button;
	public GameObject elementPrefab;
	public GameObject elements;
	private bool isBtnClicked = false;

	void Start()
	{
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
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
    }

	private void mouseCheck(){
		if(!Input.GetMouseButtonDown(0)) return;
		if(!isBtnClicked) return;
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		createEl(worldPos.x / elements.transform.parent.transform.localScale.x, worldPos.y / elements.transform.parent.transform.localScale.y);
		isBtnClicked = false;
	}

}
