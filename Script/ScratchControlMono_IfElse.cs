using System.Collections;

public class ScratchControlMono_IfElse : UnityEngine.MonoBehaviour, I_ScratchBlockable
{

    public AbstractScratchMono_ConditionHolder m_ifCondition;
    public ScratchMono_CoroutineStack m_onConditionTrue;
    public ScratchMono_CoroutineStack m_onConditionFalse;

    public IEnumerator DoTheScratchableStuff()
    {
        if (m_ifCondition.IsConditionTrue())
            yield return m_onConditionTrue;
        else
            yield return m_onConditionFalse;
    }

}
