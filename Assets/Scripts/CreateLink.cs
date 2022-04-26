using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CreateLink : MonoBehaviour
{
    public Button button;
    public GameObject linkPrefab;
	public GameObject links;
    public GameObject elements;
    private CircuitGraph globalCircGraph;
	private bool isBtnClicked = false;
    private bool isLnkStarted = false;
    private List<Vector3> points = new List<Vector3>();
    private List<List<int>> circuitGraph = new List<List<int>>();
    private int fromEl = -1;
    private int toEl = -1;

	void Start()
	{
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        globalCircGraph = GameObject.Find("CircuitGraph").GetComponent<CircuitGraph>();
        foreach (Transform child in elements.transform) circuitGraph.Add(new List<int>());  // Init graph
	}

	void Update()
	{
		MouseCheck();


        int countDif = elements.transform.childCount - circuitGraph.Count;
        for(int i = 0; i< countDif; i++) circuitGraph.Add(new List<int>());  // Update graph;
        for(int i = 0; i< countDif; i++) globalCircGraph.values.Add(1f);  // Update values list;
        globalCircGraph.graph = circuitGraph;
	}

	void TaskOnClick()
	{
		isBtnClicked = true;
    }

	private void MouseCheck()
    {
		if(!Input.GetMouseButtonDown(0)) return;
		if(!isBtnClicked) return;
        if(!isHitElement() && !isLnkStarted)  // Miss clicks
        {
            isBtnClicked = false;
            return;
        } 

        
        if(isHitElement() && !isLnkStarted)  // Start link
        {
            fromEl = HitElementInd();
            isLnkStarted = true;
            points.Add(GetMousePos());
            return;
        }
        
		
        Vector3 worldPos = GetMousePos();
		points.Add(worldPos);
        DrawLine(points[points.Count-2], points[points.Count-1]);

        if(isHitElement())  // End link
        {
            isBtnClicked = false;
            isLnkStarted = false;
            toEl = HitElementInd();
            circuitGraph[fromEl].Add(toEl);
            globalCircGraph.graph = circuitGraph;
            //globalCircGraph.printGraph();
            //globalCircGraph.printValues();
        } 
	}

    private Vector3 GetMousePos()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.x /= links.transform.parent.transform.localScale.x;
        worldPos.y /= links.transform.parent.transform.localScale.y;
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


    private void DrawLine(Vector3 start, Vector3 end)
    {  
        GameObject newLink = Instantiate(linkPrefab) as GameObject;
		newLink.transform.SetParent(links.transform, false);
        Vector3 pos = start + (end - start)/2;
        pos.z = 2;
        newLink.transform.localPosition = pos;
        Vector3 scale = newLink.transform.localScale;
        scale.x = (start - end).magnitude;
        newLink.transform.localScale = scale;
        float angle = Vector3.SignedAngle(Vector3.right, start-end, Vector3.forward);
        newLink.transform.Rotate(new Vector3(0, 0, angle));
    }

    



}



public class Pair<T, U> {
    public Pair() {
    }

    public Pair(T first, U second) {
        this.First = first;
        this.Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }
};