using System.Collections;
using UnityEngine;

public class ScratchMonoNode_ChangeVolume : A_ScratchBlockableMono
{

    public AbstractScratchMono_VariableHolderAsString m_volumePercent;

    public override IEnumerator DoTheScratchableStuff()
    {
        AudioListener.volume = Mathf.Clamp(AudioListener.volume +m_volumePercent.GetValueAsFloat(), 0.0f, 1.0f);
        yield return null;
    }



}
