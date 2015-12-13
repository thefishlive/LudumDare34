using UnityEngine;
using System;
using System.Collections;

public class TextController : MonoBehaviour 
{
    public float TimePerWord;

    private UIManager uiManager;
    private HUDController controller;

	// Use this for initialization
	void Start () 
    {
        uiManager = Utils.getUIManager();
	}

    public void ShowMessage(string message)
    {
        char[] delimiters = new char[] { ' ', '\r', '\n' };
        int length = message.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        float displayTime = length * TimePerWord;
        ShowMessage(message, displayTime);
    }

    public void ShowMessage(string message, float time)
    {
        uiManager.HUDInstance.GetComponent<HUDController>().SendMessage(message, time);
    }

    public void Clear()
    {
        uiManager.HUDInstance.GetComponent<HUDController>().Clear();
    }
}
