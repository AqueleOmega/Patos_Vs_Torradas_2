using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class BodyStateIdle : BodyBaseState
{

    Animator head;
    BodyStateManager Script_Original;

    public BodyStateIdle(Animator head1, BodyStateManager Script_Originals)
    {
        this.head = head1;
        this.Script_Original = Script_Originals;
    }
    

    public override void EnterState(BodyStateManager Body)
    {

        // Ao inicializar o state idle eu já lanço o método de escolher o próximo
        // state. Eu poderia esperar, se quissesse.
        //Escolher(player);
    }

    public override void UpdateState(BodyStateManager body)
    {
        Debug.Log(body.input);
        
        if (body.input.x > 0)
        {
            body.SwitchState(body.DireitaState);
        }

        if (body.input.x < 0)
        {
            body.SwitchState(body.EsquerdaState);
        }

        if(body.input.y > 0)
        {
            body.SwitchState(body.CimaState);
        }

        if (body.input.y < 0)
        {
            body.SwitchState(body.BaixoState);
        }
        
    
    }

    public override void OnCollisionEnter(BodyStateManager boss, Collision collision)
    {

    }
    
    public override void OnTriggerEnter(BodyStateManager boss, Collider2D collider)
    {
        
    }
}
