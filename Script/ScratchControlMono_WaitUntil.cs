using System.Collections;
using UnityEngine;

public class ScratchControlMono_WaitUntil : UnityEngine.MonoBehaviour, I_ScratchBlockable
{
    public AbstractScratchMono_ConditionHolder m_ifCondition;
 
    public IEnumerator DoTheScratchableStuff()
    {
        if (!Application.isPlaying)
            yield return null;
        while (m_ifCondition.IsConditionFalse())
           yield return new UnityEngine.WaitForEndOfFrame();
        yield return null;
    }
}
