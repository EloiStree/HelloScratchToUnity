using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ScratchBroadcasterMono_OnBroadcastReceived : MonoBehaviour, I_ScratchBroadcastListener
{
    public string m_listenToLabel;

    [Header("Debug")]

    public string m_lastReceivedBroadcast;

    public ScratchMono_CoroutineStack m_stackToRun;
    public Coroutine m_currentlyRunning;
    public BroadcastFeedBackDefault m_broadcastFeedback = new();
    public bool m_useTrim=true;
    public bool m_ignoreCase=true;


    private void OnEnable()
    {
        ScratchBroadcasterSingleton.AddBroadcastListener(this);

    }
    private void OnDisable()
    {
        ScratchBroadcasterSingleton.RemoveBroadcastListener(this);
    }
    private void OnDestroy()
    {
        ScratchBroadcasterSingleton.RemoveBroadcastListener(this);
    }

    public void OnBroadcastMessage(string broadcastMessage)
    {
        CheckValidityOfMessageAndTrigger(broadcastMessage);

    }

    private bool CheckValidityOfMessageAndTrigger(string broadcastMessage)
    {
        m_lastReceivedBroadcast = broadcastMessage;
        string label = m_listenToLabel;
        if (m_useTrim)
        {
            broadcastMessage = broadcastMessage.Trim();
            label = label.Trim();
        }
        if (m_ignoreCase)
        {
            broadcastMessage = broadcastMessage.ToLower();
            label = label.ToLower();
        }

        if (label == broadcastMessage)
        {
            LaunchSingleInstanceAction();
            return true;
        }
        return false;

    }

    public void LaunchSingleInstanceAction() {
        if (m_currentlyRunning != null)
            StopCoroutine(m_currentlyRunning);
        m_broadcastFeedback.SetAsRunning();
        m_currentlyRunning = StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        m_broadcastFeedback.SetAsRunning();
        yield return m_stackToRun.DoTheScratchableStuff();
        m_broadcastFeedback.SetAsStopped();
    }

    public void OnBroadcastMessageWithStateRequest(string broadcastMessage, out I_BroadcastFeedBack isConsquenceStillActive)
    {
        if (CheckValidityOfMessageAndTrigger(broadcastMessage))
            isConsquenceStillActive = m_broadcastFeedback;
        else isConsquenceStillActive = null;
    }

    
}

public interface I_ScratchBroadcastListener {
    public void OnBroadcastMessage(string broadcastMessage);
    public void OnBroadcastMessageWithStateRequest(string broadcastMessage, out I_BroadcastFeedBack isConsquenceStillActive);
}
public interface I_BroadcastFeedBack{
    public bool IsConsequenceOfLastBroadcastStillActive();
}

[System.Serializable]
public class BroadcastFeedBackDefault : I_BroadcastFeedBack
{
    public bool m_isStillRunning;
    public bool IsConsequenceOfLastBroadcastStillActive()
    {
        return m_isStillRunning;
    }
    public void SetAsRunning(bool isRunning = true) { m_isStillRunning = isRunning; }
    public void SetAsStopped() { m_isStillRunning = false; }
}