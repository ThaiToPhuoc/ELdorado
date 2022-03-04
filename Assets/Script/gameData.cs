using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameData : MonoBehaviour
{
    static gameData _instance;
    public static gameData instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("gameData");
                _instance = go.AddComponent<gameData>();
            }

            return _instance;

        }
    }

    public int[,] result = new int[5,5];
}