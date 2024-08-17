using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using static ObjectSO;

public class Wall :  I_Interaction
{
    [SerializeField ] ObjectSO objectSO;
   [SerializeField] I_Interaction i_Interaction;
    private void Start()
    {
        
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
       
        PlayerController.Instance.OnItneractionDone += PlayerController_OnItneractionDone;
    }

    private void PlayerController_OnItneractionDone(object sender, PlayerController.InteractedObject e)
    {
     


        if (e.i_interaction == i_Interaction)
        {
              Debug.Log("InteractionDoneEvent");
            Show();

            ObjectSO.objectSelected = ObjectSelected.wall;
        }
        else
        {
            Hide();
        }
    }

    

   

   
    private void Hide()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    private void Show()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public override ObjectSO GetObjectSo()
    { 
        return objectSO;
    }
}
