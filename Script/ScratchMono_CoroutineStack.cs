using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchMono_CoroutineStack :  A_ScratchBlockableMono
{

    public List<A_ScratchBlockableMono> m_scriptToPlay = new List<A_ScratchBlockableMono>();

    [Header("Debug")]
    public List<A_ScratchBlockableMono> m_played = new List<A_ScratchBlockableMono>();
    public A_ScratchBlockableMono m_playing;
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

    public override IEnumerator DoTheScratchableStuff()
    {
        yield return  Coroutine_Play();
    }
}


public abstract class A_ScratchBlockableMono :MonoBehaviour, I_ScratchBlockable
{
    public abstract IEnumerator DoTheScratchableStuff();

    [ContextMenu("Execute Block as Coroutine")]
    public void ExecuteBlockAsCoroutine() { 
        StartCoroutine(DoTheScratchableStuff());
    }
}