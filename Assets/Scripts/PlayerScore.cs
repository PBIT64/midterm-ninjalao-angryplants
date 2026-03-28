using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] ScoreTable ScoreTable;
    int score = 0;
    int maxscore = 0;
    void Start()
    {
        List<TargetMeat> Meats = FindObjectsOfType<TargetMeat>().ToList();
        maxscore = Meats.Count;
        Debug.Log($"Max Meats : {maxscore}");
    }

    public void GiveScore()
    {
        score++;
        int starCount = -(maxscore - 3 - score);
        ScoreTable.SetStar(starCount);
    }

}
