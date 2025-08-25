using UnityEngine;

public class FowardMove : AnimalMove
{
    protected override void Move()
    {
        Vector3 move = Vector3.forward * (AnimalState.AnimalStatus.MoveSpeed * Time.fixedDeltaTime);
        AnimalState.Rigidbody?.MovePosition(AnimalState.transform.position + move);
    }
}
