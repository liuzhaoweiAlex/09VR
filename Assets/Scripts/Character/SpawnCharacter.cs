using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;
using static UnityEditor.Progress;

public class SpawnCharacter : MonoBehaviour
{
    public Transform character; // ��ɫ�����λ������  
    public float randomRange = 0.5f; // ���λ�õķ�Χ 
    public float randomYRangea = 2f; // ���Yλ�õķ�Χa
    public float randomYRangeb = 3f; // ���Yλ�õķ�Χb
    public float spawnInterval = 2.0f; // ���ɶ���ļ��ʱ�䣨�룩
    public int charactersCount = 20; // ���Ͻ�ɫ����
    public int sageTimeCharactersCount = 30; // ����ʱ��ʱ���Ͻ�ɫ������

    private Coroutine spawnCoroutine; // ����Э������

    // Start is called before the first frame update
    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnCharacters()); // Э�����ɽ�ɫ
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    ///��������
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnCharacters()
    {
        GameObject Archer = Resources.Load<GameObject>("Character/Prefabs/Archer");  // ����Դ�м��ع�����Ԥ��  
        GameObject Berserker = Resources.Load<GameObject>("Character/Prefabs/Berserker");  // ����Դ�м��ؿ�սʿԤ��
        GameObject knight = Resources.Load<GameObject>("Character/Prefabs/knight");  // ����Դ�м�����ʿԤ��
        GameObject Sage = Resources.Load<GameObject>("Character/Prefabs/Sage");  // ����Դ�м�������Ԥ��

        List<GameObject> characterInScene = new List<GameObject>();
        characterInScene.Add(Archer);
        characterInScene.Add(Berserker);
        characterInScene.Add(knight);
        characterInScene.Add(Sage);
        
        while (true) 
        {
            yield return new WaitForSeconds(spawnInterval);

            // ��ȡ��ɫ��ǰλ��  
            Vector3 characterPosition = character.position;

            // �������ƫ����  
            float randomX = UnityEngine.Random.Range(-randomRange, randomRange);
            float randomY = UnityEngine.Random.Range(randomYRangea, randomYRangeb);
            float randomZ = UnityEngine.Random.Range(-randomRange, randomRange);

            // �����µ����λ��  
            Vector3 randomPosition = new Vector3(characterPosition.x + randomX, characterPosition.y + randomY, characterPosition.z + randomZ);

            // ��������ĸ���ɫ  
            int randomInt = Random.Range(0, 4);

            int currentCharactersCount = charactersCount;

            if (SpawnManager.instance.isSageTime == true)
            {
                Debug.Log("����ʱ��");
                currentCharactersCount = sageTimeCharactersCount; // ���������ʱ�䣬�ϵ���������
            }
            else
            {
                Debug.Log("������ʱ��");
                currentCharactersCount = charactersCount;
            }

            if (GameObject.FindGameObjectsWithTag("Character").Length < currentCharactersCount)
            {
                // �ڸ�λ�����ɽ�ɫʵ�� 
                Instantiate(characterInScene[randomInt], randomPosition, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0));
            }
        }
    }
}
