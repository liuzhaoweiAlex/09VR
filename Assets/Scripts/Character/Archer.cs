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


    public float speed = 20f;  //  移动速度
    public Transform target;  //  目标位置
    private Rigidbody rb;  //  物体的刚体组件
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
            Debug.Log("判定到了1");
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

                //Debug.Log("判定到了2");
                //rb = GetComponent<Rigidbody>();  //  获取物体的刚体组件
                //rb.useGravity = false;
                //StartCoroutine(MoveToTarget());  //  开始移动到目标位置的协程
                //Vector3 moveDirection = target.position - transform.position;  //  计算物体需要移动的方向
                //moveDirection.Normalize();  //  将方向标准化
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
        while (Vector3.Distance(transform.position, target.position) > 0.01f)  //  只要物体和目标位置的距离大于0.01f,就一直移动
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed);  //  使用插值方法移动物体到目标位置
            rb.MovePosition(transform.position);  //  将物体的位置更新到刚体组件中
            yield return null;  //  继续下一次迭代
        }
    }
    private void MoveToPosition(Vector3 position, float moveSpeed)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, moveSpeed * Time.deltaTime);
        Debug.Log("gogogo");
    }

}
