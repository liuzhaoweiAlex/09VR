using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase_Character : Base_Character
{
    [Header("Enemy_Property")]
    public float T_tauntValue = 1;
    public void Start()
    {
        tauntValues.Add("Enemy", 1f);
        tauntValues.Add("T", 1f);
        tauntValues.Add("DPS1", 1f);

    }
    T_Character t;
    DPS1_Character dps1;
    public void OnTriggerEnter(Collider other)
    {
        t = other.GetComponent<T_Character>();

        if (t != null)
        {
            inAttackRange = true;
            Debug.Log("inAttackRange");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (t != null)
        {
            inAttackRange = false;
            Debug.Log("outAttackRange");
        }
            
    }


}
