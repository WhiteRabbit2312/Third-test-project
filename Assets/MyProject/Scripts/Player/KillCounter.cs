using Fusion;


public class KillCounter : NetworkBehaviour
{
    [Networked] public NetworkDictionary<PlayerRef, int> KillDictionary => default;

    /*
    private void Huy()
    {
        foreach (var item in KillDictionary)
        {
            Debug.LogError("Player: " + item.Key + "Bullet all kills: " + item.Value);
        }
    }*/
}
