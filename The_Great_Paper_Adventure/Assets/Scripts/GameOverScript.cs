using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    void OnGUI() {
        const int buttonWidth = 120;
        const int buttonHeight = 60;

        if (
            GUI.Button(
                new Rect(
                    Screen.width / 2 - (buttonWidth / 2),
                    (1 * Screen.height / 3) - (buttonHeight / 2),
                    buttonWidth,
                    buttonHeight),
                "Начать сначала!"
                )
            )
        {
            Application.LoadLevel(0);
        }

        if (
            GUI.Button(
                new Rect(
                    Screen.width / 2 - (buttonWidth / 2),
                    (2 * Screen.height / 3) - (buttonHeight / 2),
                    buttonWidth,
                    buttonHeight),
                "Назад в меню"
                )
            )
        {
            Application.LoadLevel(1);
        }
    }
}
