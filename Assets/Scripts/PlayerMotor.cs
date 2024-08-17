using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    private Transform target;
    private float rotationSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(target!=null)
        {
            agent.SetDestination(target.position);
            FaceRotation();
        }
    }
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        target = newTarget.interactionTransform;
        agent.stoppingDistance = newTarget.radius * .8f;
        //To Rotate towards the target if target changing position
        agent.updateRotation = false;
    }

    public void StopFollowing()
    {
        target = null;
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
    }

    private void FaceRotation()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion  lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation, rotationSpeed*Time.deltaTime);
    }
}
