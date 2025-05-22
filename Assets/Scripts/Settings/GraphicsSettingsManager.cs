using TMPro;
using UnityEngine;

public class GraphicsSettingsManager : MonoBehaviour
{
    public TMP_Dropdown ScreenResolution;
    public TMP_Dropdown FPS;
    public TMP_Dropdown GraphicQuality;
    public TMP_Dropdown TextureQuality;
    public TMP_Dropdown Shadows;
    public TMP_Dropdown ShadowsQuality;
    public TMP_Dropdown Smoothing;
    public TMP_Dropdown AnisotropicFiltration;

    public static TMP_Dropdown[] Dropdowns;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        SaveGraphic();
    }

    private void Init()
    {
        Dropdowns = new TMP_Dropdown[] { ScreenResolution, FPS, GraphicQuality, TextureQuality, Shadows, ShadowsQuality, Smoothing, AnisotropicFiltration };
        LoadGraphicSave();

        if (FPS != null)
            FPS.onValueChanged.AddListener(delegate { ChangeFPSLimit(FPS); });

        if (ScreenResolution != null)
            ScreenResolution.onValueChanged.AddListener(delegate { ChangeScreenResolution(ScreenResolution); });

        if (GraphicQuality != null)
            GraphicQuality.onValueChanged.AddListener(delegate { ChangeGraphicQuality(GraphicQuality); });

        if (TextureQuality != null)
            TextureQuality.onValueChanged.AddListener(delegate { ChangeTextureQuality(TextureQuality); });

        if (Shadows != null)
            Shadows.onValueChanged.AddListener(delegate { ChangeShadows(Shadows); });

        if (ShadowsQuality != null)
            ShadowsQuality.onValueChanged.AddListener(delegate { ChangeShadowsQuality(ShadowsQuality); });

        if (Smoothing != null)
            Smoothing.onValueChanged.AddListener(delegate { ChangeSmoothing(Smoothing); });

        if (AnisotropicFiltration != null)
            AnisotropicFiltration.onValueChanged.AddListener(delegate { ChangeAnisotropicFiltration(AnisotropicFiltration); });
    }

    private void LoadGraphicSave()
    {
        for (int i = 0; i < Dropdowns.Length; i++)
            Dropdowns[i].value = SettingsTransitions.DataSettings.graphicIndexSettings[i];

        ChangeScreenResolution(ScreenResolution);
        ChangeFPSLimit(FPS);
        ChangeGraphicQuality(GraphicQuality);
        ChangeTextureQuality(TextureQuality);
        ChangeShadows(Shadows);
        ChangeShadowsQuality(ShadowsQuality);
        ChangeSmoothing(Smoothing);
        ChangeAnisotropicFiltration(AnisotropicFiltration);

        if (MenuManager.IsUploadGraphics == false)
            MenuManager.IsUploadGraphics = true;
    }

    private void SaveGraphic()
    {
        for (int i = 0; i < Dropdowns.Length; i++)
            SettingsTransitions.DataSettings.graphicIndexSettings[i] = Dropdowns[i].value;
    }

    private void ChangeScreenResolution(TMP_Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 1:
                Screen.SetResolution(2560, 1440, true);
                break;
        }
    }

    private void ChangeFPSLimit(TMP_Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                Application.targetFrameRate = 30;
                break;
            case 1:
                Application.targetFrameRate = 60;
                break;
            case 2:
                Application.targetFrameRate = 75;
                break;
            case 3:
                Application.targetFrameRate = 120;
                break;
            case 4:
                Application.targetFrameRate = -1;
                break;
        }
    }

    private void ChangeGraphicQuality(TMP_Dropdown dropdown)
    {
        QualitySettings.SetQualityLevel(dropdown.value, true);
    }

    private void ChangeTextureQuality(TMP_Dropdown dropdown)
    {
        QualitySettings.globalTextureMipmapLimit = dropdown.value switch
        {
            0 => 3,
            1 => 2,
            2 => 1,
            3 => 0,
            _ => 2
        };
    }

    private void ChangeShadows(TMP_Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                QualitySettings.shadows = ShadowQuality.Disable;
                break;
            case 1:
                QualitySettings.shadows = ShadowQuality.HardOnly;
                break;
            case 2:
                QualitySettings.shadows = ShadowQuality.All;
                break;
        }
    }

    private void ChangeShadowsQuality(TMP_Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                QualitySettings.shadowResolution = ShadowResolution.Low;
                break;
            case 1:
                QualitySettings.shadowResolution = ShadowResolution.Medium;
                break;
            case 2:
                QualitySettings.shadowResolution = ShadowResolution.High;
                break;
            case 3:
                QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
                break;
        }
    }

    private void ChangeSmoothing(TMP_Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                QualitySettings.antiAliasing = 0;
                break;
            case 1:
                QualitySettings.antiAliasing = 2;
                break;
            case 2:
                QualitySettings.antiAliasing = 4;
                break;
            case 3:
                QualitySettings.antiAliasing = 8;
                break;
        }
    }

    private void ChangeAnisotropicFiltration(TMP_Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                break;
            case 1:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                Texture.SetGlobalAnisotropicFilteringLimits(4, 16);
                break;
            case 2:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                Texture.SetGlobalAnisotropicFilteringLimits(8, 16);
                break;
            case 3:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                Texture.SetGlobalAnisotropicFilteringLimits(16, 16);
                break;
        }
    }
}