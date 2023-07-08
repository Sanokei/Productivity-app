using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CoridorTrigger : MonoBehaviour
{
    [SerializeField] DoorManager EnterDoor;
    [SerializeField] DoorManager ExitDoor;
    [SerializeField] ShootShootGoUp ssgu;
    [SerializeField] PlayableDirector room_2;
    bool _Triggered = false;
    bool _2Triggered = false;
    void OnEnable()
    {
        AreaTrigger.OnEnterEvent += OnEnter;
    }

    void OnDisable()
    {
        AreaTrigger.OnEnterEvent -= OnEnter;
    }

    void OnEnter(string name)
    {
        if(name == "FirstTrigger" && !_Triggered)
        {
            _Triggered = true;
            EnterDoor.CloseDoor();
            ExitDoor.OpenDoor();
        }
        if(name == "SecondTrigger" && !_2Triggered)
        {
            _2Triggered = true;
            ExitDoor.CloseDoor();
            ssgu.WallsGoUp();
            room_2.Play();
        }
    }
}
