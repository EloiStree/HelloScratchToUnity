using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scratchMono_Forever : MonoBehaviour, I_ScratchBlockable
{
    public bool m_useEndOfFrameSecurity = true;
    public ScratchMono_CoroutineStack m_scratchStack;

    public Coroutine m_running;

    [ContextMenu("Launch Forever loop")]
    public void LaunchForeverCoroutine() {
        if (m_running != null)
            StopCoroutine(m_running);
        m_running= StartCoroutine(DoTheScratchableStuff());
        
    }       

    public IEnumerator DoTheScratchableStuff()
    {
        if (!Application.isPlaying)
            yield return null;
        while (true) {

            if(m_scratchStack)
                yield return m_scratchStack.DoTheScratchableStuff();
            
            if (m_useEndOfFrameSecurity)
                yield return new WaitForEndOfFrame();
        }
    }
}
