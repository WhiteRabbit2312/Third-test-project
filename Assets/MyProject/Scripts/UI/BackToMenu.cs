using UnityEngine.SceneManagement;
using Fusion;

public class BackToMenu : NetworkBehaviour
{
    private int _scene = 0;
    public void BackToMenuButton()
    {
        SceneManager.LoadScene(_scene);
    }
}
