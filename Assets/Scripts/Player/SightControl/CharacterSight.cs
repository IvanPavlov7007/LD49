using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Pixelplacement;

[ExecuteAlways]
public class CharacterSight : MonoBehaviour
{
    private PostProcessVolume postProcessVolume;
    DepthOfField depth;
    ColorGrading colorGrading;


    public float initialFocalLength;
    public float focalLength;

    public static CharacterSight instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        postProcessVolume = Camera.main.GetComponent<PostProcessVolume>();
        if (postProcessVolume)
        {
            if (!postProcessVolume.sharedProfile.TryGetSettings<DepthOfField>(out depth))
            {
                Debug.Log("No depth of Field");
            }
            if (!postProcessVolume.sharedProfile.TryGetSettings<ColorGrading>(out colorGrading))
            {
                Debug.Log("No color grading");
            }

            colorGrading.saturation.value = 0f;
            focalLength = initialFocalLength;
            depth.focalLength.value = initialFocalLength;
        }
        //Clarify();
    }

    void Update()
    {
        depth.focalLength.value = focalLength;
    }

    public void Clarify(float time)
    {
        StartCoroutine(clarifyForTimeAndRange(time,50f));
    }

    public void CatVision()
    {
        StartCoroutine(catVisionAnimation(30f));
    }

    IEnumerator catVisionAnimation(float range)
    {
        float elaps_time = 0f;
        Camera c = Camera.main;
        Tween.FieldOfView(c, c.fieldOfView + 10f, 1f, 0f, AnimationCurve.EaseInOut(0f, 0f, 1f, 1f));
        float desiredFocalLength = focalLength - range;
        float initFocalLength = focalLength;
        focalLength = desiredFocalLength;

        while (elaps_time < 1f)
        {
            elaps_time += Time.deltaTime;
            focalLength = initFocalLength - elaps_time * range;
            colorGrading.saturation.value = -100f * elaps_time / 1f;
            yield return new WaitForEndOfFrame();
        }
        colorGrading.saturation.value = -100f;
    }

    IEnumerator clarifyForTimeAndRange(float time, float range)
    {
        float elaps_time = 0f;
        Camera c = Camera.main;
        Tween.FieldOfView(c, c.fieldOfView + 10f, 1f,0f, AnimationCurve.EaseInOut(0f,0f,1f,1f));
        Tween.FieldOfView(c, c.fieldOfView, 1f,1f, AnimationCurve.EaseInOut(0f, 0f, 1f, 1f));
        float desiredFocalLength = focalLength - range;
        float initFocalLength = focalLength;
        focalLength = desiredFocalLength;

        while (elaps_time < 1f)
        {
            elaps_time += Time.deltaTime;
            focalLength = initFocalLength - elaps_time * range;
            yield return new WaitForEndOfFrame();
        }
        elaps_time = 0f;

        while (elaps_time < time)
        {
            elaps_time += Time.deltaTime;
            focalLength = desiredFocalLength + (elaps_time / time) * range;
            yield return new WaitForEndOfFrame();
        }
        focalLength = initFocalLength;
    }
}
