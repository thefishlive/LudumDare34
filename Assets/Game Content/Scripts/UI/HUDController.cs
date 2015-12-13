using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class HUDController : MonoBehaviour 
{
    public float TimePerWord;
    public Text MessageBox;

    private bool displaying;
    private float displayTime;
    private float startTime;

	// Update is called once per frame
	void Update () 
    {
        if (displaying && (Time.time - startTime) >= displayTime)
        {
            MessageBox.text = "";
        }
	}

    public bool SendMessage(string message)
    {
        if (displaying) return false;
        MessageBox.text = message;

        char[] delimiters = new char[] { ' ', '\r', '\n' };
        int length = message.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        displayTime = length * TimePerWord;
        startTime = Time.time;
        displaying = true;
        Debug.Log(message);

        return true;
    }

    public void SkipMessage()
    {

    }
}
