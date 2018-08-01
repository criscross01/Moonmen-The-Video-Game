using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionality : MonoBehaviour
{

    public Transform canvas;


    //Main Menu options.
    public void StartButton ()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OptionsButton ()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void BackButton ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton ()
    {
        Application.Quit();
    }



    //Pause Menu options.
    public void ResumeButton ()
    {
        canvas.gameObject.SetActive(false);
    }

    public void PauseOptionsButton()
    {
        //WIP
    }


    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
