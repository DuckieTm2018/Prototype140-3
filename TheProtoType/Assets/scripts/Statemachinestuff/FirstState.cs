
using UnityEngine;
using StateStuff;

public class FirstState : State<Ai>
{
    private static FirstState _instance;
    private FirstState()
    {
        if(_instance != null)
        {
            return;
        }
        _instance = this;
    }
    public static FirstState Instance
    {
        get
        {
            if (_instance == null)
            {
                new FirstState();
            }
            return _instance;
        }
    }

    public override void EnterState(Ai _owner)
    {
        Debug.Log("Entering FirstState");
    }

    public override void ExitState(Ai _owner)
    {
        Debug.Log("Exiting FirstState");
    }

    public override void UpdateState(Ai _owner)
    {
        if(_owner.switchState)
        {
            _owner.stateMachine.ChangeState(SecondState.Instance);
        }
    }
}
