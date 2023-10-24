using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI m_time;
    public TextMeshProUGUI m_lb;
    public float countdownTime = 60f;
    public GameObject gameOver;


    void Start()
    {
        StartCoroutine(StartCountdown());
        
    }

    // Update is called once per frame
    private IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
            UpdateTimerText();
        }
        Debug.Log("Countdown finished!");
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);
        m_time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Update()
    {
        if (countdownTime <= 0)
        {
            gameOver.SetActive(true);

        }
        m_lb.text = "Points: " + GlobalData.Instance.lb;

    }
}