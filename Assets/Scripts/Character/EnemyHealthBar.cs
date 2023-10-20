using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform enemyHead; // 敌人的头部位置
    public Image healthBarImage; // 血条图片

    private Camera mainCamera; // 主摄像机

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        // 将血条位置固定在敌人头部上方
        Vector3 worldPos = enemyHead.position + Vector3.up * -0.1f;
        Vector3 screenPos = mainCamera.WorldToScreenPoint(worldPos);
        healthBarImage.transform.position = screenPos;
    }
}
