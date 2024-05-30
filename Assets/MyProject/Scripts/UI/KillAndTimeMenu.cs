using UnityEngine;
using Fusion;
using UnityEngine.InputSystem;

public class KillAndTimeMenu : NetworkBehaviour
{
    [SerializeField] private NetworkObject _panel;
    [SerializeField] private InputActionReference _actionReferenceOpenMenu;
    [SerializeField] private InputActionReference __actionReferenceOpenMenuOculus;

    void Update()
    {
        if (_actionReferenceOpenMenu.action.IsPressed() || __actionReferenceOpenMenuOculus.action.IsPressed())
        {
            _panel.gameObject.SetActive(true);
        }
        
        else
        {
            _panel.gameObject.SetActive(false);
        }
    }
}
