using System;

[Serializable]
public class FSMTransition
{
    public FSMDecision Decision; // Example : PlayerInRangeOfAttack -> True or False
    public string TrueState; //  IF TRUE, CurrentState -> AttackState
    public string FalseState; // IF FALSE, CurrentState -> PatrolState
}
