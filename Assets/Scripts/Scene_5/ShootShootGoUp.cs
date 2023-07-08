using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class ShootShootGoUp : MonoBehaviour
{
    [SerializeField] GameObject Walls;

    public void WallsGoUp()
    {
        Walls.transform.localPositionTransition(new Vector3(Walls.transform.localPosition.x, Walls.transform.localPosition.y + 2.59f, Walls.transform.localPosition.z) ,1);
    }
}
