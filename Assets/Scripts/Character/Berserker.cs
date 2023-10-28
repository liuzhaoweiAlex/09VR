using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : MonoBehaviour
{
    // Start is called before the first frame update

    public int cost = 40;
    public float time1 = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.Instance.berserker == true)
        {
            time1 += Time.deltaTime;
            if (time1 > 10)
            {
                GlobalData.Instance.berserker = false;
                time1 = 0f;
                Debug.Log("berserker off");
            }
        }
    }

    public void intensify()
    {
        if (cost <= GlobalData.Instance.lb && !GlobalData.Instance.archer && !GlobalData.Instance.berserker)
        {
            GlobalData.Instance.lb-=cost;
            GlobalData.Instance.berserker = true;
            Debug.Log("berserker on");
        }
    }
}
