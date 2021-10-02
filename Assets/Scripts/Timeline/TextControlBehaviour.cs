using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class TextControlBehaviour : PlayableBehaviour
{
    [SerializeField]
    string text;
    [Header("Pronunciation"),SerializeField]
    bool pronounceEveryLetter = false;
    [SerializeField]
    bool pronounceWithSound = true;

    bool firstFrameProcessed = false;

    double timePerLetter;
    int currentShowedLettersCount, pronouncedLetter;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        base.OnBehaviourPlay(playable, info);
    }

    double letterIndex;
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        var displayedText = playerData as TextMeshPro;
        if (displayedText == null)
            throw new UnityException("Must have DisplayedText component");
        if (!firstFrameProcessed)
        {
            if (!pronounceEveryLetter)
                displayedText.text = text.Replace("/n", System.Environment.NewLine);
            else
            {
                timePerLetter = playable.GetDuration() / text.Length;
                currentShowedLettersCount = 0;
                pronouncedLetter = 0;
                letterIndex = 0;
            }
            firstFrameProcessed = true;
        }

        if(pronounceEveryLetter)
        {
            double time = playable.GetTime();
            //    if ( time >= currentShowedLettersCount * timePerLetter)
            //    {
            //        if (pronounceWithSound && char.IsLetter(text[currentShowedLettersCount]))
            //        {
            //            GeneralSoundSource.instance.PronounceLetter();
            //        }
            //        currentShowedLettersCount = (int)(time / timePerLetter) + 1;
            //        displayedText.SetTextImmediately(text.Substring(0,currentShowedLettersCount).Replace("/n", System.Environment.NewLine));
            //    }
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        firstFrameProcessed = false;
    }
}
