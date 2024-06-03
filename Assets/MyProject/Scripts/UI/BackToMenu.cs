using UnityEngine.SceneManagement;
using Fusion;
using UnityEngine;

public class BackToMenu : NetworkBehaviour
{
    private int _scene = 0;
    private string _connectionHandler = "Fusion_PhotonBackgroundConnectionHandler";
    private string _basicSpawner = "BasicSpawner";
    public void BackToMenuButton()
    {
        GameObject networkRunner = GameObject.FindGameObjectWithTag(_basicSpawner);

        GameObject objectToDestroy = GameObject.Find(_connectionHandler);
        Destroy(networkRunner);
        Destroy(objectToDestroy);
        SceneManager.LoadScene(_scene);
    }
}
