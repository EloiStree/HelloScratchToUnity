using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UScratchHelperMono_FollowingMonoIsStack : A_ScratchBlockableMono
{
    public List<A_ScratchBlockableMono> m_followingBlock = new List<A_ScratchBlockableMono>();

    public bool m_refreshListAtStart=true;
    public bool m_refreshAtEachCall=true;

    private void Awake()
    {
        if(m_refreshListAtStart)
           Refresh();
    }

    public override IEnumerator DoTheScratchableStuff()
    {
        if (m_refreshAtEachCall)
            Refresh();
        for (int i = 0; i < m_followingBlock.Count; i++)
        {
            if (i < m_followingBlock.Count && m_followingBlock[i] != null)
                yield return m_followingBlock[i].DoTheScratchableStuff();
        }
    }

    [ContextMenu("Refresh list")]
    void Refresh()
    {
        m_followingBlock.Clear();
        GetComponents(m_followingBlock);
        GetComponentsInChildren(m_followingBlock);
        m_followingBlock.Remove(this);
    }

}
