using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class KillAndTimeMenu : NetworkBehaviour
{
    [SerializeField] private NetworkObject _panel;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            _panel.gameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.JoystickButton4))
        {
            _panel.gameObject.SetActive(false);
        }
    }
}
