using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : State
{
    public override void OnEnter()
    {
        UIManager.Instance.SetUIState(UIState.Score);
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        
    }  
}
