using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnPlay : BaseButton
{
    public override void OnClick()
    {
        SceneManager.LoadScene("Level_1");
    }
}


