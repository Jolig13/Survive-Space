using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class shopManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] shipModels;
    [SerializeField] private int shipIndex = 0;
    [SerializeField] private Button unlockButton;
    public shipsData[] dataShip;
    [SerializeField] private TextMeshProUGUI textCoin;

    private void Start()
    {
        foreach (shipsData ship in dataShip)
        {
            if (ship.costShip == 0)
            {
                ship.isUnlocked = true;
            }
            else
            {
                ship.isUnlocked = PlayerPrefs.GetInt(ship.nameShip, 0) == 0 ? false : true;
            }
        }
        shipIndex = PlayerPrefs.GetInt("SelectShip", 0);
        foreach (GameObject ship in shipModels)
        {
            ship.SetActive(false);
        }
        shipModels[shipIndex].SetActive(true);


        //textCoin.text = ":" + GameManager.totalCoins.ToString();
    }
    private void Update()
    {
        UpdateUI();
        textCoin.text = ":" + GameManager.totalCoins.ToString();
    }
    public void NextShip()
    {
        shipModels[shipIndex].SetActive(false);
        shipIndex++;
        if (shipIndex == shipModels.Length)
        {
            shipIndex = 0;
        }
        shipModels[shipIndex].SetActive(true);
        shipsData ships = dataShip[shipIndex];
        if (!ships.isUnlocked)
        {
            return;
        }

        PlayerPrefs.SetInt("SelectShip", shipIndex);
    }
    public void PreviousShip()
    {
        shipModels[shipIndex].SetActive(false);
        shipIndex--;
        if (shipIndex == -1)
        {
            shipIndex = shipModels.Length - 1;
        }
        shipModels[shipIndex].SetActive(true);
        shipsData ships = dataShip[shipIndex];
        if (!ships.isUnlocked)
        {
            return;
        }

        PlayerPrefs.SetInt("SelectShip", shipIndex);
    }
    public void UnlockShip()
    {
        shipsData ships = dataShip[shipIndex];

        PlayerPrefs.SetInt(ships.nameShip, 1);
        PlayerPrefs.SetInt("SelectShip", shipIndex);
        ships.isUnlocked = true;
        PlayerPrefs.SetInt("totalCoins", PlayerPrefs.GetInt("totalCoins", 0) - ships.costShip);
    }
    private void UpdateUI()
    {   
        textCoin.text = ":" + GameManager.totalCoins.ToString();
        shipsData ships = dataShip[shipIndex];
        if (ships.isUnlocked)
        {
            unlockButton.gameObject.SetActive(false);
        }
        else
        {
            unlockButton.gameObject.SetActive(true);
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unlock=" + ships.costShip;
            textCoin.text = ":" + GameManager.totalCoins.ToString();
            if (ships.costShip <= PlayerPrefs.GetInt("totalCoins", 0))
            {
                unlockButton.interactable = true;
            }
            else
            {
                unlockButton.interactable = false;
            }
        }

        
    }
}
