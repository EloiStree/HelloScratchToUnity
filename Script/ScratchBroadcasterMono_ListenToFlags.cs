using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScratchBroadcasterMono_ListenToFlags : MonoBehaviour
{
    public UnityEvent m_onGreenFlag;
    public UnityEvent m_onRedFlag;

    void Awake()
    {
        ScratchBroadcasterSingletonFlagStartStop.AddListenerStartFlag(NotifyGreen);
        ScratchBroadcasterSingletonFlagStartStop.AddListenerRedStop(NotifyRed);
    }
    void OnDestroy()
    {
        ScratchBroadcasterSingletonFlagStartStop.RemoveListenerStartFlag(NotifyGreen);
        ScratchBroadcasterSingletonFlagStartStop.AddListenerRedStop(NotifyRed);
    }

    private void NotifyRed()
    {
        m_onRedFlag.Invoke();
    }

    private void NotifyGreen()
    {
        m_onGreenFlag.Invoke();
    }

    [ContextMenu("Notify Red")]
    private void TriggerOnSingletonRed()
    {
        ScratchBroadcasterSingletonFlagStartStop.TriggerRedStop();
    }

    [ContextMenu("Notify Green")]
    private void TriggerOnSingletonGreen()
    {
        ScratchBroadcasterSingletonFlagStartStop.TriggerStartFlag();
    }


}
