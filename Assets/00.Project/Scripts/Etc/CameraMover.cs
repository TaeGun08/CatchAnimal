using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Transform target;
    
    [Header("View")]
    public float rotX = 45f;
    public float rotY = 45f;

    [Header("Offset")]
    public Vector3 offsetXZ = Vector3.zero;

    [Header("Follow")]
    public float smoothTime = 0.12f;
    public float lookAhead = 0.15f;
    public float maxAheadDistance = 2f; 
    public float velocitySmoothSpeed = 5f; 

    [Header("Rotation Limits")]
    public float minY = -70f;
    public float maxY = 70f;

    [Header("Follow Limits")]
    public float minX = -10f;
    public float maxX = 10f;

    private Rigidbody targetRigidbody;
    private Vector3 velocity;
    private Vector3 smoothedVelocity;

    private void OnEnable()
    {
        target = Player.Instance.transform;
        transform.rotation = Quaternion.Euler(rotX, rotY, 0f);
        targetRigidbody = target ? target.GetComponent<Rigidbody>() : null;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = targetRigidbody ? targetRigidbody.position : target.position;
        Vector3 targetVel = targetRigidbody ? targetRigidbody.linearVelocity : Vector3.zero;

        smoothedVelocity = Vector3.Lerp(smoothedVelocity, targetVel, Time.deltaTime * velocitySmoothSpeed);

        Vector3 ahead = Vector3.ProjectOnPlane(smoothedVelocity, Vector3.up) * lookAhead;
        if (ahead.magnitude > maxAheadDistance)
            ahead = ahead.normalized * maxAheadDistance;

        Vector3 flatOffset = Quaternion.Euler(0f, rotY, 0f) * offsetXZ;
        Vector3 forwardFlat = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;

        Vector3 desiredPos = targetPos + flatOffset + ahead + Vector3.up - forwardFlat;
        
        desiredPos.x = Mathf.Clamp(desiredPos.x, minX, maxX);

        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);

        rotY = Mathf.Clamp(rotY, minY, maxY);
        transform.rotation = Quaternion.Euler(rotX, rotY, 0f);
    }

}
