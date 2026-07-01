using UnityEngine;

public class DirPState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("OI");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {
         
    }

    public override void OnTriggerEnter(PlayerStateManager player, Collider2D collider)
    {
       // boss.SwitchState(boss.PrepAtaqueState);
    }
}
