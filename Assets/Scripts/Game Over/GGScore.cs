using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GGScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI level;
    private string level_final="F";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.Instance.lb >= 70)
        {
            level_final = "S";
        }
        else if (GlobalData.Instance.lb >= 50)
        {
            level_final = "A";
        }
        else if (GlobalData.Instance.lb >= 20)
        {
            level_final = "B";
        }
        else
        {
            level_final = "C";
        }
        finalScore.text = "Score: " + GlobalData.Instance.lb + "/100";
        level.text = "Level: " + level_final;
    }
}
