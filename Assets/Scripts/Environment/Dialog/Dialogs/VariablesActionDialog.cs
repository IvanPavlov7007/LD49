using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesActionDialog : ActionDialog
{
    public string symbol;

    public virtual string getVariable()
    {
        return GameManager.instance.inventory.money.ToString();
    }

    public override DialogResult next()
    {
        index++;
        if (index < lines.Length)
        {
            // I know it's breaking the OOP-rules here, since we completely change the base( Dialog) TODO: put those filters to the Dialog class
            return new DialogResult(lines[index].Replace(symbol,getVariable()));
        }
        else
            return base.next();
    }
}
