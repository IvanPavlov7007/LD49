using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI dislpayedText, yesText, noText;

    AudioSource audioSource;

    [SerializeField]
    float timeNoSkip = 0.5f;

    [SerializeField]
    AudioClip clickSound;

    Dialog currentDialog;

    public static DialogUI instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    public void Activate(Dialog d)
    {
        currentDialog = d;
        GameManager.instance.StopGame();
        skipFrame = true;
        next();
    }

    bool skipFrame = false;
    float elapsedTime = 0f;
    void Update()
    {
        if(!skipFrame && elapsedTime > timeNoSkip && currentDialog != null && Input.GetKeyDown(KeyCode.E))
        {
            next();
        }

        skipFrame = false;
        elapsedTime += Time.unscaledDeltaTime;
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

        audioSource.PlayOneShot(clickSound);
        //for not skipping frame unintentially
        elapsedTime = 0f;
    }


}
