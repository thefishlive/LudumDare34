using UnityEngine;
using System.Collections;

public class TextController : MonoBehaviour 
{
    private UIManager uiManager;

	// Use this for initialization
	void Start () 
    {
        uiManager = Utils.getUIManager();
	}

    public void ShowMessage(string message)
    {
        var controller = uiManager.HUDInstance.GetComponent<HUDController>();
        controller.SendMessage(message);
    }
}
