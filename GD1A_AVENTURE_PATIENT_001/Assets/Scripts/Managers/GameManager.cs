using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Player player;

    public Player Player => player;

    public GameObject[] objects;

    private void Awake()
    {
        Instance = this;

        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
}
