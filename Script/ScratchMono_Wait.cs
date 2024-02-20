using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchMono_Wait : A_ScratchBlockableMono
{
    public float m_waitInSeconds;

    public override IEnumerator DoTheScratchableStuff()
    {
        if (m_waitInSeconds <= 0)
            yield return null;
        yield return new WaitForSeconds(m_waitInSeconds);
    }
}


