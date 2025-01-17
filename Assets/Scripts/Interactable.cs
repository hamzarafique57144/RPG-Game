using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocus = false;
    bool hasFocused = false;
    Transform player;
    public Transform interactionTransform;
    public virtual void Interact()
    {
        //This method is to meant ovverWritten
        
    }
    private void Update()
    {
        if(isFocus && hasFocused)
        {
            
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
               
                Interact();
                hasFocused = false;
            }
        }
    }
    public void OnFocused(Transform newPlayer)
    {
        isFocus = true;
        player = newPlayer;
        hasFocused = true;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasFocused = false;
    }
    void OnDrawGizmosSelected()
    {
        if(interactionTransform==null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
