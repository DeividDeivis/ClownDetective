using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuState : State
{
    [SerializeField] private Button playButton;
   
    public override void OnEnter()
    {
        playButton.interactable = true;
        UIManager.Instance.SetUIState(UIState.Menu);
        playButton.onClick.AddListener(()=>
        {
            ToNextState();
            playButton.interactable = false;
        });
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        playButton.onClick.RemoveAllListeners();
    }
 
    private void ToNextState()
    {
        UIManager.Instance.ExitUIScreen(GameManager.Instance.ChangeState);   
    }
}
