using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector2(GameManager.Instance.ScrollCamera()*Time.deltaTime,0));
    }
}
