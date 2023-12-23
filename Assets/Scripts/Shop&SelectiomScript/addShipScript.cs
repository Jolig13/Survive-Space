using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipS : MonoBehaviour
{
    [SerializeField] private List<GameObject>ship;
    void Start()
    {
        var index=PlayerPrefs.GetInt("ShipInt");
        Instantiate(ship[index],this.transform.position,this.transform.rotation);
    }
}
