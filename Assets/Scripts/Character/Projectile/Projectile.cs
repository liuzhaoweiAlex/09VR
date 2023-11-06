using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectile : BossComponent
{
    public Transform targetTransform; // Ŀ��λ��
    public float projectileMoveSpeed; // �ƶ��ٶ�

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        float step = projectileMoveSpeed * Time.deltaTime;

        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(targetTransform.position.x, targetTransform.position.y, targetTransform.position.z), step);
    }
}
