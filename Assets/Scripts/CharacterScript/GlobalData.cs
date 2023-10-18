using System.Collections.Generic;
//using Unity.Mathematics;

public class GlobalData
{
    private GlobalData()
    {

    }

    private static GlobalData _instance;
    public static GlobalData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GlobalData();
            }
            return _instance;
        }
    }


    public float maxHealth { get; set; } = 100f;


    public float speed { get; set; } = 5f;

    public float attackSpeed { get; set; } = 1f;

    




}