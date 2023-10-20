using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossComponent : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100f;
    public float currentHealth;
    public float defensePower = 5f;
    public float attackPower = 10f;
    public float CharacterDamage = 50f;
    public GameObject win;

    public Image healthBarImage; // 血条图片

    void Start()
    {
        currentHealth = maxHealth;
        //healthBarImage = GetComponentInChildren<Image>();
    }

    public void TakeDamage(float damage)
    {
        float actuallDamage = damage - defensePower;
        if(actuallDamage <= 0)
        { 
            actuallDamage = 0; 
        }
        currentHealth -= actuallDamage;
        UpdateHealthBar();
        if(currentHealth <= 0)
        {
            win.SetActive(true);
        }

        Debug.Log("防御：" + defensePower);
        Debug.Log("真实造成伤害：" + actuallDamage);
        Debug.Log("当前血量：" + currentHealth);
    }

    void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
        healthBarImage.fillAmount = fillAmount;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<Character>() != null)
        {
            Debug.Log("攻击伤害："+ CharacterDamage);
            TakeDamage(CharacterDamage);


        }

    }
}

