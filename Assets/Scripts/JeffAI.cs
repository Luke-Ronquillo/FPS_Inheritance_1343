using UnityEngine;
using UnityEngine.AI;
enum MyStates
{
    wander,
    pursue,
    attack,
    recovery
}
public class JeffAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;
    MyStates myCurrState;

    [SerializeField] float wanderRadius = 10f;
    [SerializeField] float timeBetweenWanderPoints = 5f;
    [SerializeField] float playerSightRange = 15;
    [SerializeField] float playerLoseSightRange = 20;
    [SerializeField] float playerAttackRange = 2;
    [SerializeField] float recoveryTime = 2;
    float currStateElapsed;
    float timeRecovering = 0;

    float distanceToTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currStateElapsed = timeBetweenWanderPoints;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        switch (myCurrState)
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
        //agent.speed = 10;
        //agent.SetDestination(target.position);

        //float distanceToTarget = Vector3.Distance(transform.position, target.position);

        //if (distanceToTarget < 2)
        //    agent.isStopped = true;
        //if (distanceToTarget > 4)
        //    agent.isStopped = false;
    }
    void UpdateWander()
    {
        agent.speed = 3.5f;
        currStateElapsed += Time.deltaTime;
        if (currStateElapsed >= timeBetweenWanderPoints)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            currStateElapsed = 0;
        }
        if (distanceToTarget < playerSightRange)
        {
            currStateElapsed = 0;
            WanderToPursue();
        }
        Debug.Log("I'm wandering");
    }
    void UpdatePursue()
    {
        agent.SetDestination(target.position);
        if (distanceToTarget > playerLoseSightRange)
            PursueToWander();
        if (distanceToTarget < playerAttackRange)
            PursueToAttack();
        Debug.Log("I'm pursuing");
    }
    void UpdateAttack()
    {
        agent.speed = 0;
        currStateElapsed += Time.deltaTime;
        if (currStateElapsed > 2)
            AttackToRecovery();
        Debug.Log("I'm attacking");
    }
    void UpdateRecovery()
    {
        Debug.Log("I'm recovering");

        timeRecovering += Time.deltaTime;

        if (timeRecovering > recoveryTime)
        {
            timeRecovering = 0;
            currStateElapsed = 0;
            RecoveryToWander();
        }
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
    void RecoveryToWander()
    {
        myCurrState = MyStates.wander;
        currStateElapsed = timeBetweenWanderPoints;
    }

    Vector3 RandomNavSphere(Vector3 origin, float dist, int layerMask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layerMask);
        return navHit.position;
    }
}
