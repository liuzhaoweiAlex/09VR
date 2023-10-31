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
    public float CharacterDamage = 20f;
    public float berserker_on = 40f;
    public GameObject win;
    public GameObject damage_r;
    public bool flag_r=false;
    public float time1 = 0f;
    public TextMeshProUGUI text_r;

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

    private AudioSource audioSource; // 获得音效组件

    private ParticleSystem hitParticle; // 获得受击特效

    void Start()
    {
        currentHealth = maxHealth;
        //healthBarImage = GetComponentInChildren<Image>();

        initialPosition = transform.position; // 记录初始位置  
        StartCoroutine(MoveObjectCoroutine()); // 在Start函数中开始协程 

        //PlayHitParticles(); // 播放特效测试
        //PlayHitSound(); // 播放音效测试
    }

    void Update()
    {

        //float step = moveSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition1.transform.position, step);
        if (flag_r)
        {
            time1 += Time.deltaTime;
            if (time1 > 1)
            {
                damage_r.SetActive(false);
                flag_r = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        PlayHitSound(); // 播放受击音效
        PlayHitParticles(); // 播放受击特效

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
        if (flag_r)
        {
            text_r.text = actuallDamage+"!!";
        }
    }

    void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
        healthBarImage.fillAmount = fillAmount;
        if(fillAmount<=1 && fillAmount > 0.7)
        {
            
            healthBarImage.color = new Color32(130,24,152,255);
        }
        if(fillAmount<=0.7 && fillAmount > 0.3)
        {
            healthBarImage.color = new Color32(255, 220, 80, 255);
        }
        if (fillAmount <= 0.3)
        {
            healthBarImage.color = new Color32(255, 0, 0, 255);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponentInParent<Character>() != null)
        //{
        //    Debug.Log("攻击伤害："+ CharacterDamage);
        //    TakeDamage(CharacterDamage);
        //}
        if (collision.gameObject.GetComponentInParent<Berserker>() != null)
        {
            if (GlobalData.Instance.berserker)
            {
                Debug.Log("攻击伤害：" + berserker_on);
                damage_r.SetActive(true);
                flag_r = true;
                TakeDamage(berserker_on);
                
            }
            else
            {
                Debug.Log("攻击伤害：" + CharacterDamage);
                TakeDamage(CharacterDamage);
            }
           
        }
        if (collision.gameObject.GetComponentInParent<Archer>() != null)
        {
            Debug.Log("攻击伤害：" + CharacterDamage);
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

    /// <summary>
    /// 播放音效
    /// </summary>
    public void PlayHitSound()
    {
        // 获取音频源组件 
        audioSource = GetComponent<AudioSource>();

        // 播放音效  
        audioSource.Play();
    }

    /// <summary>
    /// 播放受击特效
    /// </summary>
    public void PlayHitParticles()
    {
        // 获取特效源组件
        hitParticle = GameObject.Find("Boss").GetComponentInChildren<ParticleSystem>();

        // 播放特效
        hitParticle.Play();
    }
}

