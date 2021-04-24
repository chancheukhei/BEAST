using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public static int nowLevel = 1;

    public void backToCurrent()
    {
        SceneManager.LoadScene(nowLevel);
    }

    void Update()
    {

    }
}
