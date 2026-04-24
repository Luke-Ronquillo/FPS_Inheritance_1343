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
    }
}
