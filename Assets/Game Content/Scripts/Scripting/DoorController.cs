using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class DoorController : Interactable 
{
    private static int OPEN = Animator.StringToHash("Open");

    public List<string> OpenMessage = null;

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

        if (open && OpenMessage.Count != 0)
        {
            var controller = Utils.getTextController();
            controller.Clear();

            foreach (string message in OpenMessage)
            {
                controller.ShowMessage(message);
            }
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
