using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimManager : TransparencyChangingComponent {

    static DimManager _instance;
    public static DimManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<DimManager>();
            return _instance;
        }
    }

    public Shader dimmingShader;
    [SerializeField]
    private Material curMaterial = null;

    int mapProperty = Shader.PropertyToID("_DistanceMap");
    int visibilityProperty = Shader.PropertyToID("_Visibility");
    int deltaRadiusProperty = Shader.PropertyToID("_DeltaRadius");

    private Texture radialMap, linearMap;
    [SerializeField]
    bool useLinear;

    private Material material
    {
        get
        {
            if (curMaterial == null && dimmingShader != null)
            {
                curMaterial = new Material(dimmingShader);
                curMaterial.hideFlags = HideFlags.DontSave;
            }
            return curMaterial;
        }
    }

    [SerializeField, Range(0f,1f)]
    float visibility = 1f;

    //debug:
    private void Update()
    {
        Visibility = visibility;
    }

    public override float Visibility
    {
        get
        {
            return visibility;
        }

        set
        {
            visibility = value;
            material.SetFloat(visibilityProperty, visibility);
            material.SetFloat(deltaRadiusProperty, Mathf.Pow(visibility,0.5f) * 1f);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        radialMap = GetRadialDistMap();
        linearMap = GetLinearDistMap();
    }

    protected override void Start()
    {
        base.Start();
        UseDistanceMap(useLinear);
    }

    private Texture GetRadialDistMap()
    {
        int width = Screen.width;
        int height = Screen.height;
        Vector2 middlePoint = new Vector2(width, height) * 0.5f;
        float longestDist = middlePoint.magnitude;
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGBAHalf, false, true);
        Color[] pixels = new Color[width * height];
        int i;
        float value;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                i = x + width * y;
                value = (new Vector2(x, y) - middlePoint).magnitude / longestDist;
                pixels[i].r = value;
            }
        }
        texture.SetPixels(pixels);
        texture.Apply();
        return texture;
    }

    private Texture GetLinearDistMap()
    {
        int width = Screen.width;
        int height = Screen.height;
        float middle = height * 0.5f;
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGBAHalf, false, true);
        Color[] pixels = new Color[width * height];
        int i;
        float value;
        for (int y = 0; y < height; y++)
        {
            value = Mathf.Abs((y - middle)) / middle;
            for (int x = 0; x < width; x++)
            {
                i = x + width * y;
                pixels[i].r = value;
            }
        }
        texture.SetPixels(pixels);
        texture.Apply();
        return texture;
    }

    public void UseDistanceMap(bool linear)
    {
        material.SetTexture(mapProperty, linear? linearMap : radialMap);
    }


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
