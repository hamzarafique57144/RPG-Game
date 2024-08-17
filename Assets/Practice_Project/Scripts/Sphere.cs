using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Search;
using UnityEngine;
using static ObjectSO;

public class Sphere :  I_Interaction
{
    [SerializeField] ObjectSO objectSO;
    [SerializeField] private I_Interaction i_Interaction;

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

            ObjectSO.objectSelected = ObjectSelected.sphere;
        }
        else
        {
            Hide();
        }
    }

    

    private void Show()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    private void Hide()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
   

    public override ObjectSO GetObjectSo()
    {
        return objectSO;
    }
}
