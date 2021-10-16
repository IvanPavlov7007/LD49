using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    protected string[] lines;

    protected int index = -1;

    public virtual void Reset()
    {
        index = -1;
    }

    public virtual DialogResult next()
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
    public enum ResultType {NextLine, Action, End}

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
