using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_S_SmellRange : MonoBehaviour
{
    void Update()
    {
        
    }

    public T_Character t;
    EnemyBase_Character enemy;
    DPS1_Character dPS1_Character;

    public void OnTriggerEnter(Collider other)
    {
        
        enemy = other.GetComponent<EnemyBase_Character>();
        dPS1_Character = other.GetComponent<DPS1_Character>();

        if (enemy != null  && t.S_skillIsUsed)
        {
            Debug.Log("S_skill is Used to enemy");
            t.S_skillIsUsed = false;
            t.CharacterObject[0].GetComponent<EnemyBase_Character>().GetHit(t.enemyName, t.attackValue, t.tauntAddValue);
            Debug.Log("here is attack");

        }
        if (dPS1_Character != null && t.S_skillIsUsed)
        {
            Debug.Log("S_skill is Used to dPS1_Character");
            t.S_skillIsUsed = false;
            t.CharacterObject[3].GetComponent<EnemyBase_Character>().GetHit("DPS1", t.attackValue, t.tauntAddValue);
            Debug.Log("here is attack");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (enemy != null || dPS1_Character != null)
        {
            Debug.Log("S_skill already Use");
        }
    }
}
