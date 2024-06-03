using Fusion;


public class KillCounter : NetworkBehaviour
{
    [Networked] public NetworkDictionary<PlayerRef, int> KillDictionary => default;
}
