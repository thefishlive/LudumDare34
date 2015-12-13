using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public bool CanMove;
    public bool CanLook;
    public bool CanInteract;
    public bool CanJump;

    public float SensitivityX;
    public float SensitivityY;

    public float MovementSpeed;
    public float JumpStrength;
    public int PlayerReach;

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
        Debug.Log(Cursor.lockState);

        UIManager = Utils.getUIManager();
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
        if (CanLook && Cursor.lockState != CursorLockMode.None)
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
            if (Controls.Look.Value.sqrMagnitude > 0) GetComponent<PlayMakerFSM>().SendEvent("Looked");
        }

        if (CanMove)
        {
            if (Controls.Move.Value.sqrMagnitude > 0) GetComponent<PlayMakerFSM>().SendEvent("Moved");
            GetComponent<Rigidbody>().AddForce(transform.forward * (Controls.Move.Y * MovementSpeed), ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(transform.right * (Controls.Move.X * MovementSpeed), ForceMode.Impulse);
        }

        if (CanJump)
        {
            if (Controls.Jump.WasPressed)
            {
                Debug.Log("Jump");
                GetComponent<Rigidbody>().AddForce(Vector3.up * JumpStrength, ForceMode.Impulse);
            }
        }

        if (CanInteract)
        {
            if (Controls.Interact.WasPressed)
            {
                RaycastHit hit;

                if (Physics.Raycast(new Ray(camera.transform.position, camera.transform.forward), out hit, PlayerReach))
                {
                    GameObject obj = hit.collider.gameObject;
                    Debug.Log(obj.name);
                    var interactable = obj.GetComponent<Interactable>();

                    if (interactable != null)
                    {
                        interactable.interact();
                    }
                }
            }
        }
    }
}
