using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchMono_CoroutineStack : MonoBehaviour, I_ScratchBlockable
{

    public List<MonoBehaviour> m_scriptToPlay = new List<MonoBehaviour>();

    [Header("Debug")]
    public List<MonoBehaviour> m_played = new List<MonoBehaviour>();
    public MonoBehaviour m_playing;
    public int m_index = 0;
    public Coroutine m_coroutine;
    [ContextMenu("Play Stack")]
    public void PlayStackAsCoroutine()
    {
        if (m_coroutine != null)
            StopCoroutine(m_coroutine);
        m_coroutine = StartCoroutine(Coroutine_Play());
    }

    private IEnumerator Coroutine_Play()
    {
        m_played.Clear(); m_index = 0;
        foreach (var item in m_scriptToPlay)
        {
            if (item is I_ScratchBlockable) {
                m_playing = item;
                I_ScratchBlockable block = (I_ScratchBlockable)item;
                yield return block.DoTheScratchableStuff();
                m_played.Add(item);
            }
            m_index++;
        }
    }

    public IEnumerator DoTheScratchableStuff()
    {
        yield return  Coroutine_Play();
    }
}
