using UnityEngine;
using System.Collections;

public class KeyPadController : Interactable 
{
    public Interactable target;

    public override void interact()
    {
        target.interact();
    }
}
