using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] Text scoreborad;
    string baseScoreText = "ÇΩÇ◊ÇΩÅF";

    public void ShowGameOverPanel()
    {
        gameoverPanel.SetActive(true);
    }

    public void UpdateScoreBorad(int score)
    {
        string currentText = baseScoreText + score.ToString() + "êl";
        scoreborad.text = currentText;
    }
}
