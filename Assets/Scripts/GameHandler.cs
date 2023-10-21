using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StartEndlessGame()
    {
        //ENDLESS Game
    }

    public void Exit()
    {
        Application.Quit();
    }

    
}
