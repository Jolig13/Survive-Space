using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    private float score;
    [SerializeField] private TextMeshProUGUI totalScore;
    [SerializeField] private TextMeshProUGUI highScore;
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
    public void Start() 
    {
        highScore.text = PlayerPrefs.GetInt("highScore",0).ToString();
    }
    public void Score()
    {
        score += 1*Time.deltaTime;

        totalScore.text = ((int)score).ToString();

        if (score > PlayerPrefs.GetInt("hihgScore",0))
        {
            PlayerPrefs.SetInt("highScore",(int)score);
            highScore.text=score.ToString("0");
        }
    }
}
