using System.Collections;
using UnityEngine;

public class DirBState : BodyBaseState
{
    public Animator head;
    BodyStateManager Script_Original;

    public DirBState(Animator head1, BodyStateManager Script_Originals)
    {
        this.head = head1;
        this.Script_Original = Script_Originals;
    }

    public override void EnterState(BodyStateManager body)
    {
        head.SetBool("Direita", true);

        // CORREÇÃO: Usa o 'body' para iniciar a Corrotina
        body.StartCoroutine(Wait(body));
    }

    public override void UpdateState(BodyStateManager body)
    {
        // Debug.Log("Entrou"); // Cuidado com o spam no console aqui
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
        while (body.input.y !< 0)
        {
            yield return new WaitForFixedUpdate();
        }
        head.SetBool("Baixo", false);
        body.SwitchState(body.IdleState);
        yield return null;
    }
}