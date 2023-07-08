using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class DoorManager : MonoBehaviour
{
    [SerializeField] GameObject LeftDoor;
    [SerializeField] GameObject RightDoor;
    public void OpenDoor()
    {
        LeftDoor.transform.localPositionTransition(new Vector3(LeftDoor.transform.localPosition.x, LeftDoor.transform.localPosition.y, LeftDoor.transform.localPosition.z + 3) , 1);
        RightDoor.transform.localPositionTransition(new Vector3(RightDoor.transform.localPosition.x, RightDoor.transform.localPosition.y, RightDoor.transform.localPosition.z - 3) ,1);
    }

    public void CloseDoor()
    {
        LeftDoor.transform.localPositionTransition(new Vector3(LeftDoor.transform.localPosition.x, LeftDoor.transform.localPosition.y, LeftDoor.transform.localPosition.z - 3) , 1);
        RightDoor.transform.localPositionTransition(new Vector3(RightDoor.transform.localPosition.x, RightDoor.transform.localPosition.y, RightDoor.transform.localPosition.z + 3) ,1);
    }
}
