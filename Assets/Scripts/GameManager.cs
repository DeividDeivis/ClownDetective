using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //private UIController UI;
   
    private State currentState;
    private List<State> states = new List<State>();
    public static GameManager Instance;

    

    private void Awake()
    {
       
        Instance = this;
        states.Add(GetComponent<MenuState>());        
        states.Add(GetComponent<GamePlayState>());
        states.Add(GetComponent<GameEndState>());        
        //foreach(State state in states) state.Init(this, UI);
    }

    private void Start()
    {       
        ChangeState(states[0]);
    }
    private void Update()
    {
        currentState.OnUpdate();

            
    }

    /// <summary>
    /// Change the game state to the next one.
    /// </summary>
    public void ChangeState()
    {
        currentState.OnExit();
        currentState = NextState();
        currentState.OnEnter();
    }

    /// <summary>
    /// Change the game state to a specific state.
    /// </summary>
    /// <param name="state">Next game state.</param>
    private void ChangeState(State state)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = state;
        currentState.OnEnter();
    }

    /// <summary>
    /// Get the next game state of the states list.
    /// </summary>
    /// <returns>Next game state.</returns>
    public State NextState()
    {
        int nextIndex = states.IndexOf(currentState) + 1;
        if (nextIndex < states.Count)
        {
            return states[nextIndex];
        }
        else
        {
            return states[0];
        }
    }
   

}
public enum GameStates
{
    Menu, GamePlay, GameEnd
}

