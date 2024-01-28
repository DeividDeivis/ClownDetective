using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State
{
    LevelController levelController;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }
    public override void OnEnter()
    {
        UIManager.Instance.SetUIState(UIState.Gameplay);
        levelController.ShuffleList();
        levelController.GetNextCharacter();
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        //TODO apagar UI gameplay
    }

    private void ToNextState()
    {
        GameManager.Instance.ChangeState();
        
    }
}
