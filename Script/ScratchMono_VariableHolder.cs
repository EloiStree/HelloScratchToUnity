using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchMono_VariableHolder : AbstractScratchMono_VariableHolderAsString
{
    public string m_variable;

    public override string GetVariableAsString()
    {
        return m_variable;
    }
}


public abstract class AbstractScratchMono_VariableHolderAsString : MonoBehaviour {


    public abstract string GetVariableAsString();

    public float GetValueAsFloat(float defaulValueIfError = 0)
    {

        if (float.TryParse(GetVariableAsString(), out float result))
        {
            return result;
        }
        else
        {
            return defaulValueIfError;
        }
    }
    public float GetValueAsInt(int defaulValueIfError = 0)
    {

        if (int.TryParse(GetVariableAsString(), out int result))
        {
            return result;
        }
        else
        {
            return defaulValueIfError;
        }
    }
}