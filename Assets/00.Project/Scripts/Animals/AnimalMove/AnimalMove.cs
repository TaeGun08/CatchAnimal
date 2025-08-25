using System;
using UnityEngine;

public abstract class AnimalMove : MonoBehaviour
{
    public AnimalState AnimalState { get; set; }

    protected void FixedUpdate()
    {
        Move();
    }

    protected abstract void Move();
}
