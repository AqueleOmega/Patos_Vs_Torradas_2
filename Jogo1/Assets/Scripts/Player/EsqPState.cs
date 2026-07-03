using System.Collections;
using UnityEngine;

public class EsqPState : PlayerBaseState
{
    public Animator head;

    public EsqPState(Animator head1)
    {
        this.head = head1;
    }

    public override void EnterState(PlayerStateManager player)
    {
        head.SetBool("Esquerda", true);

        
        player.StartCoroutine(Wait(player));
    }

    public override void UpdateState(PlayerStateManager player)
    {
        // Debug.Log("Entrou"); 
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {

    }

    public override void OnTriggerEnter(PlayerStateManager player, Collider2D collider)
    {
        player.SwitchState(player.IdleState);
    }

    private IEnumerator Wait(PlayerStateManager player)
    {
        yield return new WaitForSeconds(0.8f);
        head.SetBool("Esquerda", false);
        Debug.Log("Oi");
        player.SwitchState(player.IdleState);
    }
}