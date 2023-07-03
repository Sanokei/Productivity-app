using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PianoButtonPress : MonoBehaviour
{
    [SerializeField] AnimationClip ButtonPress;
    [SerializeField] Animation anim;
    [SerializeField] PlayableDirector PressTwice;
    [SerializeField] PlayableDirector PressFive;
    [SerializeField] PlayableDirector Cheer;
    [SerializeField] PlayableDirector Boo;
    Ray ray;
    RaycastHit hitData;
    int _buttonPressed = 0;
    
    void Update()
    {
            
        if (Physics.Raycast(PlayerMovement.Instance.playerCamera.ScreenPointToRay(Input.mousePosition), out hitData, 5) && hitData.transform.tag == "PianoButton")
        {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
            {
                anim.clip = ButtonPress;
                anim.Play();
                _buttonPressed++;

                if(_buttonPressed < 9)
                {
                    Cheer.Play();
                }

                if(_buttonPressed >= 9)
                {
                    Boo.Play();
                }

                if(_buttonPressed == 4)
                {
                    PressTwice.Play();
                }
                if(_buttonPressed == 9)
                {
                    PressFive.Play();
                }
            }
        }
    }
}
