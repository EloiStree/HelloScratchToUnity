using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchMono_Wait : MonoBehaviour, I_ScratchBlockable
{
    public float m_waitInSeconds;

    public IEnumerator DoTheScratchableStuff()
    {
        yield return new WaitForSeconds(m_waitInSeconds);
    }
}


