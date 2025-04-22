using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public BodyScaler bodyScaler;
    public GameObject measurementPanel;
    public GameObject modelControlPanel;

    // Measurement input fields
    public TMP_InputField heightInput;
    public TMP_InputField chestInput;
    public TMP_InputField waistInput;
    public TMP_InputField hipsInput;
    public TMP_InputField shoulderWidthInput;
    public TMP_InputField armLengthInput;
    public TMP_InputField legLengthInput;

    // Model control UI elements
    public Slider scaleSlider;
    public Slider rotationXSlider;
    public Slider rotationYSlider;
    public Slider rotationZSlider;
    public Button exportButton;
    public Button batchExportButton;

    private void Start()
    {
        InitializeUI();
        SetupEventListeners();
    }

    private void InitializeUI()
    {
        // Set default values
        heightInput.text = "180";
        chestInput.text = "100";
        waistInput.text = "80";
        hipsInput.text = "90";
        shoulderWidthInput.text = "45";
        armLengthInput.text = "60";
        legLengthInput.text = "90";

        // Initialize sliders
        scaleSlider.minValue = 0.1f;
        scaleSlider.maxValue = 2.0f;
        scaleSlider.value = 1.0f;

        rotationXSlider.minValue = -180f;
        rotationXSlider.maxValue = 180f;
        rotationYSlider.minValue = -180f;
        rotationYSlider.maxValue = 180f;
        rotationZSlider.minValue = -180f;
        rotationZSlider.maxValue = 180f;
    }

    private void SetupEventListeners()
    {
        // Measurement input listeners
        heightInput.onEndEdit.AddListener(UpdateHeight);
        chestInput.onEndEdit.AddListener(UpdateChest);
        waistInput.onEndEdit.AddListener(UpdateWaist);
        hipsInput.onEndEdit.AddListener(UpdateHips);
        shoulderWidthInput.onEndEdit.AddListener(UpdateShoulderWidth);
        armLengthInput.onEndEdit.AddListener(UpdateArmLength);
        legLengthInput.onEndEdit.AddListener(UpdateLegLength);

        // Model control listeners
        scaleSlider.onValueChanged.AddListener(UpdateModelScale);
        rotationXSlider.onValueChanged.AddListener(UpdateRotationX);
        rotationYSlider.onValueChanged.AddListener(UpdateRotationY);
        rotationZSlider.onValueChanged.AddListener(UpdateRotationZ);
        exportButton.onClick.AddListener(ExportCurrentModel);
        batchExportButton.onClick.AddListener(ExportAllModels);
    }

    private void UpdateHeight(string value)
    {
        if (float.TryParse(value, out float height))
        {
            bodyScaler.measurements.height = height;
            bodyScaler.UpdateAvatarScale();
        }
    }

    private void UpdateChest(string value)
    {
        if (float.TryParse(value, out float chest))
        {
            bodyScaler.measurements.chest = chest;
            bodyScaler.UpdateAvatarScale();
        }
    }

    private void UpdateWaist(string value)
    {
        if (float.TryParse(value, out float waist))
        {
            bodyScaler.measurements.waist = waist;
            bodyScaler.UpdateAvatarScale();
        }
    }

    private void UpdateHips(string value)
    {
        if (float.TryParse(value, out float hips))
        {
            bodyScaler.measurements.hips = hips;
            bodyScaler.UpdateAvatarScale();
        }
    }

    private void UpdateShoulderWidth(string value)
    {
        if (float.TryParse(value, out float width))
        {
            bodyScaler.measurements.shoulderWidth = width;
            bodyScaler.UpdateAvatarScale();
        }
    }

    private void UpdateArmLength(string value)
    {
        if (float.TryParse(value, out float length))
        {
            bodyScaler.measurements.armLength = length;
            bodyScaler.UpdateAvatarScale();
        }
    }

    private void UpdateLegLength(string value)
    {
        if (float.TryParse(value, out float length))
        {
            bodyScaler.measurements.legLength = length;
            bodyScaler.UpdateAvatarScale();
        }
    }

    private void UpdateModelScale(float value)
    {
        bodyScaler.scaleFactor = value;
        bodyScaler.UpdateAvatarScale();
    }

    private void UpdateRotationX(float value)
    {
        bodyScaler.UpdateRotation(new Vector3(value, bodyScaler.GetCurrentRotation().y, bodyScaler.GetCurrentRotation().z));
    }

    private void UpdateRotationY(float value)
    {
        bodyScaler.UpdateRotation(new Vector3(bodyScaler.GetCurrentRotation().x, value, bodyScaler.GetCurrentRotation().z));
    }

    private void UpdateRotationZ(float value)
    {
        bodyScaler.UpdateRotation(new Vector3(bodyScaler.GetCurrentRotation().x, bodyScaler.GetCurrentRotation().y, value));
    }

    private void ExportCurrentModel()
    {
        bodyScaler.ExportCurrentModel();
    }

    private void ExportAllModels()
    {
        bodyScaler.ExportAllModels();
    }

    public void ToggleMeasurementPanel(bool show)
    {
        measurementPanel.SetActive(show);
    }

    public void ToggleModelControlPanel(bool show)
    {
        modelControlPanel.SetActive(show);
    }
} 