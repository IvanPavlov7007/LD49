using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObject : MonoBehaviour
{
    public SpriteCameraPositioning SCP;
    [SerializeField]
    protected SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer
    {
        get
        {
            return spriteRenderer;
        }
    }

    [SerializeField]
    protected bool isFadeOutWhenClose;
    [SerializeField]
    protected Vector2 fadeOutRange; // from 1 to ~0
    [SerializeField]
    protected Vector2 fadeOutDistance;

    [SerializeField]
    protected bool isFakeObject;
    [SerializeField]
    protected Vector2 activationRange; // x - max dist, y - min dist (50 - 0)
    [SerializeField]
    protected bool isRandomPrefab;
    [SerializeField]
    protected GameObject objectPrefab;
    [SerializeField]
    protected List<GameObject> similarPrefabs;
    protected EnvironmentObject realObjectEnv;
    protected bool isMimicActivated = false;
    public bool IsMimicActivated 
    {
        set
        {
            isMimicActivated = value;            
        }
    }


    protected virtual void Awake()
    {
        if (isFakeObject && !isMimicActivated)
        {
            if (isRandomPrefab)
            {
                objectPrefab = similarPrefabs[Random.Range(0, similarPrefabs.Count)];
            }
            GameObject realObject = Instantiate(objectPrefab, this.transform.position, Quaternion.identity);

            realObject.transform.parent = this.transform;
            realObjectEnv = realObject.GetComponent<EnvironmentObject>();
            realObjectEnv.isMimicActivated = true;
            realObjectEnv.SpriteRenderer.color = GetColorWithChangedAlpha(realObjectEnv.SpriteRenderer.color, 0f);
            realObject.SetActive(false);
        }
    }

    protected virtual void Update()
    {
        if (isFadeOutWhenClose)
        {
            FadeOutCloseAlpha(SCP.DistanceToTarget);
        }

        if (isFakeObject && !isMimicActivated)
        {
            if (SCP.DistanceToTarget != 0)
            {
                CheckMimicActivate(SCP.DistanceToTarget, PlayerController.Instance.MadnessFactor);
            }
        }
    }

    private void CheckMimicActivate(float distance, float madnessFactor)
    {
        float activationDistance = Mathf.Lerp(activationRange.x, activationRange.y, madnessFactor);
        if (distance < activationDistance)
        {
            StartCoroutine(FadeOut(this, 0f, 2f * madnessFactor, true));
            StartCoroutine(FadeOut(realObjectEnv, 1f, 2f * madnessFactor));
            realObjectEnv.gameObject.SetActive(true);
            realObjectEnv.transform.parent = null;
            isMimicActivated = true;
        }
    }

    private IEnumerator FadeOut(EnvironmentObject envObj, float targetAlpha, float duration, bool isDestroy=false)
    {
        float startAlpha = envObj.SpriteRenderer.color.a;
        for (float elapsed = 0f; elapsed < duration; elapsed += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / duration);
            envObj.SpriteRenderer.color = GetColorWithChangedAlpha(envObj.SpriteRenderer.color, alpha);
            yield return null;
        }
        envObj.SpriteRenderer.color = GetColorWithChangedAlpha(envObj.SpriteRenderer.color, targetAlpha);

        if (isDestroy)
        {
            Destroy(envObj.gameObject);
        }
    }

    private void FadeOutCloseAlpha(float distance)
    {
        float newAlpha = 1f;

        if (distance > fadeOutDistance.x)
        {
            newAlpha = fadeOutRange.x;
        }
        else if (distance < fadeOutDistance.y)
        {
            newAlpha = fadeOutRange.y;
        }
        else
        {
            newAlpha = Mathf.Lerp(fadeOutRange.y, fadeOutRange.x, (distance - fadeOutDistance.y) / fadeOutDistance.y);
        }
        spriteRenderer.color = GetColorWithChangedAlpha(spriteRenderer.color, newAlpha);
    }

    private Color GetColorWithChangedAlpha(Color oldColor, float alpha)
    {
        return new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
    }


}
