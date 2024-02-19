using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchBroadcasterMono_PushAndWait : MonoBehaviour, I_ScratchBlockable
{

    public string m_messageToPush;

    public IEnumerator DoTheScratchableStuff()
    {
        
        yield return DoTheScratchableStuff(m_messageToPush);
    }
    public IEnumerator DoTheScratchableStuff(string message)
    {
        if (!Application.isPlaying)
            yield return null;
        ScratchBroadcasterSingleton.BroadcastWithWaiting(message, out List<I_BroadcastFeedBack> feedbacks);

        bool thereIsFeedBackLeft = true;
        while (thereIsFeedBackLeft == true)
        {
            yield return new WaitForEndOfFrame();
            thereIsFeedBackLeft = false;
            foreach (var item in feedbacks)
            {
                if (item != null && item.IsConsequenceOfLastBroadcastStillActive())
                {
                    thereIsFeedBackLeft = true;
                    break;
                }
            }
        }
        yield return null;
    }
}
