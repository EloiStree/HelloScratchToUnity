using System.Collections;

public class ScratchControlMono_If : A_ScratchBlockableMono
{

    public AbstractScratchMono_ConditionHolder m_ifCondition;
    public A_ScratchBlockableMono m_onConditionTrue;

    public override IEnumerator DoTheScratchableStuff()
    {
        if (m_ifCondition.IsConditionTrue())
            yield return m_onConditionTrue.DoTheScratchableStuff();
        yield return null;
    }

}

