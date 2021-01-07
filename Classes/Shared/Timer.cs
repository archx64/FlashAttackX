using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private List<TimedEvent> events;

    private class TimedEvent
    {
        public float timeToExecute;
        public CallBack method;
    }

    public delegate void CallBack();

    private void Awake()
    {
        events = new List<TimedEvent>();
    }

    private void Update()
    {
        if (events.Count == 0)
        {
            return;
        }

        for (int i = 0; i < events.Count; i++)
        {
            TimedEvent timedEvent = events[i];
            if(timedEvent.timeToExecute<=Time.time)
            {
                timedEvent.method();
                events.Remove(timedEvent);
            }
        }
    }

    public void Add(CallBack method, float inSeconds)
    {
        events.Add(new TimedEvent
        {
            method = method,
            timeToExecute = Time.time + inSeconds
        });
    }
}
