using UnityEngine;

public abstract class BodyBaseState
{
    public abstract void EnterState(BodyStateManager body);

    public abstract void UpdateState(BodyStateManager body);

    public abstract void OnCollisionEnter(BodyStateManager body, Collision collision);

    public abstract void OnTriggerEnter(BodyStateManager body, Collider2D collider);
}