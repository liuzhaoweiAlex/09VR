using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class Base_Character : MonoBehaviour
{
    [Header("Base_Property")]
    //public float tauntValue = 1;

    public float tauntAddValue = 2;
    public float tauntlimitValue = 16;

    public float healthlimitValue = 0;
    public float healthValue = 10;
    public float attackValue = 3;

    public bool isDirtLoving = false;
    public bool isAttacked = false;
    public bool isGetHit = false;
    public bool inAttackRange = false;

    private string highestTauntAttacker = null;
    private float highestTauntValue = 0f;

    public List<GameObject> CharacterObject;
    GameObject attackerObject;

    protected Dictionary<string, float> tauntValues = new Dictionary<string, float>();

    
    public void IncreaseTaunt(string attackerName, float tauntAValue)
    {
        if (tauntValues.ContainsKey(attackerName))
        {
            tauntValues[attackerName] += tauntAValue;
            //Debug.Log(tauntValues[attackerName]);
        }
        else
        {
            //tauntValues.Add(attackerName, tauntAValue);
            Debug.Log("It's not the key in the dictionary.");
        }
    }

    public void HealthAdd(float amount)
    {
        healthValue += amount;
    }

    protected virtual void Update()
    {
        HealthValueCheckMachine();
        CheckHighestTauntAttacker();
    }

    public void CheckHighestTauntAttacker()
    {
        highestTauntAttacker = null;
        highestTauntValue = 0f;

        foreach (var kvp in tauntValues)
        {
            if (kvp.Value >= tauntlimitValue && kvp.Value > highestTauntValue)
            {
                highestTauntAttacker = kvp.Key;
                highestTauntValue = kvp.Value;
            }
        }

        // 如果有攻击者满足条件，执行相应操作
        if (!string.IsNullOrEmpty(highestTauntAttacker))
        {
            Debug.Log("Player taunts " + highestTauntAttacker + " with taunt value " + highestTauntValue);

            // 这里可以根据需要执行其他操作，比如获取攻击者的Object信息
            

            if(highestTauntAttacker == "Enemy")
            {
                attackerObject = CharacterObject[0];
                attackerObject.GetComponent<EnemyBase_Character>().Attack();
                Debug.Log("Enemy attack T");

            }
            else if (highestTauntAttacker == "T")
            {
                attackerObject = CharacterObject[1];
                attackerObject.GetComponent<T_Character>().Attack();
            }
            else if (highestTauntAttacker == "DPS1")
            {
                attackerObject = CharacterObject[2];
                attackerObject.GetComponent<DPS1_Character>().Attack();
            }
            else
            {
                Debug.Log("no highestTauntAttacker");
            }
        }
    }
    public void HealthValueCheckMachine() 
    {
        if (healthValue <= healthlimitValue)
        {
            Die();
        }
    }

    public virtual void Attack() 
    {
        Debug.Log("Here is Attack");
    }

    
    public void Die()
    {
        Debug.Log("Here is die");
    }

    public virtual void GetHit(string attacker, float HValue, float TValue)
    {
        IncreaseTaunt(attacker, TValue);
        HealthAdd(-HValue);
        Debug.Log("Here is getHit");
    }
}
