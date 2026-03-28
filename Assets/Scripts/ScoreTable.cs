using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour
{
    Image Star1;
    Image Star2;
    Image Star3;
    private void Start()
    {
        Star1 = transform.Find("Star1").GetComponent<Image>();
        Star2 = transform.Find("Star2").GetComponent<Image>();
        Star3 = transform.Find("Star3").GetComponent<Image>();
    }
    public void SetStar(int starCount)
    {
        if (starCount >= 1) { Star1.color = Color.white; } else { Star1.color = Color.black; }
        if (starCount >= 2) { Star2.color = Color.white; } else { Star2.color = Color.black; }
        if (starCount >= 3) { Star3.color = Color.white; } else { Star3.color = Color.black; }
    }
}
