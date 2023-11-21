using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    [SerializeField] private float speedCamera;
    void Update()
    {
        transform.position+=new Vector3(speedCamera*Time.deltaTime,0,0);
    }
}
