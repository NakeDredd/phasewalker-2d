using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Timeline
{
    Past,
    Present,
    Future
}

public class PhaseWalker : MonoBehaviour
{
    [SerializeField] private Timeline currentTimeline;
    [SerializeField] private float cooldown;

    private float cooldownTimer;

    public delegate void PhaseWalkerEvents(Timeline newTimeline);
    public static PhaseWalkerEvents OnChangeTimeline;

    private void Update()
    {
        if (cooldownTimer <= cooldown)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButton(0) && cooldownTimer <= 0)
        {
            ChangeTimeline();
            cooldownTimer = cooldown;
        }
    }
    
    private void ChangeTimeline()
    {
        if (currentTimeline == Timeline.Present)
        {
            OnChangeTimeline.Invoke(Timeline.Past);
            currentTimeline = Timeline.Past;
        }
        else if (currentTimeline == Timeline.Past)
        {
            OnChangeTimeline.Invoke(Timeline.Present);
            currentTimeline = Timeline.Present;
        }
    }
}
