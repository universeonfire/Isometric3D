using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] Transform camTarget;
    //Order of execution 
    void LateUpdate()
    {
        transform.position = camTarget.position;
    }
}
