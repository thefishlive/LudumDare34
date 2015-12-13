using UnityEngine;
using System.Collections;

public class SignalLightController : Interactable 
{
    public ScriptingController Controller;

    public Material OnMaterial;
    public Material OffMaterial;
    public GameObject Light;

    public bool State;

    public virtual void SetState(bool state)
    {
        Debug.Log(state);
        State = state;
        Light.GetComponent<MeshRenderer>().material = State ? OnMaterial : OffMaterial;
        Controller.SendSignal(State);
    }

    public void Toggle()
    {
        SetState(!State);
    }

    public override void interact()
    {
        Toggle();
    }

}
