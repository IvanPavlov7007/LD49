using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI dislpayedText, yesText, noText;

    Dialog currentDialog;

    public static DialogUI instance;
    private void Awake()
    {
        instance = this;
    }

    public void Activate(Dialog d)
    {
        currentDialog = d;
        GameManager.instance.StopGame();
        skipFrame = true;
        next();
    }

    bool skipFrame = false;
    void Update()
    {
        if(!skipFrame && currentDialog != null && Input.GetKeyDown(KeyCode.E))
        {
            next();
        }

        skipFrame = false;
    }

    void next()
    {
        var result = currentDialog.next();
        if(result.resultType == DialogResult.ResultType.NextLine)
        {
            dislpayedText.text = result.text;
        }

        if(result.resultType == DialogResult.ResultType.End)
        {
            dislpayedText.text = string.Empty;
            GameManager.instance.ContinueGame();
            currentDialog = null;
        }
    }


}
