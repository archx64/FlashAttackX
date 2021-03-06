﻿using UnityEngine;

public class PickupFlour : GoapAction
{
    bool completed = false;
    float startTime = 0;
    public float workDuration = 2; // seconds
    public Inventory windmill;

    public PickupFlour()
    {
        addPrecondition("hasStock", true);
        addPrecondition("hasFlour", false);
        addEffect("hasFlour", true);
        actionName = "PickupFlour";
    }

    public override void Reset()
    {
        completed = false;
        startTime = 0;
    }

    public override bool IsDone()
    {
        return completed;
    }

    public override bool RequiresInRange()
    {
        return true;
    }

    public override bool CheckProceduralPrecondition(GameObject agent)
    {
        return true;
    }

    public override bool Perform(GameObject agent)
    {
        if (startTime == 0)
        {
            Debug.Log("Starting: " + actionName);
            startTime = Time.time;
        }

        if (Time.time - startTime > workDuration)
        {
            Debug.Log("Finished: " + actionName);
            GetComponent<Inventory>().flourLevel += 5;
            windmill.flourLevel -= 5;
            completed = true;
        }
        return true;
    }

}
