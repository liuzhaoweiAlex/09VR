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
        if (GlobalData.Instance.maxHealth >= 70)
        {
            
        }
        else if(GlobalData.Instance.maxHealth>=50)
        {
            level_final = "A";
        }
        else if (GlobalData.Instance.maxHealth >= 20)
        {
            level_final = "B";
        }
        else
        {
            level_final = "C";
        }
    }

    // Update is called once per frame
    void Update()
    {
        finalScore.text = "Score: " + GlobalData.Instance.maxHealth + "/100";
        level.text = "Level: " + level_final;
    }
}
