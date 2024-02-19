using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScratchMono_OnGameStart : MonoBehaviour
{
    public UnityEvent m_onGameAwake;
    public UnityEvent m_onGameStart;

    public void Awake()
    {
        m_onGameAwake.Invoke();
    }
    public void Start()
    {

        m_onGameStart.Invoke();
    }

}
