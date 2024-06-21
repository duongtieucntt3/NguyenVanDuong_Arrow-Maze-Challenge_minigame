
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnReset : BaseButton
{
    public override void OnClick()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1.0f;
    }
}
