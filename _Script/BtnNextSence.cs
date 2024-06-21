using UnityEngine;
using UnityEngine.SceneManagement;
public class BtnNextSence :BaseButton
{
    public override void OnClick()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
        Time.timeScale = 1.0f;
    }
}

