using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour 
{
    public GameObject HUD;
    public GameObject PauseMenu;

    private GameObject HUDInstance;
    private GameObject PauseMenuInstance;

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
