using UnityEngine;
using UnityEngine.SceneManagement;
public class BtnHome :BaseButton
{
    protected string sceneName = "MenuPlay";
    public override void OnClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(this.sceneName);

    }
}

