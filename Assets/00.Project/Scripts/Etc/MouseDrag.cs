using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class MouseDrag : MonoBehaviour
{
    [SerializeField] private GameObject ballObject;
    [SerializeField] private float forwardDistance = 10f;   // 전방 기본 거리
    [SerializeField] private float height = 5f;             // 궤적 높이
    [SerializeField] private int lineResolution = 30;       // 라인 세분화
    [SerializeField] private int circleResolution = 40;     // 원 세분화
    [SerializeField] private float circleRadius = 1.0f;     // 원 반지름
    [SerializeField] private Material circleMaterial;       // 원 표시용 머티리얼

    private LineRenderer lineRenderer;
    private LineRenderer circleRenderer;
    private Vector2 touchStart;
    private Vector2 touchEnd;
    private bool isDragging;
    private GameObject currentBall;

    private void Awake()
    {
        // 궤적 라인
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;

        // 원 전용 라인 렌더러 생성
        GameObject circleObj = new GameObject("TargetCircle");
        circleRenderer = circleObj.AddComponent<LineRenderer>();
        circleRenderer.loop = true;
        circleRenderer.widthMultiplier = 0.05f;
        circleRenderer.material = circleMaterial;
        circleRenderer.positionCount = 0;
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStart = touch.position;
                    BallInstantiate();
                    isDragging = true;
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    touchEnd = touch.position;
                    DrawTrajectory();
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    lineRenderer.positionCount = 0;
                    circleRenderer.positionCount = 0;
                    LaunchBall();
                    break;
            }
        }
    }

    private void BallInstantiate()
    {
        if (currentBall != null) Destroy(currentBall);
        currentBall = Instantiate(ballObject, transform.position + Vector3.up, Quaternion.identity);
    }

    private void DrawTrajectory()
    {
        Vector2 dragDelta = (touchEnd - touchStart) / Screen.height;

        float distance = forwardDistance + dragDelta.y * forwardDistance;
        float side = dragDelta.x * 5f;

        Vector3 p0 = transform.position + Vector3.up;
        Vector3 p3 = p0 + transform.forward * distance + transform.right * side;

        Vector3 p1 = p0 + (transform.forward * (distance * 0.3f)) + Vector3.up * height;
        Vector3 p2 = p0 + (transform.forward * (distance * 0.6f)) + Vector3.up * height;

        // 라인 렌더러 궤적
        lineRenderer.positionCount = lineResolution;
        for (int i = 0; i < lineResolution; i++)
        {
            float t = i / (float)(lineResolution - 1);
            lineRenderer.SetPosition(i, Cubic(p0, p1, p2, p3, t));
        }

        // 원 그리기
        DrawCircle(p3);
    }

    private void LaunchBall()
    {
        if (currentBall == null) return;

        Vector2 dragDelta = (touchEnd - touchStart) / Screen.height;
        float distance = forwardDistance + dragDelta.y * forwardDistance;
        float side = dragDelta.x * 5f;

        Vector3 p0 = transform.position + Vector3.up;
        Vector3 p3 = p0 + transform.forward * distance + transform.right * side;
        Vector3 p1 = p0 + (transform.forward * (distance * 0.3f)) + Vector3.up * height;
        Vector3 p2 = p0 + (transform.forward * (distance * 0.6f)) + Vector3.up * height;

        StartCoroutine(FlyAlongBezier(currentBall, p0, p1, p2, p3, 1f));
    }

    private void DrawCircle(Vector3 center)
    {
        circleRenderer.positionCount = circleResolution;
        for (int i = 0; i < circleResolution; i++)
        {
            float angle = i * Mathf.PI * 2f / circleResolution;
            float x = Mathf.Cos(angle) * circleRadius;
            float z = Mathf.Sin(angle) * circleRadius;
            circleRenderer.SetPosition(i, new Vector3(center.x + x, center.y, center.z + z));
        }
    }

    private IEnumerator FlyAlongBezier(GameObject ball, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            float t = time / duration;
            ball.transform.position = Cubic(p0, p1, p2, p3, t);
            time += Time.deltaTime;
            yield return null;
        }
        ball.transform.position = p3;
    }

    private Vector3 Cubic(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float u = 1f - t;
        return u * u * u * p0
               + 3f * u * u * t * p1
               + 3f * u * t * t * p2
               + t * t * t * p3;
    }
}
