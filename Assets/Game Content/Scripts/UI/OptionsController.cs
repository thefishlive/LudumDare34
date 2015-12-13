using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour 
{
    public Slider Sensitivity;
    public Slider FieldOfView;

    public void Start()
    {
        Sensitivity.value = PlayerPrefs.GetFloat("Sensitvity");
        FieldOfView.value = PlayerPrefs.GetFloat("FieldOfView");
    }

    public void OnSensitivityChanged()
    {
        PlayerPrefs.SetFloat("Sensitvity", Sensitivity.value);
        PlayerPrefs.Save();
    }

    public void OnFieldOfViewChanged()
    {
        PlayerPrefs.SetFloat("FieldOfView", FieldOfView.value);
        PlayerPrefs.Save();
    }
}
