using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    //protected GameManager controller;
    //protected UIController ui;
    
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();

    //public void Init(GameManager _controller, UIController _ui)
    //{        
    //    controller = _controller;
    //    ui = _ui;
    //}
}
