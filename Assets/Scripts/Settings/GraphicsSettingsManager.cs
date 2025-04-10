using TMPro;
using UnityEngine;

public class GraphicsSettingsManager : MonoBehaviour
{
    public TMP_Dropdown GraphicQuality;
    public TMP_Dropdown TextureQuality;
    public TMP_Dropdown Shadows;
    public TMP_Dropdown ShadowsQuality;
    public TMP_Dropdown Smoothing;
    public TMP_Dropdown AnisotropicFiltration;

    public static TMP_Dropdown[] Dropdowns;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        SaveGraphic();
    }

    private void Init()
    {
        Dropdowns = new TMP_Dropdown[] { GraphicQuality, TextureQuality, Shadows, ShadowsQuality, Smoothing, AnisotropicFiltration };
        LoadGraphicSave(Dropdowns);

        GraphicQuality.enabled = false;
        TextureQuality.enabled = false;
        Shadows.enabled = false;
        ShadowsQuality.enabled = false;
        Smoothing.enabled = false;
        AnisotropicFiltration.enabled = false;


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

    private void LoadGraphicSave(TMP_Dropdown[] dropdowns)
    {
        for (int i = 0; i < dropdowns.Length; i++)
            dropdowns[i].value = SettingsTransitions.DataSettings.graphicIndexSettings[i];

        ChangeGraphicQuality(GraphicQuality);
        ChangeTextureQuality(TextureQuality);
        ChangeShadows(Shadows);
        ChangeShadowsQuality(ShadowsQuality);
        ChangeSmoothing(Smoothing);
        ChangeAnisotropicFiltration(AnisotropicFiltration);
    }

    private void SaveGraphic()
    {
        for (int i = 0; i < Dropdowns.Length; i++)
            SettingsTransitions.DataSettings.graphicIndexSettings[i] = Dropdowns[i].value;

        SettingsTransitions.DataSettings.Save(SettingsTransitions.DataSettings, "SettingsData.json");
    }

    private void ChangeGraphicQuality(TMP_Dropdown dropdown)
    {
        QualitySettings.SetQualityLevel(dropdown.value, true);
    }

    private void ChangeTextureQuality(TMP_Dropdown dropdown)
    {
        QualitySettings.globalTextureMipmapLimit = dropdown.value;
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