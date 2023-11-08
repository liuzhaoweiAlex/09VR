using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Archer : MonoBehaviour
{
    // Start is called before the first frame update
    public int cost = 30;
    public float time_1 = 0f;
    public float time_2 = 0f;
    public GameObject player;
    public GameObject enemy;
    public float enemy_x;
    public float enemy_y;
    public float player_x;
    public float player_y;
    private Vector3 targetPosition = new Vector3(0.061f, 0.298f, 1.908f);


    public float speed = 20f;  //  �ƶ��ٶ�
    public Transform target;  //  Ŀ��λ��
    private Rigidbody rb;  //  ����ĸ������
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (GlobalData.Instance.archer == true)
        //{
        //    time_1 += Time.deltaTime;
        //    if (time_1 > 15)
        //    {
        //        GlobalData.Instance.archer = false;
        //        time_1 = 0f;
        //        Debug.Log("archer off");
        //    }
        //}

        if (GlobalData.Instance.archer == true)
        {
            Debug.Log("�ж�����1");
            enemy_x = enemy.transform.position.x;
            enemy_y = enemy.transform.position.y;
            player_x = player.transform.position.x;
            player_y = player.transform.position.y;
            if ((player_x - enemy_x) * (player_x - enemy_x) + (player_y - enemy_y) * (player_y - enemy_y) < 1.4 * 1.4)
            {
                //if(flag == false)
                //{
                //    flag = true;
                //    GetComponent<Rigidbody>().isKinematic = true;
                //    GetComponent<Rigidbody>().isKinematic = false;
                //}
                //GetComponent<Rigidbody>().useGravity = false;

                //Debug.Log("�ж�����2");
                //rb = GetComponent<Rigidbody>();  //  ��ȡ����ĸ������
                //rb.useGravity = false;
                //StartCoroutine(MoveToTarget());  //  ��ʼ�ƶ���Ŀ��λ�õ�Э��
                //Vector3 moveDirection = target.position - transform.position;  //  ����������Ҫ�ƶ��ķ���
                //moveDirection.Normalize();  //  �������׼��
                //rb.velocity = moveDirection * speed;
                //Vector3 direction = (target.position - transform.position).normalized;
                // GetComponent<Rigidbody>().velocity = direction * speed;
                // MoveToPosition(targetPosition, speed);
                GetComponent<Rigidbody>().isKinematic = true;
                time_2 += Time.deltaTime;
                if (time_2 > 3)
                {
                    Destroy(player);
                }
                
            }
        }
    }

    public void intensify()
    {
        if (cost <= GlobalData.Instance.lb && !GlobalData.Instance.berserker && !GlobalData.Instance.archer)
        {
            GlobalData.Instance.lb -= cost;
            GlobalData.Instance.archer = true;
            Debug.Log("archer on");
        }
    }

    IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, target.position) > 0.01f)  //  ֻҪ�����Ŀ��λ�õľ������0.01f,��һֱ�ƶ�
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed);  //  ʹ�ò�ֵ�����ƶ����嵽Ŀ��λ��
            rb.MovePosition(transform.position);  //  �������λ�ø��µ����������
            yield return null;  //  ������һ�ε���
        }
    }
    private void MoveToPosition(Vector3 position, float moveSpeed)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, moveSpeed * Time.deltaTime);
        Debug.Log("gogogo");
    }

}
