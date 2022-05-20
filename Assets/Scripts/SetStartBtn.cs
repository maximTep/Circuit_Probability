using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class SetStartBtn : MonoBehaviour
{
	public Button button;
	public GameObject startPrefab;
	public GameObject elements;
    private CircuitGraph globalCircGraph;
	private GameObject newElement;
	private bool isBtnClicked = false;
	private bool isInstanted = false;
	

	void Start()
	{
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		globalCircGraph = GameObject.Find("CircuitGraph").GetComponent<CircuitGraph>();
	}

	void Update()
	{
		mouseCheck();
	}

	void TaskOnClick()
	{
		isBtnClicked = true;
    }

	public void setStartEl(int elNum){
		if(!isInstanted)
		{
			newElement = Instantiate(startPrefab) as GameObject;
			isInstanted = true;
		} 
		newElement.transform.SetParent(this.transform.parent, false);
        Vector3 pos = elements.transform.GetChild(elNum).transform.position;
        newElement.transform.position = pos;
		globalCircGraph.setStartEl(elNum);
    }

	private void mouseCheck(){
		if(!Input.GetMouseButtonDown(0)) return;
		if(!isBtnClicked) return;

		if(!isHitElement())  // Miss clicks
        {
            isBtnClicked = false;
            return;
        } 

        if(isHitElement())
        {
            isBtnClicked = false;
			setStartEl(HitElementInd());
        } 

		isBtnClicked = false;
	}

	private Vector3 GetMousePos()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.x /= elements.transform.parent.transform.localScale.x;
        worldPos.y /= elements.transform.parent.transform.localScale.y;
        worldPos.z = 1;
        return worldPos;
    }


	private bool isHitElement()
    {
        return elements.transform.localPosition.z != 1f;
    }

    private int HitElementInd()
    {
        return (int)elements.transform.localPosition.z - 2;
    }

}
