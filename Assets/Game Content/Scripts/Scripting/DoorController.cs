using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class DoorController : Interactable 
{
    private static int OPEN = Animator.StringToHash("Open");

    private Animator animator;

	// Use this for initialization
	void Start () 
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void SetOpen(bool open)
    {
        animator.SetBool(OPEN, open);

        if (open)
        {
            GetComponent<PlayMakerFSM>().SendEvent("OpenDoor");
        }
    }

    public void Toggle()
    {
        SetOpen(!animator.GetBool(OPEN));
    }

    public override void interact()
    {
        Toggle();
    }
}
