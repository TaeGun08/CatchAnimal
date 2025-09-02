using System;
using UnityEngine;

public abstract class AnimalMovement : MonoBehaviour
{
    public AnimalContext Context { get; set; }

    public virtual void Initialize(AnimalContext context)
    {
        Context = context;
    }
    
    protected void FixedUpdate()
    {
        TerrestrialMovement();
        AerialMovement();
        AquaticMovement();
    }

    protected virtual void TerrestrialMovement(){}

    protected virtual void AerialMovement(){}
    
    protected virtual void AquaticMovement(){}
}
