using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchMono_MoveBlock : MonoBehaviour
{

    public float m_value;
    public Transform m_whatToMove;

    [ContextMenu("Move")]
    public void MoveWithInspectorValue()
    {
        m_whatToMove.Translate(Vector3.forward*m_value, Space.Self);
    }
    public void MoveWithGivenValue(float value)
    {

        m_whatToMove.Translate(Vector3.forward * value, Space.Self);
    }
    public void Reset()
    {
        m_whatToMove = this.transform;
    }
}
