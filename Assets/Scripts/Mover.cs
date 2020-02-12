using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    Camera mainCamera;
    Ray lastRay;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
         
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
        //Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
        //navMeshAgent.SetDestination(target.position);
    }
    private void MoveToCursor()
    {
        RaycastHit hit;
        lastRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(lastRay, out hit))
        {
            navMeshAgent.SetDestination(hit.point);
        }
    }
}
