using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] private GameObject past;
    [SerializeField] private GameObject present;
    [SerializeField] private GameObject future;
    [SerializeField] private Timeline currentTimeline;

    private GameObject currentTimelineObject;

    private void Awake()
    {
        PhaseWalker.OnChangeTimeline += ChangeTimeline;

        currentTimelineObject = past;
        ChangeTimeline(currentTimeline);
    }

    private void OnDisable()
    {
        PhaseWalker.OnChangeTimeline -= ChangeTimeline;
    }

    private void ChangeTimeline(Timeline newTimeline)
    {
        currentTimelineObject.SetActive(false);
        switch (newTimeline)
        {
            case Timeline.Past:
                past.SetActive(true);
                currentTimelineObject = past;
                break;
            case Timeline.Present:
                present.SetActive(true);
                currentTimelineObject = present;
                break;
            case Timeline.Future:
                future.SetActive(true);
                currentTimelineObject = future;
                break;
        }
    }
}
