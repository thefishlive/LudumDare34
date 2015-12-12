using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public bool CanMove;
    public bool CanLook;
    public bool CanInteract;

    public float SensitivityX;
    public float SensitivityY;

    public float MovementSpeed;

    private PlayerControls Controls;
    private Transform camera;

    private UIManager UIManager;

	// Use this for initialization
	void Start () 
    {
        camera = Camera.main.GetComponent<Transform>();
        Controls = new PlayerControls();
        Controls.SetupDefaultControls();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        UIManager = GameObject.FindGameObjectWithTag("UI Manager").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Controls.Pause.WasPressed)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            UIManager.ShowPauseMenu();
        }

        UpdateMovement();
	}

    private void UpdateMovement()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            return;
        }

        if (CanLook)
        {
            Vector3 cameradestination = camera.transform.localEulerAngles + new Vector3(Controls.Look.Y * SensitivityY, 0.0f, 0.0f);

            if (cameradestination.x <= 180.0f && cameradestination.x > 30.0f)
            {
                cameradestination.x = 30.0f;
            }

            if (cameradestination.x >= 180.0f && cameradestination.x < 350.0f)
            {
                cameradestination.x = 350.0f;
            }

            camera.transform.localEulerAngles = cameradestination;

            float rotationX = Controls.Look.X * SensitivityX;
            transform.localEulerAngles = transform.localEulerAngles + new Vector3(0.0f, rotationX, 0.0f);
        }

        if (CanMove)
        {
            transform.position += (transform.forward * (Controls.Move.Y * MovementSpeed)) + (transform.right * (Controls.Move.X * MovementSpeed));
        }
    }
}
