using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] ships;
    [SerializeField] private int shipIndex = 0;

    private void Start()
    {
        shipIndex = PlayerPrefs.GetInt("SelectShip", 0);
        foreach (GameObject ship in ships)
        {
            ship.SetActive(false);
        }
        ships[shipIndex].SetActive(true);
    }
}
