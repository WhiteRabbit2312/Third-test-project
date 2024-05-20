using UnityEngine;
using Fusion;

public class ResultsPanel : NetworkBehaviour
{
    [SerializeField] private GameObject _resultPanel;
    private TimerUI _time;
    public override void Spawned()
    {
        _time = gameObject.AddComponent<TimerUI>();
        _time.OnEndGame += EnableResultsPanel;
    }

    private void EnableResultsPanel()
    {
        _resultPanel.SetActive(true);
    }
}
