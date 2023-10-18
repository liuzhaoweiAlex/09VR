using System.Collections;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    public float currentHealth;
    private bool isAttacking = false;
    public float defensePower = 5f;
    public float attackPower = 10f;
    public float tauntValue = 0f;//����ֵ
    public float tauntCoefficient = 1f;//����������ͬ��ɫһ���������
    public int countAttackNum = 0;
    // Ѫ������
    public GameObject healthBar;

    private void Start()
    {
        currentHealth = GlobalData.Instance.maxHealth;
        countAttackNum = 0;
    }

    private void Update()
    {
        // ����Ѫ����ʾ
        UpdateHealthBar();

        if (Input.GetMouseButtonDown(0))  // ����갴��ʱ
        {
            isAttacking = true;
            InvokeRepeating("Attacking", 0f, GlobalData.Instance.attackSpeed);  // ÿ��attackSpeed�����Attacking����
        }

        if (Input.GetMouseButtonUp(0))  // ����굯��ʱ
        {
            isAttacking = false;
            CancelInvoke("Attacking");  // ֹͣ����Attacking����
        }



    }

    // �ܵ��˺�
    public void TakeDamage(float damage)
    {
        float actualDamage = damage - defensePower;
        actualDamage = Mathf.Clamp(actualDamage, 0f, float.MaxValue); // ��ֹ�����˺�
        currentHealth -= actualDamage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ����Ŀ��
    public void Attack(CharacterAttributes target)
    {
        float damage = attackPower - target.defensePower;
        damage = Mathf.Clamp(damage, 0f, float.MaxValue); // ��ֹ�����˺�
        target.TakeDamage(damage);
    }

    // �ƶ�
    public void Move(Vector3 direction)
    {
        transform.Translate(direction * GlobalData.Instance.speed * Time.deltaTime);
    }

    // ����Ѫ����ʾ
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            float healthRatio = currentHealth / GlobalData.Instance.maxHealth;
            healthBar.transform.localScale = new Vector3(healthRatio, 1f, 1f);
        }
    }

    // ����
    private void Die()
    {
        // ��ɫ�������߼�
    }

    private void Attacking()
    {
        //������ʵ����ҵĹ����߼�
        Debug.Log("Player attack!");
        countAttackNum++;
    }

    public float Taunt()
    {
        return countAttackNum * tauntCoefficient * attackPower;//����ֵ��������
    }

}