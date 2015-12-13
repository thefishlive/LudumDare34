using UnityEngine;

class Utils
{
    public static UIManager getUIManager()
    {
        return GameObject.FindGameObjectWithTag("UI Manager").GetComponent<UIManager>();
    }

    public static TextController getTextController()
    {
        return GameObject.FindGameObjectWithTag("Text Controller").GetComponent<TextController>();
    }
}
