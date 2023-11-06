using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool isSageTime; // œÕ’ﬂ ±º‰

    public static SpawnManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSageTime(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSageTime(bool sageTime)
    {
        isSageTime = sageTime;
    }
}
