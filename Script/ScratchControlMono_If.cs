using System.Collections;

public class ScratchControlMono_If : UnityEngine.MonoBehaviour, I_ScratchBlockable
{

    public AbstractScratchMono_ConditionHolder m_ifCondition;
    public ScratchMono_CoroutineStack m_onConditionTrue;

    public IEnumerator DoTheScratchableStuff()
    {
        if (m_ifCondition.IsConditionTrue())
            yield return m_onConditionTrue;
        yield return null;
    }

}

