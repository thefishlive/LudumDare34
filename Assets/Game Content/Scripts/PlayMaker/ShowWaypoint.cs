using HutongGames.PlayMaker;

[ActionCategory(ActionCategory.Logic)]
[Tooltip("Shows a waypoint")]
public class ShowWaypoint : FsmStateAction
{
    [UIHint(UIHint.Variable)]
    [Tooltip("")]
    public UnityEngine.GameObject Waypoint;

    public override void Reset()
    {
    }

    public override void OnEnter()
    {
        Waypoint.SetActive(true);
        Finish();
    }
}
