using UnityEngine;
using UnityEngine.SceneManagement;

public class OnExit : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("DemoLevel");
    }
    public void Exit() {
        Application.Quit();
    }
}
