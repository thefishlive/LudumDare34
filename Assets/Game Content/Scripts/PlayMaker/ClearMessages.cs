using HutongGames.PlayMaker;

[ActionCategory(ActionCategory.Logic)]
[Tooltip("Clears the current messages being displayed.")]
public class ClearMessages : FsmStateAction
{
    public override void Reset()
    {
    }

    public override void OnEnter()
    {
        Utils.getTextController().Clear();
        Finish();
    }
}
