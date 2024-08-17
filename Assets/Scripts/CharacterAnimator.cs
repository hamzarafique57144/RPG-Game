using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float animationSmoothTime = 0.1f;
    NavMeshAgent agent;
   [SerializeField] Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("SpeedPercent",speedPercent, animationSmoothTime, Time.deltaTime);
    }
}
