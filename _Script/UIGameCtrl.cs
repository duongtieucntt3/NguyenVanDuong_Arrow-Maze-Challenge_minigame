
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameCtrl : DuongMonoBehaviour
{
    public Transform GameOver;
    public Transform Win;

    private static UIGameCtrl instance;
    public static UIGameCtrl Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (UIGameCtrl.instance != null) Debug.LogError("Only 1 UIGameCtrl allow to exist");
        UIGameCtrl.instance = this;
    }
}
