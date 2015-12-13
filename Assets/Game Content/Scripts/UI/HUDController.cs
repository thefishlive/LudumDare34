using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class HUDController : MonoBehaviour 
{
    private struct MessageEntry
    {
        public string Message { get; set; }
        public float Time { get; set; }
    }

    public float TimePerWord;
    public Text MessageBox;

    private Queue<MessageEntry> messages = new Queue<MessageEntry>();

    private bool displaying;
    private float displayTime;
    private float startTime;

	// Update is called once per frame
	void Update () 
    {
        if (displaying && (Time.time - startTime) >= displayTime)
        {
            if (messages.Count > 0)
            {
                var message = messages.Dequeue();
                MessageBox.text = message.Message;
                displayTime = message.Time;
                startTime = Time.time;
                Debug.Log(message);
            }
            else
            {
                MessageBox.text = "";
                displaying = false;
            }
        }
	}

    public bool SendMessage(string message, float displayTime)
    {
        if (displaying)
        {
            var entry = new MessageEntry();
            entry.Message = message;
            entry.Time = displayTime;
            messages.Enqueue(entry);
        }
        else
        {
            MessageBox.text = message;
            this.displayTime = displayTime;
            this.startTime = Time.time;
            this.displaying = true;
        }

        return true;
    }

    public void SkipMessage()
    {
        startTime = 0; // Force refresh
    }

    public void Clear()
    {
        SkipMessage();
        messages.Clear();
    }
}
