using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour {
    public static DiceMode mode;
    public Text displayScreen;

    private void Awake()
    {
        mode = DiceMode.SingleMode;
    }

    public enum DiceMode
    {
        SumMode,
        SingleMode
    };

    public void RollDice(int diceType)
    {
        if (mode == DiceMode.SingleMode)
        {
            displayScreen.text = Random.Range(1, diceType + 1).ToString();
        }
    }

    public void HeadsOrTails()
    {
        string[] faces = new string[2];

        faces[0] = "Head";
        faces[1] = "Tail";

        displayScreen.text = faces[Random.Range(0, 2)];
    }

    public void ClearDisplay()
    {
        displayScreen.text = "";
    }
}
