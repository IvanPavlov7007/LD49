using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [SerializeField]
    string[] lines;
    public virtual void Start()
    {
        GameManager.instance.StopGame();
    }

    protected int index = -1;

    public DialogResult next()
    {
        index++;
        if (index < lines.Length)
            return new DialogResult(lines[index]);
        else
            return new DialogResult(DialogResult.ResultType.End);
    }
}

public class DialogResult
{
    public readonly ResultType resultType;
    public readonly string text;
    public enum ResultType {NextLine, Choice, End}

    public DialogResult(string text)
    {
        this.text = text;
        resultType = ResultType.NextLine;
    }

    public DialogResult(ResultType result)
    {
        this.resultType = result;
    }
}
