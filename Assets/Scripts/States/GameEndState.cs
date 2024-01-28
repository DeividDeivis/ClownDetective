using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndState : State
{
    //[SerializeField] private Button menuButton;

    public override void OnEnter()
    {
        UIManager.Instance.SetUIState(UIState.Score);
        //menuButton.interactable = true;
        //UIManager.Instance.SetUIState(UIState.Score);
        //menuButton.onClick.AddListener(() =>
        //{
        //    ToNextState();
        //    menuButton.interactable = false;
        //});
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        //menuButton.onClick.RemoveAllListeners();
    }

    private void ToNextState()
    {
        UIManager.Instance.ExitUIScreen(GameManager.Instance.ChangeState);
    }
}
