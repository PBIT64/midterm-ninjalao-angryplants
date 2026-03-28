using UnityEngine;

public class TargetMeat : MonoBehaviour
{
    [SerializeField] PlayerScore playerScore;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            playerScore.GiveScore();
            Destroy(gameObject);
        }
    }
}