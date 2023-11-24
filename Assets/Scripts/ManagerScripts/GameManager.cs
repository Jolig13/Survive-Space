using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    private float score;
    [SerializeField] private TMP_Text actualScore;
    [SerializeField] private TMP_Text highScore;
    [SerializeField] private float ScrollSpeed;
    private float ScrollSpeedUp;
    private float SpeedDivider=20f;
    private void Awake() 
    {
        if (Instance==null)
        {
            Instance=this;
        }
        else
        {
            Destroy(this.gameObject);
        } 
    }
    private void Update() 
    {
        highScore.text=PlayerPrefs.GetInt("highScore",0).ToString();
        UpgradeSpeed();
    }
    public void Score()
    {   
        score += 1*Time.deltaTime;
        actualScore.text = ((int)score).ToString();
        if (score > PlayerPrefs.GetInt("highScore",0))
        {
            PlayerPrefs.SetInt("highScore",(int)score);
            highScore.text=score.ToString("0");
        }
    }

    public float ScrollCamera()
    {
        return ScrollSpeedUp;
    }
    private void UpgradeSpeed()
    {
        ScrollSpeedUp=ScrollSpeed+score/SpeedDivider;
    }
}
