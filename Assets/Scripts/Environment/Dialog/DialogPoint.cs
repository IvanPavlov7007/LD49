using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPoint : MonoBehaviour
{
    [SerializeField]
    Dialog dialog;

    DialogUI ui;
    private void Start()
    {
        ui = DialogUI.instance;
    }

    public void StartDialog()
    {
        DialogUI.instance.Activate(dialog);
    }

    public void StartDialog(Dialog d)
    {
        DialogUI.instance.Activate(d);
    }

    public void SetDialog(Dialog d)
    {
        dialog = d;
    }
}
