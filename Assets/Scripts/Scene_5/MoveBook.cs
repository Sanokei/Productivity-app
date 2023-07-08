using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Lean.Transition;

public class MoveBook : MonoBehaviour
{
    bool _BookMoved = false;
    [SerializeField] Camera _Camera;
    Ray ray;
    RaycastHit hitData;
    [SerializeField] PlayableDirector starter;
    void Update()
    {
        if (Physics.Raycast(_Camera.ScreenPointToRay(Input.mousePosition), out hitData, 5) && hitData.transform.tag == "Book")
        {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
            {
                if(!_BookMoved)
                {
                    _BookMoved = true;
                    MovingBook();
                    starter.Play();
                }
            }
        }
    }

    void MovingBook()
    {
        transform.localPositionTransition(new Vector3(transform.position.x, transform.position.y, transform.position.z + 3) ,2);
    }
}
