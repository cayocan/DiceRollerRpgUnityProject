using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour {
    public static DiceMode mode;

    public Text displayScreen;
    public Text totalDisplayScreen;
    public Text diceModeDisplay;

    private int total;

    const string DISPLAYSCREENNULLTEXT = "0d0";
    const string TOTALDISPLAYSCREENNULLTEXT = "Total";
    const string SINGLEMODELABEL = "Single Mode";
    const string SUMMODELABEL = "Sum Mode";

    private void Awake()
    {
        mode = DiceMode.SingleMode;
        diceModeDisplay.text = SINGLEMODELABEL;
    }

    public enum DiceMode
    {
        SumMode,
        SingleMode
    };

    public void ChangeMode()
    {
        if (mode == DiceMode.SingleMode)
        {
            mode = DiceMode.SumMode;
            diceModeDisplay.text = SUMMODELABEL;
            ClearDisplay();
        }
        else if (mode == DiceMode.SumMode)
        {           
            mode = DiceMode.SingleMode;
            diceModeDisplay.text = SINGLEMODELABEL;
            ClearDisplay();
        }
    }

    public void RollDice(int diceType)
    {
        if (mode == DiceMode.SingleMode)
        {
            displayScreen.text = "1d" + diceType + " = " + Random.Range(1, diceType + 1);
        }
        else if (mode == DiceMode.SumMode)
        {
            int result = Random.Range(1, diceType + 1);
            total += result;

            if (displayScreen.text == DISPLAYSCREENNULLTEXT)
            {
                displayScreen.text = null;
            }
            else
            {
                displayScreen.text += " + ";
            }

            displayScreen.text += "(1d" + diceType + " = " + result + ")";
            totalDisplayScreen.text = total.ToString();
        }
    }

    public void HeadsOrTails()
    {
        ClearTotal();
        string[] faces = new string[2];

        faces[0] = "Head";
        faces[1] = "Tail";

        displayScreen.text = faces[Random.Range(0, 2)];
    }

    public void ClearDisplay()
    {
        ClearTotal();

        displayScreen.text = DISPLAYSCREENNULLTEXT;
        totalDisplayScreen.text = TOTALDISPLAYSCREENNULLTEXT;
    }

    public void ClearTotal()
    {
        total = 0;
    }
}
