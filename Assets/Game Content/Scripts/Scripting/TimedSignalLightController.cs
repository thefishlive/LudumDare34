using UnityEngine;
using System.Collections;

public class TimedSignalLightController : SignalLightController
{
    public float ResetTime;

    private float time;
    private float startTime;
    
    // Update is called once per frame
    void Update()
    {
        if (State && (Time.time - startTime) >= ResetTime)
        {
            base.SetState(false);
            Debug.Log("Disabled");
        }
    }

    public override void SetState(bool state)
    {
        if (!state)
        {
            Debug.LogWarning("Cannot toggle this timer off");
            return;
        }

        base.SetState(state);
        startTime = Time.time;
        Debug.Log(startTime);
    }
}
