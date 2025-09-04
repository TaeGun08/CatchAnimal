using System;
using System.Collections;
using UnityEngine;

public class Player : SingletonBehaviour<Player>, IObstacleCollision
{
    private Animator animator;
    private Rigidbody rigidbody;
    private Collider collider;
    public Animal Animal { get; private set; }

    public bool IsRiding { get; set; }

    protected virtual void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    public void ChangeAnimation(string animation)
    {
        animator.SetTrigger(animation);
    }
    
    public void Riding(Animal animal)
    {
        rigidbody.isKinematic = true;
        collider.isTrigger = true;
        Animal = animal;
        animal.AnimalController.ChangeState<AnimalRunState>();
        transform.parent = animal.transform;
        transform.localPosition = animal.RidingOffset;
        IsRiding = true;
    }

    public void Dismount()
    {
        rigidbody.isKinematic = false;
        collider.isTrigger = false;
        Animal.AnimalController.ChangeState<AnimalAutoState>();
        transform.parent = null;
        Jump();
        IsRiding = false;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * 10f, ForceMode.Impulse);
        rigidbody.AddForce(transform.forward * 10f, ForceMode.Impulse);
    }


    public void HitObstacle()
    {
        
    }
}
