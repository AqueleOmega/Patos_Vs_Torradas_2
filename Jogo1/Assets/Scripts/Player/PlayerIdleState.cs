using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class PlayerStateIdle : PlayerBaseState
{

    Animator head;
    PlayerStateManager Script_Original;

    public PlayerStateIdle(Animator head1, PlayerStateManager Script_Originals)
    {
        this.head = head1;
        this.Script_Original = Script_Originals;
    }
    

    public override void EnterState(PlayerStateManager player){

        // Ao inicializar o state idle eu já lanço o método de escolher o próximo
        // state. Eu poderia esperar, se quissesse.
        //Escolher(player);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        Debug.Log(player.input);
        
        if (player.input.x > 0)
        {
            player.SwitchState(player.DireitaState);
        }
        if (player.input.x < 0)
        {
            player.SwitchState(player.EsquerdaState);
        }

        if(player.input.y > 0)
        {
            player.SwitchState(player.CimaState);
        }

        if (player.input.y < 0)
        {
            player.SwitchState(player.BaixoState);
        }
        
    
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {

    }
    
    public override void OnTriggerEnter(PlayerStateManager player, Collider2D collider)
    {
        
    }
}
