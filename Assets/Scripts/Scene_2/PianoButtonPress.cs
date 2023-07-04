using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PianoButtonPress : MonoBehaviour
{
    [SerializeField] Camera _Camera;
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
            
        if (Physics.Raycast(_Camera.ScreenPointToRay(Input.mousePosition), out hitData, 5) && hitData.transform.tag == "PianoButton")
        {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
            {
                anim.clip = ButtonPress;
                anim.Play();
                _buttonPressed++;
                Debug.Log(_buttonPressed);
                int dialog1 = 10;
                int dialog2 = 45;
                if(_buttonPressed < dialog2)
                {
                    Cheer.Play();
                }

                if(_buttonPressed >= dialog2)
                {
                    Boo.Play();
                }

                if(_buttonPressed == dialog1)
                {
                    PressTwice.Play();
                }
                if(_buttonPressed == dialog2 + 3)
                {
                    PressFive.Play();
                }
            }
        }
    }
}
