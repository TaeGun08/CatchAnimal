using System;
using UnityEngine;

public class AnimalRunState : AnimalStateBase
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
        animalMovement.enabled = true;
    }

    public override void StateExit()
    {
        animalMovement.enabled = false;
    }
}