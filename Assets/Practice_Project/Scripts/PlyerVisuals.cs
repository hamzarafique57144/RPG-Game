using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlyerVisuals : MonoBehaviour
{
    [SerializeField] Material defualtMaterial;
    [SerializeField] TextMeshProUGUI message;

    [SerializeField] ObjectSO objectSO;
    void Start()
    {
        PlayerController.Instance.OnInteraction += PlayerController_OnInteraction;
    }

    private void PlayerController_OnInteraction(object sender, System.EventArgs e)
    {
        /*gameObject.GetComponent<MeshFilter>().sharedMesh = PlayerController.Instance.GetInteraction().GetObjectSo().GetObjectsSOClass().meshFilter.sharedMesh;
        gameObject.GetComponent<MeshRenderer>().material = PlayerController.Instance.GetInteraction().GetObjectSo().GetObjectsSOClass().Objectmaterail;
        message.text = PlayerController.Instance.GetInteraction().GetObjectSo().GetObjectsSOClass().message;*/

        gameObject.GetComponent<MeshFilter>().sharedMesh = objectSO.GetObjectsSOClass().meshFilter.sharedMesh;
        gameObject.GetComponent<MeshRenderer>().material = objectSO.GetObjectsSOClass().Objectmaterail;
        message.text = objectSO.GetObjectsSOClass().message;
    }

    
}
