using HutongGames.PlayMaker;

[ActionCategory(ActionCategory.Logic)]
[Tooltip("Sends a dialog message to the player.")]
public class SendMessage : FsmStateAction
{
    [RequiredField]
    [UIHint(UIHint.Variable)]
    [Tooltip("The message to send.")]
    public string message;

    [UIHint(UIHint.Variable)]
    [Tooltip("The time to show it on screen")]
    public float displayTime;

    public override void Reset()
    {
        message = null;
    }

    public override void OnEnter()
    {
        if (displayTime == 0)
        {
            Utils.getTextController().ShowMessage(message);
        }
        else
        {
            Utils.getTextController().ShowMessage(message, displayTime);
        }

        Finish();
    }
}
