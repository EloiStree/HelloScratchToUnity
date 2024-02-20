using System.Collections;

public class ScratchControlMono_IfElse : A_ScratchBlockableMono
{

    public AbstractScratchMono_ConditionHolder m_ifCondition;
    public A_ScratchBlockableMono m_onConditionTrue;
    public A_ScratchBlockableMono m_onConditionFalse;

    public override IEnumerator DoTheScratchableStuff()
    {
        if (m_ifCondition.IsConditionTrue())
            yield return m_onConditionTrue.DoTheScratchableStuff();
        else
            yield return m_onConditionFalse.DoTheScratchableStuff();
    }

}
