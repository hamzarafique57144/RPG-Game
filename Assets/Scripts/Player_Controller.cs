using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class Player_Controller : MonoBehaviour
{
    PlayerMotor motor;
    [SerializeField] LayerMask movemntMask;
    private float rayHitDistance = 100f;
    Camera cam;

    private Interactable focus;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        cam = Camera.main;
    }

   
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if(Physics.Raycast(ray,out raycastHit,rayHitDistance,movemntMask) )
            {
               motor.MoveToPoint(raycastHit.point);
                RemoveFocus();
            }
        }

        //If we press the right mouse
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if(Physics.Raycast(ray,out raycastHit,rayHitDistance))
            {
                Interactable interactable = raycastHit.collider.GetComponent<Interactable>();
                if( interactable != null )
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    private void SetFocus(Interactable newFocus)
    {
        if(newFocus!= focus)
        {
            if (focus!= null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        
        newFocus.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
       // focus.OnDefocused();
        focus = null;
        motor.StopFollowing();
    }

    
}
