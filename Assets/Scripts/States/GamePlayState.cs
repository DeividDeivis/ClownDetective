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
        //TODO prender UI gameplay
        levelController.ShuffleList();
        levelController.GetNextCharacter();
    }

    public override void OnExit()
    {
        //TODO apagar UI gameplay
    }

    public override void OnUpdate()
    {
        
    }

    private void ToNextState()
    {
        controller.ChangeState();
        
    }
}
