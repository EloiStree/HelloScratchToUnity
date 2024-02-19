using System.Collections;
using UnityEngine;

public class scratchMono_Repeat: MonoBehaviour, I_ScratchBlockable
{
    public int m_repeatCount = 10;
    public ScratchMono_CoroutineStack m_scratchStack;

    public Coroutine m_running;

    [ContextMenu("Launch Repeater loop")]
    public void LaunchRepeaterCoroutine()
    {
        if (m_running != null)
            StopCoroutine(m_running);
        m_running = StartCoroutine(DoTheScratchableStuff());

    }

    public IEnumerator DoTheScratchableStuff()
    {
        for (int i = 0; i < m_repeatCount; i++)
        {
            if (m_scratchStack) 
                yield return m_scratchStack.DoTheScratchableStuff();
        }
    }
}
