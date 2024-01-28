using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuState : State
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button backFromCredits;
    [SerializeField] private GameObject creditsScreen;
   
    public override void OnEnter()
    {
        playButton.interactable = true;
        UIManager.Instance.SetUIState(UIState.Menu);
        playButton.onClick.AddListener(()=>
        {
            ToNextState();
            playButton.interactable = false;
        });

        creditsButton.onClick.AddListener(() =>
        {
            creditsScreen.SetActive(true);
        });

        backFromCredits.onClick.AddListener(() =>
        {
            creditsScreen.SetActive(false);
        });
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        playButton.onClick.RemoveAllListeners();
        creditsButton.onClick.RemoveAllListeners();
        backFromCredits.onClick.RemoveAllListeners();
    }
 
    private void ToNextState()
    {
        UIManager.Instance.ExitUIScreen(GameManager.Instance.ChangeState);   
    }
}
