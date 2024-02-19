using UnityEngine;

public class ScratchBroadcasterFlagStartStopMono :MonoBehaviour{

    public bool m_useAutoStartAtEnable = true;
    public bool m_useAutoStopAtDisable = true;
    public bool m_useAutoStopAtDestroy = true;
    public void OnEnable()
    {
        if (m_useAutoStartAtEnable)
        {
            BroadcastGreenFlagStartEvent();
        }
    }
    public void OnDisable()
    {
        if (m_useAutoStopAtDisable)
        {
            BroadcastGreenRedStopEvent();
        }
    }
    public void OnDestroy()
    {
        if (m_useAutoStopAtDestroy)
        {
            BroadcastGreenRedStopEvent();
        }
    }


    private void BroadcastGreenFlagStartEvent()
    {
        ScratchBroadcasterSingletonFlagStartStop.TriggerStartFlag();
    }
    private void BroadcastGreenRedStopEvent()
    {
        ScratchBroadcasterSingletonFlagStartStop.TriggerRedStop();
    }
}