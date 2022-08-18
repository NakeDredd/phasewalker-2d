using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public enum Timeline
{
    Past,
    Present,
    Future
}

public class PhaseWalker : MonoBehaviour
{
    [SerializeField] private Timeline currentTimeline;
    [SerializeField] private PlayerInput playerInput;

    public delegate void PhaseWalkerEvents(Timeline newTimeline);
    public static PhaseWalkerEvents OnChangeTimeline;

    private void Start()
    {
        playerInput.actions["SwipeTimeline"].performed += ChangeTimeline;
    }
    private void OnDisable()
    {
        playerInput.actions["SwipeTimeline"].performed -= ChangeTimeline;
    }

    private void ChangeTimeline(CallbackContext context)
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
