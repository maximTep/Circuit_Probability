using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementsScript : MonoBehaviour
{
    private CircuitGraph globalCircGraph;
    private System.Random random = new System.Random();

    

    // Start is called before the first frame update
    void Start()
    {
        globalCircGraph = GameObject.Find("CircuitGraph").GetComponent<CircuitGraph>();
    }

    // Update is called once per frame
    void Update()
    {       
        checkClick();
        listenInputs();
    }

    

    public void setUniformDistribution()
    {
        foreach (Transform element in transform)
        {
            double randNum = random.NextDouble();
            var textComp = element.GetChild(1).GetComponent<InputField>();
            textComp.text = randNum.ToString();
        }
    }

    public void setNormalDistribution()
    {
        foreach (Transform element in transform)
        {
            double randNum = getNormalRand_0_1();
            var textComp = element.GetChild(1).GetComponent<InputField>();
            textComp.text = randNum.ToString();
        }
    }

    public void setPoissonDistribution()
    {
        foreach (Transform element in transform)
        {
            double randNum = getPoissonRand();
            var textComp = element.GetChild(1).GetComponent<InputField>();
            textComp.text = randNum.ToString();
        }
    }

    private float getNormalRand()  // Box-Muller
    {
        float r1 = (float)random.NextDouble(), r2 = (float)random.NextDouble();
        return Mathf.Cos(2*Mathf.PI*r1)*Mathf.Sqrt(-2*Mathf.Log(r2));
    }

    private float getPoissonRand()  // Knuth   (DISCRETE?? DOESNT WORK)
    {
        float lambda = 0.5f;
        float L = Mathf.Exp(-lambda);
        float p = 1;
        int k = 0;
        for(k = 0; p > L; ++k)
        {
            p *= (float)random.NextDouble();
        }
        return k-1;
    }

    private float getNormalRand_0_1()
    {
        return sigmoid(getNormalRand());
    }

    private float sigmoid(float x)
    {
        return 1/(1 + Mathf.Exp(-x));
    }


    private void checkClick()
    {
        Vector3 pos = this.gameObject.transform.localPosition;
        pos.z = 1f;
        int it = 0;
        foreach (Transform child in transform)
        {
            if (child.transform.localPosition.z == 2f)
            {
                pos.z = it + 2f;
                //Debug.Log("!!!!");
                break;
            }
            it++;
        }
        this.gameObject.transform.localPosition = pos;
    }

    private void listenInputs()
    {
        int it = 0;
        foreach (Transform child in transform)
        {
            var input = child.GetChild(1).GetComponent<InputField>();
            float val = 1f;
            float.TryParse(input.text, out val);
            if (input.text == "") val = 1f;
            globalCircGraph.values[it] = val;
            it++;
        }
    }



}
