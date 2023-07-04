using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Frogger : MonoBehaviour
{
    [SerializeField] List<PlayableDirector> Dialogue = new List<PlayableDirector>();
    [SerializeField] List<PlayableDirector> CarHitDialogue = new List<PlayableDirector>();
    [SerializeField] PlayableDirector EndingDialogue;
    [SerializeField] PlayableDirector DefaultCarPD;

    [SerializeField] CharacterController Player;
    [SerializeField] GameObject StartingArea;

    int DialogueNum = 1;
    int CarHitDialogueNum = 0;
    PlayableDirector CurrentTimeline;

    void OnEnable()
    {
        AreaTrigger.OnEnterEvent += OnEnter;
    }

    void OnDisable()
    {
        AreaTrigger.OnEnterEvent -= OnEnter;
        CurrentTimeline.stopped -= OnDialogStop;
    }
    void Start()
    {
        playCurrentTimeline(Dialogue[0]);
    }

    void OnEnter(string name)
    {
        if(name == "car")
        {
            try
            {
                CurrentTimeline.stopped -= OnDialogStop;
                CurrentTimeline.Stop();
                TeleportBackToStart();
                playCurrentTimeline(CarHitDialogue[CarHitDialogueNum]);
                CarHitDialogueNum++;
            }
            catch(System.IndexOutOfRangeException e)
            {
                playCurrentTimeline(DefaultCarPD);
                Debug.Log($"Out of Dialogue: {name} {CarHitDialogueNum}");
            } 
        }
        if(name == "end")
        {
            CurrentTimeline.stopped -= OnDialogStop;
            CurrentTimeline.Stop();
            EndingDialogue.Play();
        }
    }
    void OnDialogStop(PlayableDirector pd)
    {
        
        Player.enabled = true;
        Debug.Log($"{pd.name}  {DialogueNum}");
        CurrentTimeline.stopped -= OnDialogStop;
        try
        {
            playCurrentTimeline(Dialogue[DialogueNum]);
            DialogueNum++;
        }
        catch(System.IndexOutOfRangeException e)
        {
            Debug.Log($"Out of Dialogue: {pd}");
        }
    }
    void playCurrentTimeline(PlayableDirector pd)
    {
        CurrentTimeline?.Stop();
        CurrentTimeline = pd;
        CurrentTimeline.Play();
        CurrentTimeline.stopped += OnDialogStop;
    }

    public void TeleportBackToStart()
    {
        Player.enabled = false;
        Player.transform.position = StartingArea.transform.position;
    }
}
