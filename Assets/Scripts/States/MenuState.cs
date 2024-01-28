using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuState : State
{
    [SerializeField] private Button playButton;
   
    public override void OnEnter()
    {    
        UIManager.Instance.SetUIState(UIState.Menu);
        playButton.onClick.AddListener(ToNextState);
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
        controller.ChangeState();        
    }
}
