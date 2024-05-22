using UnityEngine;
using Fusion;

public class ResultsPanel : NetworkBehaviour
{
    [SerializeField] private GameObject _resultPanel;
    private GameStages _time;
    public override void Spawned()
    {
        _time = gameObject.AddComponent<GameStages>();
    }

    private void EnableResultsPanel()
    {
        _resultPanel.SetActive(true);
    }
}
