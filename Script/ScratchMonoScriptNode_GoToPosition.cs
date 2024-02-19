using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchMonoScriptNode_GoToPosition : MonoBehaviour, I_ScratchBlockable
{
    public AbstractScratchMono_VariableHolderVector3 m_position;
    public Transform m_whatToMove;

    [ContextMenu("Go To")]
    public void GoToValueInInspector()
    {

        GoToGivenValue(m_position.GetVector3());
    }
    public void GoToGivenValue(Vector3 position)
    {
        m_whatToMove.position = position;
    }

    private void Reset()
    {
        m_whatToMove = this.transform;
    }

    public IEnumerator DoTheScratchableStuff()
    {
        GoToValueInInspector();
        yield return null;
    }
}
