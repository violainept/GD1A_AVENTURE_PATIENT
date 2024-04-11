using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageText : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private TextMeshProUGUI damageTMP;

    public void SetDamageText(float damage)
    {
        damageTMP.text = damage.ToString();
    }

    public void DestroyText()
    {
        Destroy(gameObject);
    }
}
