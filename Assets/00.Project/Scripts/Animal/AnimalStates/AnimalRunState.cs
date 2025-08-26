using System;
using UnityEngine;

public class AnimalRunState : AnimalState
{
    private AnimalMovement animalMovement;

    public override void Initialize(AnimalContext context)
    {
        base.Initialize(context);

        if (animalMovement == null)
        {
            animalMovement = GetComponent<AnimalMovement>();
        }
        
        animalMovement.Initialize(context);
    }

    public override void StateEnter()
    {
    }

    public override void StateExit()
    {
    }
}