using System;
using UnityEngine;

public abstract class AnimalState : MonoBehaviour
{
    public AnimalController Controller { get; private set; }
    public Animator[] Animators { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public AnimalStatus AnimalStatus { get; private set; }
    
    public virtual void Initialize(AnimalContext context)
    {
        Controller = context.Controller;
        Animators = context.Animators;
        Rigidbody = context.Rigidbody;
        AnimalStatus = context.AnimalStatus;
    }
    
    public abstract void StateEnter();
    public abstract void StateExit();
}
