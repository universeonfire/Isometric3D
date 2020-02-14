using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Camera mainCamera;
    private Ray ray;
    private Animator animator;
    private Vector3 worldVelocity;
    private Vector3 localVelocity;
    private float playerSpeed;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        worldVelocity = navMeshAgent.velocity;
        localVelocity = transform.InverseTransformDirection(worldVelocity);
        playerSpeed = localVelocity.z;
        animator.SetFloat("Forward", playerSpeed);
    }

    private void MoveToCursor()
    {
        RaycastHit hit;
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
   
        if (Physics.Raycast(ray, out hit))
        {
            navMeshAgent.SetDestination(hit.point);
        }
    }
}
