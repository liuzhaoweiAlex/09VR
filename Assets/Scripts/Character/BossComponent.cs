using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
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

    public GameObject originalPosition; // 原始位置

    public float randomRange = 0.5f; // 随机位置的范围 
    public float randomYRangea = 2f; // 随机Y位置的范围a
    public float randomYRangeb = 3f; // 随机Y位置的范围b

    public Vector3 targetPosition; // 目标位置  
    public float moveSpeed = 1.0f; // 移动速度  

    private Vector3 initialPosition; // 初始位置  
    private float elapsedTime; // 已经过去的时间 

    public bool flashSkillTime = false; // 是否处于闪烁技能赋值

    void Start()
    {
        currentHealth = maxHealth;
        //healthBarImage = GetComponentInChildren<Image>();

        initialPosition = transform.position; // 记录初始位置  
        StartCoroutine(MoveObjectCoroutine()); // 在Start函数中开始协程 
    }

    void Update()
    {

        //float step = moveSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition1.transform.position, step);
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

    /// <summary>
    /// 移动
    /// </summary>
    /// <returns></returns>
    IEnumerator MoveObjectCoroutine()
    {
        while (flashSkillTime == true) // 创建一个无限循环，使协程一直运行  
        {
            // 获取角色当前位置  
            Vector3 bossPosition = transform.position;

            // 生成随机偏移量  
            float randomX = UnityEngine.Random.Range(-randomRange, randomRange);
            float randomY = UnityEngine.Random.Range(randomYRangea, randomYRangeb);
            float randomZ = UnityEngine.Random.Range(-randomRange, randomRange);

            // 计算新的随机位置  
            Vector3 randomPosition = new Vector3(bossPosition.x + randomX, bossPosition.y + randomY, bossPosition.z + randomZ);

            targetPosition = randomPosition;

            // 将游戏对象移动到指定位置  
            transform.position = targetPosition;
            // 记录过去的时间  
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(1); // 让协程等待1秒钟，然后重新开始下一轮循环（移动、等待）
        }
    }
}

