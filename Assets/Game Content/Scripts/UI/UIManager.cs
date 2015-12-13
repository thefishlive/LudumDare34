using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour 
{
    public GameObject HUD;
    public GameObject PauseMenu;

    public GameObject HUDInstance { get; set; }
    public GameObject PauseMenuInstance { get; set; }

	void Start () 
    {
        if (HUD != null)
        {
            HUDInstance = Instantiate(HUD);
        }

        if (PauseMenu != null)
        {
            PauseMenuInstance = Instantiate(PauseMenu);
            PauseMenuInstance.SetActive(false);
        }
	}
	
    public void ShowPauseMenu()
    {
        if (PauseMenuInstance != null)
        {
            PauseMenuInstance.SetActive(true);
        }
    }

    public void HidePauseMenu()
    {
        if (PauseMenuInstance != null)
        {
            PauseMenuInstance.SetActive(false);
        }
    }
}
