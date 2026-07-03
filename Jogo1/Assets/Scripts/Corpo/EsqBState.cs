using System.Collections;
using UnityEngine;

public class EsqBState : BodyBaseState
{
    public Animator head;
    BodyStateManager Script_Original;

    public EsqBState(Animator head1, BodyStateManager Script_Originals)
    {
        this.head = head1;
        this.Script_Original = Script_Originals;
    }

    public override void EnterState(BodyStateManager body)
    {
        head.SetBool("Esquerda", true);

        
        body.StartCoroutine(Wait(body));
    }

    public override void UpdateState(BodyStateManager body)
    {
        // Debug.Log("Entrou");
    }

    public override void OnCollisionEnter(BodyStateManager body, Collision collision)
    {

    }

    public override void OnTriggerEnter(BodyStateManager body, Collider2D collider)
    {
        body.SwitchState(body.IdleState);
    }

    private IEnumerator Wait(BodyStateManager body)
    {
        while (body.input.x < 0)
        {
            yield return new WaitForFixedUpdate();
        }
        head.SetBool("Esquerda", false);
        body.SwitchState(body.IdleState);
    }
}