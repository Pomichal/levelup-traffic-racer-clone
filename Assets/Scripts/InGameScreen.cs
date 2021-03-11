using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScreen : MonoBehaviour
{
    public HoldButtonBehaviour speedUpButton;
    public HoldButtonBehaviour slowDownButton;

    public void Show()
    {
        gameObject.SetActive(true);
        speedUpButton.isDown = false;
        slowDownButton.isDown = false;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
