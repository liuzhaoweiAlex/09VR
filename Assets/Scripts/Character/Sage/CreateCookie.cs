using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCookie : MonoBehaviour
{
    public Transform character; // 角色对象的位置引用  
    public float randomRange = 0.5f; // 随机位置的范围 
    public float spawnInterval = 2.0f; // 生成对象的间隔时间（秒）
    public int cookiesCount = 4; // 场上料理数量

    private Coroutine spawnCoroutine; // 储存协程引用

    // Start is called before the first frame update
    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnCookies()); // 协程生成料理
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 每隔2秒生成一个料理
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnCookies()
    {
        GameObject Cookie = Resources.Load<GameObject>("Character/Prefabs/Cookie");  // 从资源中加载料理预设  

        float randomProbability = UnityEngine.Random.value;

        while (randomProbability > 0.5 && GameObject.FindGameObjectsWithTag("Cookie").Length < cookiesCount) // 随机数大于0.5且场上料理数量小于一定数量时生成
        {
            yield return new WaitForSeconds(spawnInterval);

            // 获取角色当前位置  
            Vector3 characterPosition = character.position;

            // 生成随机偏移量  
            float randomX = UnityEngine.Random.Range(-randomRange, randomRange);
            float randomZ = UnityEngine.Random.Range(-randomRange, randomRange);

            // 计算新的随机位置  
            Vector3 randomPosition = new Vector3(characterPosition.x + randomX, characterPosition.y, characterPosition.z + randomZ);

            // 在该位置生成对象实例 
            Instantiate(Cookie, randomPosition, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0));
        }
    }
}
