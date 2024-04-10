using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class EnemyBrain : MonoBehaviour
{

    [SerializeField] private string initState;
    [SerializeField] private FSMState[] states; // Keep all states with actions and decisions 
    public FSMState CurrentState {  get;  set; }
    public Transform Player;

 

    private void Start()
    {
        ChangeState(initState);
    }

    private void Update()
    {
        CurrentState?.UpdateState(this); // Note : Same as     if (CurrentState == null) return;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void ChangeState(string newStateId)
    {
        FSMState newState = GetState(newStateId);
        if (newState == null)
        {
            return;
        }
        CurrentState = newState;
    }
    private FSMState GetState(string newStateID) // Check if a state exist or not 
    {
        for (int i = 0; i < states.Length; i++) // If there is a state in FSMState[]
        {
            if (states[i].ID == newStateID)
            {
                return states[i];
            }
        }
        return null;
    }
}
