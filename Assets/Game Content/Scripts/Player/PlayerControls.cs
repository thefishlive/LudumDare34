using UnityEngine;
using InControl;
using System.Collections;

public class PlayerControls : PlayerActionSet
{
    public PlayerAction LookLeft        { get; private set; }
    public PlayerAction LookRight       { get; private set; }
    public PlayerAction LookDown        { get; private set; }
    public PlayerAction LookUp          { get; private set; }
    public PlayerTwoAxisAction Look     { get; private set; }

    public PlayerAction MoveLeft        { get; private set; }
    public PlayerAction MoveRight       { get; private set; }
    public PlayerAction MoveForward     { get; private set; }
    public PlayerAction MoveBackwards   { get; private set; }
    public PlayerTwoAxisAction Move     { get; private set; }

    public PlayerAction Pause           { get; private set; }
    public PlayerAction Jump            { get; private set; }
    public PlayerAction Interact        { get; private set; }

    public PlayerControls() 
    {
        LookLeft = CreatePlayerAction("Look Left");
        LookRight = CreatePlayerAction("Look Right");
        LookUp = CreatePlayerAction("Look Up");
        LookDown = CreatePlayerAction("Look Down");
        Look = CreateTwoAxisPlayerAction(LookLeft, LookRight, LookUp, LookDown);

        MoveLeft = CreatePlayerAction("Move Left");
        MoveRight = CreatePlayerAction("Move Right");
        MoveForward = CreatePlayerAction("Move Forwards");
        MoveBackwards = CreatePlayerAction("Move Backwards");
        Move = CreateTwoAxisPlayerAction(MoveLeft, MoveRight, MoveBackwards, MoveForward);

        Pause = CreatePlayerAction("Pause");
        Jump = CreatePlayerAction("Jump");
        Interact = CreatePlayerAction("Interact");
	}
	
	public void SetupDefaultControls() 
    {
        LookLeft.AddDefaultBinding(Mouse.NegativeX);
        LookLeft.AddDefaultBinding(InputControlType.RightStickLeft);
        LookRight.AddDefaultBinding(Mouse.PositiveX);
        LookRight.AddDefaultBinding(InputControlType.RightStickRight);
        LookUp.AddDefaultBinding(Mouse.PositiveY);
        LookUp.AddDefaultBinding(InputControlType.RightStickUp);
        LookDown.AddDefaultBinding(Mouse.NegativeY);
        LookDown.AddDefaultBinding(InputControlType.RightStickDown);

        MoveLeft.AddDefaultBinding(Key.A);
        MoveLeft.AddDefaultBinding(InputControlType.LeftStickLeft);
        MoveRight.AddDefaultBinding(Key.D);
        MoveRight.AddDefaultBinding(InputControlType.LeftStickRight);
        MoveForward.AddDefaultBinding(Key.W);
        MoveForward.AddDefaultBinding(InputControlType.LeftStickUp);
        MoveBackwards.AddDefaultBinding(Key.S);
        MoveBackwards.AddDefaultBinding(InputControlType.LeftStickDown);

        Pause.AddDefaultBinding(Key.Escape);
        Pause.AddDefaultBinding(InputControlType.Start);
        Jump.AddDefaultBinding(Key.Space);
        Jump.AddDefaultBinding(InputControlType.Action1);
        Interact.AddDefaultBinding(Key.E);
        Interact.AddDefaultBinding(InputControlType.Action4);
	}
}
