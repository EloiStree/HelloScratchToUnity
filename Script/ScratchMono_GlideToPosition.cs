using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchMono_GlideToPosition : MonoBehaviour
{

    public Vector3 m_position;
    public Transform m_whatToMove;
    public float m_timeToGlide;


    [Header("Visible private debug")]
    public Vector3 m_startPoint;
    public float m_timeInGameStartGliding;
    public Vector3 m_endPoint;
    public float m_timeInGameEndGliding;


    public Coroutine m_currentGliding;

    [ContextMenu("Glide to position")]
    public void GlideToValueInInspector()
    {
        GlideToGivenValue(m_position, m_timeToGlide);
    }
    public void GlideToGivenValue(Vector3 position, float timeToGlide)
    {
        if (m_currentGliding != null)
            StopCoroutine(m_currentGliding);

        m_startPoint = m_whatToMove.position;
        m_timeInGameStartGliding = Time.time;
        
        m_endPoint = position;
        m_timeInGameEndGliding = Time.time+timeToGlide;

        m_currentGliding = StartCoroutine(Coroutinable_GlideToGivenValue(position));
    }

    public IEnumerator Coroutinable_GlideToGivenValue(Vector3 position) {

        while (Time.time <= m_timeInGameEndGliding) {

            if ((m_timeInGameEndGliding - m_timeInGameStartGliding) == 0)
                break;
            float percentThere = 1f-(m_timeInGameEndGliding - Time.time) / (m_timeInGameEndGliding - m_timeInGameStartGliding);
            m_whatToMove.position = Vector3.Lerp(m_startPoint, m_endPoint, percentThere);
            yield return new WaitForEndOfFrame();
        }
    }

    private void Reset()
    {
        m_whatToMove = this.transform;
    }
}
