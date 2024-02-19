using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchBroadcasterMono_Push : MonoBehaviour, I_ScratchBlockable
{

    public string m_messageToPush;

    public IEnumerator DoTheScratchableStuff()
    {
            PushWithInspectorValue();
            yield return null;
    }

    public void PushWithInspectorValue() { ScratchBroadcasterSingleton.BroadcastWithoutWaiting(m_messageToPush); }
    public void PushWithGivenValue(string label) { ScratchBroadcasterSingleton.BroadcastWithoutWaiting(label); }
}
