using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{

    public static DamageManager Instance; // Singleton = Access to methods, variables, properties of the class outside the course 

    [Header("Configurations")]
    [SerializeField] private DamageText damageTextPrefab;

    private void Awake()
    {
        Instance = this; // this = Class
    }

    public void ShowDamageText(float damageAmount, Transform parent)
    {
        DamageText text = Instantiate(damageTextPrefab, parent);
        text.transform.position += Vector3.right * 0.5f;
        text.SetDamageText(damageAmount);
    }
}
