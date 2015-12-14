using HutongGames.PlayMaker;

[ActionCategory(ActionCategory.Logic)]
[Tooltip("Closes a door")]
public class CloseDoor : FsmStateAction
{
    [UIHint(UIHint.Variable)]
    [Tooltip("")]
    public DoorController Door;

    public override void Reset()
    {
    }

    public override void OnEnter()
    {
        Door.SetOpen(false);
        Finish();
    }
}
