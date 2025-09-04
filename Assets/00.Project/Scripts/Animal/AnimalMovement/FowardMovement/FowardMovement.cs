using UnityEngine;

public class FowardMovement : AnimalMovement
{
    protected override void TerrestrialMovement()
    {
        if (Context.Rigidbody == null) return;
        
        float angleY = Context.Rigidbody.rotation.eulerAngles.y;
        angleY = (angleY > 180f ? angleY - 360f : angleY) + TouchController.Instance.HorizontalDirection * Time.fixedDeltaTime;
        angleY = Mathf.Clamp(angleY, -50f, 50f);
        Context.Rigidbody.MoveRotation(Quaternion.Euler(0f, angleY, 0f));
        
        Vector3 forwardVelocity = Context.Rigidbody.transform.forward * Context.AnimalStatus.MoveSpeed;
        Context.Rigidbody.linearVelocity = new Vector3(forwardVelocity.x, Context.Rigidbody.linearVelocity.y, forwardVelocity.z);
    }
}