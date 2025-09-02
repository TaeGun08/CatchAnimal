using UnityEngine;

public class AutoMove : AutoBehavior
{
    public override void Behavior()
    {
        Context.Rigidbody.MovePosition(Context.Rigidbody.position + Context.Rigidbody.transform.forward *
            (Context.AnimalStatus.MoveSpeed * 0.65f * Time.deltaTime));
    }
}