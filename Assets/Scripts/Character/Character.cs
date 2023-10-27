using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject character; // 勇者的引用
    public float minHeightY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DestroySelf();
    }

    /// <summary>
    /// 低于一定高度自毁
    /// </summary>
    void DestroySelf()
    {
        if (character.transform.position.y < minHeightY && SpawnManager.instance.isSageTime == false)
        {
            Destroy(character);
        }
    }

    /// <summary>
    /// 攻击自毁
    /// </summary>
    public void HitDestroy()
    {
        Destroy(character);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<BossComponent>() != null)
        {
            Debug.Log("计算伤害");
            HitDestroy(); // 攻击自毁
        }
        else
        {
            //Debug.Log("不是目标");
        }
    }
}
