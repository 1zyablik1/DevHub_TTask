using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishPanel : BaseUI
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text buttonText;

    private const string winText = "WIN";
    private const string winButtonText = "NEXT";
    private const string loseText = "LOSE";
    private const string loseButtonText = "RESTART";

    protected override void Subscribe()
    {
        base.Subscribe();

        Events.OnGlobalFinishStateEnter += FinishStateEnter;
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        Events.OnGlobalFinishStateEnter -= FinishStateEnter;
    }

    private void FinishStateEnter()
    {
        if (LevelManager.IsLevelSucceed())
        {
            text.text = winText;
            buttonText.text = winButtonText;
            return;
        }

        buttonText.text = loseButtonText;
        text.text = loseText;
    }

    public void OnFinishButtonClicked()
    {
        GlobalStateMachine.SetState<Menu>();
    }
}
