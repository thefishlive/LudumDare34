using UnityEngine;
using System.Collections.Generic;

public class ScriptingController : MonoBehaviour 
{
    public int RequiredSignals;
    public Interactable Target;

    private List<SignalLightController> lights = new List<SignalLightController>();

    private int signals = 0;

    public void SendSignal(SignalLightController controller, bool signal)
    {
        signals += signal ? 1 : -1;
        lights.Add(controller);
        Debug.Log(signals);

        if (signals >= RequiredSignals)
        {
            Target.interact();

            foreach (var light in lights)
            {
                light.Lock();
            }
        }
    }
}
