using UnityEngine;
using Fusion;

public class ResultsPanel : NetworkBehaviour
{
    [SerializeField] private GameObject _resultPanel;
    private Timer _time;
    public override void Spawned()
    {
        _time = gameObject.AddComponent<Timer>();
        _time.OnEndGame += EnableResultsPanel;
    }

    private void EnableResultsPanel()
    {
        _resultPanel.SetActive(true);
    }
}
