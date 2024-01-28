using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuState : State
{
       
    

   
    public override void OnEnter()
    {
        //TODO Prender UI menu

        
        
    }

    public override void OnExit()
    {        
        //TODO Apagar UI menu
        
    }

    public override void OnUpdate()
    {
        
    }
    
    private void ToNextState()
    {
        controller.ChangeState();        
    }

    
}
