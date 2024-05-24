using System.Collections;
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
        if (__actionReferenceOpenMenuOculus.action.IsPressed())//if (_playerInput.actions["UI Press"].IsPressed())
        {
            //Debug.LogError("Pressed");
            _panel.gameObject.SetActive(true);
        }
        
        else
        {
            //Debug.LogError("UnPressed");
            _panel.gameObject.SetActive(false);
        }
    }
}
