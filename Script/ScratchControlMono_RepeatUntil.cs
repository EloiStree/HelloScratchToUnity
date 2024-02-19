using System.Collections;

public class ScratchControlMono_RepeatUntil : UnityEngine.MonoBehaviour, I_ScratchBlockable
{

    public AbstractScratchMono_ConditionHolder m_ifCondition;
    public ScratchMono_CoroutineStack m_whatToRepeat;
    public bool m_useFrameWaitSecurity = true;

    public IEnumerator DoTheScratchableStuff()
    {
        while (m_ifCondition.IsConditionTrue()) { 
            yield return m_whatToRepeat;
            if (m_useFrameWaitSecurity)
                yield return new UnityEngine.WaitForEndOfFrame();
        }
        yield return null;
    }

}
