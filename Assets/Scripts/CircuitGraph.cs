using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitGraph : MonoBehaviour
{
    public List<List<int>> graph = new List<List<int>>();
    public List<float> values = new List<float>();






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    
    private float calculateFork(List<int> fork)
    {
        if(fork.Count == 0) return 1f;
        if(fork.Count == 1) return values[fork[0]];  // Not obligatory
        float res = 1;
        foreach (int el in fork)
        {
            res *= 1 - values[el];
        }
        return 1 - res;
    }


    public float calculateProbability()
    {
        if(graph.Count == 0) return 1;
        return values[0] * calculateFork(graph[0]);
    }





    public void printGraph()
    {
        string s = "graph:\n";
        int i = 0;
        foreach(var line in graph)
        {
            s+=(i++).ToString()+": ";
            foreach(var el in line) s += el.ToString() + " ";
            s+="\n";
        }
        Debug.Log(s);
    }

    public void printValues()
    {
        string s = "values:\n";
        foreach(var val in values) s += val.ToString() + " ";
        Debug.Log(s);
    }





}
