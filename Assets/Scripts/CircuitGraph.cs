using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitGraph : MonoBehaviour
{
    public List<List<int>> graph = new List<List<int>>();
    public List<float> values = new List<float>();
    private List<bool> used = new List<bool>();
    private List<bool> isNodeOpen = new List<bool>();
    private List<bool> isNodeClosed = new List<bool>();
    private List<List<int>> reversedGraph = new List<List<int>>();
    private System.Random random = new System.Random();





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public float calculateProbability()
    {
        return calculateAproxProbability(1000);
    }

    public float calculateAproxProbability(int numOfTests)
    {
        int successfullTests = 0;
        for(int i = 0; i< numOfTests; i++)
        {
            if(getRandDfsProb())successfullTests++;
        } 
        return successfullTests*1f/numOfTests;
    }


    private bool getRandDfsProb()
    {
        return dfsHelp(0);
    }

    private bool dfsHelp(int startEl)
    {
        float r = (float)random.NextDouble();
        if (r > values[startEl]) return false;
        if(graph[startEl].Count == 0) return true;
        bool res = false;
        foreach(var el in graph[startEl])
        {   
            res = res || dfsHelp(el);            
        }
        return res;
    }



    
    // EXACT SOLUTION HADNT BEEN FOUND

    // private float calculateFork(List<int> fork)
    // {
    //     if(fork.Count == 0) return 1f;
    //     float res = 1;
    //     foreach (int el in fork)
    //     {
    //         if(used[el]) continue;
    //         used[el] = true;
    //         res *= 1 - (values[el] * calculateFork(graph[el]));
    //     }
    //     return 1 - res;
    // }


    // public float calculateProbability()
    // {
    //     used.Clear();
    //     for(int i = 0; i < values.Count; i++) used.Add(false);
    //     if(graph.Count == 0) return 0;
    //     return values[0] * calculateFork(graph[0]);
    // }

    // private void detectNodes()
    // {
    //     isNodeOpen.Clear();
    //     isNodeClosed.Clear();
    //     for(int i = 0; i < values.Count; i++) isNodeOpen.Add(false);
    //     for(int i = 0; i < values.Count; i++) isNodeClosed.Add(false);
    //     reversedGraph.Clear();
    //     for(int i = 0; i< graph.Count; i++) reversedGraph.Add(new List<int>());
    //     for(int i = 0; i< graph.Count; i++)
    //     {
    //         for(int j = 0; j< graph[i].Count; j++)
    //         {
    //             reversedGraph[j].Add(i);
    //         }
    //     }

    //     for(int i = 0; i< graph.Count; i++) if (graph[i].Count > 1) isNodeOpen[i] = true;
    //     for(int i = 0; i< reversedGraph.Count; i++) if (reversedGraph[i].Count > 1) isNodeClosed[i] = true;


    // }









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
