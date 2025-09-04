using System;
using UnityEngine;

public class TouchController : SingletonBehaviour<TouchController>
{
    private Vector2 touchStartPosition;
    private Vector2 touchCurrentPosition;

    public float HorizontalDirection { get; private set; }
    [SerializeField] private float slideSpeed;
    
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    touchCurrentPosition = touch.position;
                    Vector2 delta = touchCurrentPosition - touchStartPosition;

                    HorizontalDirection = delta.x * slideSpeed;
                    break;
                case TouchPhase.Ended:
                    Player.Instance.Dismount();
                    touchStartPosition = Vector2.zero;
                    HorizontalDirection = 0;
                    break;
            }
        }
    }
}