using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class PlayerStateIdle : PlayerBaseState
{

    Vector2 input;
    Animator head;

    public PlayerStateIdle(Vector2 input1, Animator head1)
    {
        this.input = input1;
        this.head = head1;
    }
    

    public override void EnterState(PlayerStateManager player){

        // Ao inicializar o state idle eu já lanço o método de escolher o próximo
        // state. Eu poderia esperar, se quissesse.
        //Escolher(player);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        Debug.Log(input);
        if (input.x > 0)
        {
            player.SwitchState(player.DireitaState);
        }
    
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {

    }
    
    public override void OnTriggerEnter(PlayerStateManager player, Collider2D collider)
    {
        
    }
}
