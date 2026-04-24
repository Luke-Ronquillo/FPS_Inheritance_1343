using UnityEngine;
enum MyStates
{
    wander,
    pursue,
    attack,
    recovery
}
public class StateExample : MonoBehaviour
{
    [SerializeField] MyStates myCurrState;

    float timeRecovering = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(myCurrState)
        {
            case MyStates.wander:
                UpdateWander();
                break;
            case MyStates.pursue:
                UpdatePursue();
                break;
            case MyStates.attack:
                UpdateAttack();
                break;
            case MyStates.recovery:
                UpdateRecovery();
                break;
        }
    }

    void UpdateWander()
    {
        Debug.Log("I'm wandering");
    }
    void UpdatePursue()
    {
        Debug.Log("I'm pursuing");
    }
    void UpdateAttack()
    {
        Debug.Log("I'm attacking");
    }
    void UpdateRecovery()
    {
        Debug.Log("I'm recovering");

        timeRecovering += Time.deltaTime;

        if (timeRecovering > 2.0f)
            RecoveryToPursue();
    }
    void WanderToPursue()
    {
        myCurrState = MyStates.pursue;
    }
    void PursueToWander()
    {
        myCurrState = MyStates.wander;
    }
    void PursueToAttack()
    {
        myCurrState = MyStates.attack;
    }
    void AttackToRecovery()
    {
        timeRecovering = 0;
        myCurrState = MyStates.recovery;
    }
    void RecoveryToPursue()
    {
        myCurrState = MyStates.pursue;
    }
    void RecoveryToWander()
    {
        myCurrState = MyStates.wander;
    }
}
