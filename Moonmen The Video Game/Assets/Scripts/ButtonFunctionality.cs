using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionality : MonoBehaviour
{

    public void StartButton ()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OptionsButton ()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton ()
    {
        Application.Quit();
    }
}
