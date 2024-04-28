using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private GameObject selectorSprite;

    private EnemyBrain enemyBrain;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }

    private void EnemySelectorCallback(EnemyBrain enemySelected) // If Player clicks on an enemy
    {
        if (enemySelected == enemyBrain)
        {
            selectorSprite.SetActive(true);
        }
        else
        {
            selectorSprite.SetActive(false);
        }
    }

    public void NoSelectionCallBack() // If Player doesn't click on an enemy
    {
        selectorSprite.SetActive(false);
    }

    private void OnEnable()
    {
        SelectionManager.OnEnemySelectedEvent += EnemySelectorCallback;
        SelectionManager.OnNoSelectionEvent += NoSelectionCallBack;
    }

    private void OnDisable()
    {
        SelectionManager.OnEnemySelectedEvent -= EnemySelectorCallback;
        SelectionManager.OnNoSelectionEvent -= NoSelectionCallBack;
    }

}
