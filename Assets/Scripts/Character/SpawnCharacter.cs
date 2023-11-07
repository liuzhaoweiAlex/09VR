using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;
using static UnityEditor.Progress;

public class SpawnCharacter : MonoBehaviour
{
    public Transform character; // 角色对象的位置引用  
    public float randomRange = 0.5f; // 随机位置的范围 
    public float randomYRangea = 2f; // 随机Y位置的范围a
    public float randomYRangeb = 3f; // 随机Y位置的范围b
    public float spawnInterval = 2.0f; // 生成对象的间隔时间（秒）
    public int charactersCount = 20; // 场上角色数量
    public int sageTimeCharactersCount = 30; // 贤者时间时场上角色的数量

    private Coroutine spawnCoroutine; // 储存协程引用

    // Start is called before the first frame update
    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnCharacters()); // 协程生成角色
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    ///生成勇者
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnCharacters()
    {
        GameObject Archer = Resources.Load<GameObject>("Character/Prefabs/Archer");  // 从资源中加载弓箭手预设  
        GameObject Berserker = Resources.Load<GameObject>("Character/Prefabs/Berserker");  // 从资源中加载狂战士预设
        GameObject knight = Resources.Load<GameObject>("Character/Prefabs/knight");  // 从资源中加载骑士预设
        GameObject Sage = Resources.Load<GameObject>("Character/Prefabs/Sage");  // 从资源中加载贤者预设

        List<GameObject> characterInScene = new List<GameObject>();
        characterInScene.Add(Archer);
        characterInScene.Add(Berserker);
        characterInScene.Add(knight);
        characterInScene.Add(Sage);
        
        while (true) 
        {
            yield return new WaitForSeconds(spawnInterval);

            // 获取角色当前位置  
            Vector3 characterPosition = character.position;

            // 生成随机偏移量  
            float randomX = UnityEngine.Random.Range(-randomRange, randomRange);
            float randomY = UnityEngine.Random.Range(randomYRangea, randomYRangeb);
            float randomZ = UnityEngine.Random.Range(-randomRange, randomRange);

            // 计算新的随机位置  
            Vector3 randomPosition = new Vector3(characterPosition.x + randomX, characterPosition.y + randomY, characterPosition.z + randomZ);

            // 计算随机哪个角色  
            int randomInt = Random.Range(0, 4);

            int currentCharactersCount = charactersCount;

            if (SpawnManager.instance.isSageTime == true)
            {
                Debug.Log("贤者时间");
                currentCharactersCount = sageTimeCharactersCount; // 如果是贤者时间，上调存在上限
            }
            else
            {
                Debug.Log("非贤者时间");
                currentCharactersCount = charactersCount;
            }

            if (GameObject.FindGameObjectsWithTag("Character").Length < currentCharactersCount)
            {
                // 在该位置生成角色实例 
                Instantiate(characterInScene[randomInt], randomPosition, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0));
            }
        }
    }
}
