using System;
using UnityEngine;

public class AnimalRunState : AnimalState
{
    private AnimalMove animalMove;

    public override void StateEnter()
    {
        animalMove = GetComponent<AnimalMove>();
        animalMove.AnimalState = this;
    }

    public override void StateExit()
    {

    }
}
