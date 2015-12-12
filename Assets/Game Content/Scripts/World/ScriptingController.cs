using UnityEngine;
using System.Collections;

public class ScriptingController : MonoBehaviour 
{
    public int RequiredSignals;
    public Interactable Target;

    private int signals = 0;

    public void SendSignal(bool signal)
    {
        signals += signal ? 1 : -1;
        Debug.Log(signals);

        if (signals >= RequiredSignals)
        {
            Target.interact();
        }
    }
}
