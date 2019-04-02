using UnityEngine;
using StateStuff;

public class SecondState : State<Ai>
{
    private static SecondState _instance;
    private SecondState()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }
    public static SecondState Instance
    {
        get
        {
            if (_instance == null)
            {
                new SecondState();
            }
            return _instance;
        }
    }

    public override void EnterState(Ai _owner)
    {
        Debug.Log("Entering SecondState");
    }

    public override void ExitState(Ai _owner)
    {
        Debug.Log("Exiting SecondState");
    }

    public override void UpdateState(Ai _owner)
    {
        if (!_owner.switchState)
        {
            _owner.stateMachine.ChangeState(FirstState.Instance);
        }
    }
}
