using UnityEngine;

public class FowardMovement : AnimalMovement
{
    protected override void TerrestrialMovement()
    {
        if (Context.Rigidbody == null) return;

        float angleY = Context.Rigidbody.rotation.eulerAngles.y;
        angleY = (angleY > 180f ? angleY - 360f : angleY) + TouchController.Instance.HorizontalDirection * 0.5f * Time.fixedDeltaTime;
        angleY = Mathf.Clamp(angleY, -50f, 50f);

        Context.Rigidbody.MoveRotation(Quaternion.Euler(0f, angleY, 0f));
        Context.Rigidbody.MovePosition(Context.Rigidbody.position + Context.Rigidbody.transform.forward * (Context.AnimalStatus.MoveSpeed * Time.fixedDeltaTime));
    }
}