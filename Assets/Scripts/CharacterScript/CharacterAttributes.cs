using System.Collections;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    public float currentHealth;
    private bool isAttacking = false;
    public float defensePower = 5f;
    public float attackPower = 10f;
    public float tauntValue = 0f;//嘲讽值
    public float tauntCoefficient = 1f;//嘲讽倍数，不同角色一定义此属性
    public int countAttackNum = 0;
    // 血条对象
    public GameObject healthBar;

    private void Start()
    {
        currentHealth = GlobalData.Instance.maxHealth;
        countAttackNum = 0;
    }

    private void Update()
    {
        // 更新血条显示
        UpdateHealthBar();

        if (Input.GetMouseButtonDown(0))  // 当鼠标按下时
        {
            isAttacking = true;
            InvokeRepeating("Attacking", 0f, GlobalData.Instance.attackSpeed);  // 每隔attackSpeed秒调用Attacking方法
        }

        if (Input.GetMouseButtonUp(0))  // 当鼠标弹起时
        {
            isAttacking = false;
            CancelInvoke("Attacking");  // 停止调用Attacking方法
        }



    }

    // 受到伤害
    public void TakeDamage(float damage)
    {
        float actualDamage = damage - defensePower;
        actualDamage = Mathf.Clamp(actualDamage, 0f, float.MaxValue); // 防止负数伤害
        currentHealth -= actualDamage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 攻击目标
    public void Attack(CharacterAttributes target)
    {
        float damage = attackPower - target.defensePower;
        damage = Mathf.Clamp(damage, 0f, float.MaxValue); // 防止负数伤害
        target.TakeDamage(damage);
    }

    // 移动
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * GlobalData.Instance.speed * Time.deltaTime);
    }

    // 更新血条显示
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            float healthRatio = currentHealth / GlobalData.Instance.maxHealth;
            healthBar.transform.localScale = new Vector3(healthRatio, 1f, 1f);
        }
    }

    // 死亡
    private void Die()
    {
        // 角色死亡的逻辑
    }

    private void Attacking()
    {
        //在这里实现玩家的攻击逻辑
        Debug.Log("Player attack!");
        countAttackNum++;
    }

    public float Taunt()
    {
        return countAttackNum * tauntCoefficient * attackPower;//嘲讽值计算和输出
    }

}