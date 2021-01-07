using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class Worker : MonoBehaviour, IGoap
{
    private NavMeshAgent agent;
    private Vector3 previousDestination;
    private Inventory inv;
    public Inventory windmill;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        inv = GetComponent<Inventory>();
    }

    public HashSet<KeyValuePair<string,object>> GetWorldState () 
    {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("hasStock", (windmill.flourLevel > 4)),
            new KeyValuePair<string, object>("hasFlour", (inv.flourLevel > 1)),
            new KeyValuePair<string, object>("hasDelivery", (inv.breadLevel > 4))
        };
        return worldData;
    }


    public HashSet<KeyValuePair<string,object>> CreateGoalState ()
    {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("doJob", true)
        };
        return goal;
    }


    public bool MoveAgent(GoapAction nextAction) {
        
        //if we don't need to move anywhere
        if(previousDestination == nextAction.target.transform.position)
        {
            nextAction.setInRange(true);
            return true;
        }
        
        agent.SetDestination(nextAction.target.transform.position);
        
        if (agent.hasPath && agent.remainingDistance < 2) {
            nextAction.setInRange(true);
            previousDestination = nextAction.target.transform.position;
            return true;
        } else
            return false;
    }

    void Update()
    {
        if(agent.hasPath)
        {
            Vector3 toTarget = agent.steeringTarget - transform.position;
            float turnAngle = Vector3.Angle(transform.forward,toTarget);
            agent.acceleration = turnAngle * agent.speed;
        }
    }

    public void PlanFailed (HashSet<KeyValuePair<string, object>> failedGoal)
    {

    }

    public void PlanFound (HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions)
    {

    }

    public void ActionsFinished ()
    {

    }

    public void PlanAborted (GoapAction aborter)
    {

    }
}
