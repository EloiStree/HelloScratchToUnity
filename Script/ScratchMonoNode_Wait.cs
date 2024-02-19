using System.Collections;
using UnityEngine;

public class ScratchMonoNode_Wait : MonoBehaviour, I_ScratchBlockable
{
    public AbstractScratchMono_VariableHolderAsString m_waitInSeconds;

    public IEnumerator DoTheScratchableStuff()
    {
        yield return new WaitForSeconds(m_waitInSeconds.GetValueAsFloat());
    }
}
