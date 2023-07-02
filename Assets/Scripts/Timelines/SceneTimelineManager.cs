using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using BuildingBlocks.DataTypes;

public class SceneTimelineManager : MonoBehaviour //TODO: this is a shit solution
{
    [SerializeField] PlayableDirector StarterTimeline;
    [SerializeField] InspectableDictionary<string, PlayableDirector> OnEnter = new InspectableDictionary<string, PlayableDirector>();
    [SerializeField] InspectableDictionary<string, PlayableDirector> OnExit = new InspectableDictionary<string,PlayableDirector>();

    string OnEnterString = "";
    string OnExitString = "";

    PlayableDirector CurrentTimeline;

    void OnEnable()
    {
        AreaTrigger.OnEnterEvent += AddOnEnterString;
        AreaTrigger.OnExitEvent += AddOnExitString;
    }

    void OnDisable()
    {
        AreaTrigger.OnEnterEvent -= AddOnEnterString;
        AreaTrigger.OnExitEvent -= AddOnExitString;
    }

    void AddOnEnterString(string name)
    {
        OnEnterString += name;
        CheckStrings(OnEnter, OnEnterString);
    }
    void AddOnExitString(string name)
    {
        OnExitString += name;
        CheckStrings(OnExit, OnExitString);
    }

    void Start()
    {
        if(StarterTimeline)
        {
            CurrentTimeline = StarterTimeline;
            CurrentTimeline.Play();
        }
        else
        {
            Debug.LogError($"No StarterTimeline set for {gameObject.name}");
        }
    }

    bool CheckStrings(InspectableDictionary<string, PlayableDirector> dic, string name)
    {
        PlayableDirector pd;
        dic.TryGetValue(name, out pd);
        if(pd)
        {
            CurrentTimeline?.Stop();
            CurrentTimeline = pd;
            CurrentTimeline.Play();
            return true;
        }
        return false;
    }
}
