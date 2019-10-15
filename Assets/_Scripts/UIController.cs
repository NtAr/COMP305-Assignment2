using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hero;

public class UIController : MonoBehaviour
{
    public Button restartButton;
    public HeroController hero;

    public void OnRestartButtonClick()
    {
        hero.Reset();
    }
}
