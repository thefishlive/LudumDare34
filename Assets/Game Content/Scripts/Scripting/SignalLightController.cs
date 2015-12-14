using UnityEngine;
using System.Collections;

public class SignalLightController : Interactable 
{
    public ScriptingController Controller;

    public Material OnMaterial;
    public Material OffMaterial;
    public GameObject Light;

    public bool State;
    public bool Locked;

    public virtual void SetState(bool state)
    {
        if (Locked) return;

        State = state;
        Light.GetComponent<MeshRenderer>().material = State ? OnMaterial : OffMaterial;
        Controller.SendSignal(this, State);
    }

    public void Toggle()
    {
        SetState(!State);
    }

    public override void interact()
    {
        Toggle();
    }

    public void Lock()
    {
        Locked = true;
    }

}
