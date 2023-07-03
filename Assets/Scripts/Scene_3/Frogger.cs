using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Frogger : MonoBehaviour
{
    [SerializeField] List<PlayableDirector> Dialogue = new List<PlayableDirector>();

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
        Debug.Log(name);
    }
}
