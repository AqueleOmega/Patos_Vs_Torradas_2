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
        if (player.input.x < 0 && player.input.y < 0)
        {
            Debug.Log(player.input);
            player.SwitchState(player.diagEsqYState);
        }

        else if (player.input.x > 0 && player.input.y < 0)
        {
            Debug.Log(player.input);
            player.SwitchState(player.diagDirYState);
        }

        else if (player.input.x < 0 && player.input.y > 0)
        {
            Debug.Log(player.input);
            player.SwitchState(player.diagEsqState);
        }

        else if (player.input.x > 0 && player.input.y > 0)
        {
            Debug.Log(player.input);
            player.SwitchState(player.diagDirState);
        }
        
        else if (player.input.x > 0)
        {
            player.SwitchState(player.DireitaState);
        }
        else if (player.input.x < 0)
        {
            player.SwitchState(player.EsquerdaState);
        }

        else if (player.input.y > 0)
        {
            player.SwitchState(player.CimaState);
        }

        else if (player.input.y < 0)
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
