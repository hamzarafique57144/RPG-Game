using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
   
    
    [SerializeField] float moveSpeed = 5f;
    public event EventHandler OnInteraction;
    float rayDistance = 5f;
    private float rotateSpeed = 75f;

    public event EventHandler<InteractedObject> OnItneractionDone;

    Vector3 lastInteraction = new Vector3();
    private I_Interaction i_interaction;
    public class InteractedObject
    {
        public I_Interaction i_interaction;
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
       
        
    }

    private void Update()
    {
        
        MovePlayer();
       
    }

    private Vector2 GetMovementVector()
    {
        Vector2 inputVector = new Vector2();
        if (Input.GetKey(KeyCode.UpArrow))
            inputVector.y = +1;
        if (Input.GetKey(KeyCode.DownArrow))
            inputVector.y = -1;
        if (Input.GetKey(KeyCode.LeftArrow))
            inputVector.x = -1;
        if (Input.GetKey(KeyCode.RightArrow))
            inputVector.x = +1;
        inputVector = inputVector.normalized;
        return inputVector;
    }

    private void MovePlayer()
    {
        Vector2 inputVector = GetMovementVector();
        Vector3 movDir = new Vector3 (inputVector.x, 0, inputVector.y);
       if(movDir!=Vector3.zero)
        {
            lastInteraction = movDir;
        }
       // float detectionDistance = 0.1f;
        
        bool canWalk = !Physics.Raycast(transform.position, lastInteraction, rayDistance);
        if(canWalk)
        {
            
            transform.position += movDir * moveSpeed * Time.deltaTime;
            
        }
       
        if(movDir!= Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, movDir, rotateSpeed * Time.deltaTime);//For player rotation
        }
      
        if (Physics.Raycast(transform.position, lastInteraction, out RaycastHit raycastHit, rayDistance))
        {
            if (raycastHit.transform.TryGetComponent(out I_Interaction i_Interaction))
            {
                
                SetObjectSelected(i_Interaction);
                i_interaction = i_Interaction;
                OnInteraction?.Invoke(this, EventArgs.Empty);

            }
           
           
        }
        else
        {
            SetObjectSelected(null);
        }

    }

    private void SetObjectSelected(I_Interaction i_Interaction)
    {
        
        OnItneractionDone?.Invoke(this,new  InteractedObject{
            i_interaction = i_Interaction 
        });
    }

    public I_Interaction GetInteraction()
    {
        return i_interaction;
    }
}
