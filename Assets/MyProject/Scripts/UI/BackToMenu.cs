using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fusion;

public class BackToMenu : NetworkBehaviour
{
    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
