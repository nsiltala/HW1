using UnityEngine;
using UnityEngine.InputSystem;

public class LightColorChanger : MonoBehaviour
{
    public Light lightSource;
    public InputActionReference changeColorAction;
    public Color newColor = new Color(0.3f, 0.4f, 0.6f, 1.0f);

    private Color defaultColor;
    private bool isDefaultColor = true;

    void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();
        }

        if (lightSource != null)
        {
            defaultColor = lightSource.color;
        }
        else
        {
            Debug.LogError("Light component is not assigned or found!");
            return;
        }

        if (changeColorAction != null)
        {
            changeColorAction.action.Enable();
            changeColorAction.action.performed += ChangeLightColor;
        }
        else
        {
            Debug.LogError("Input Action Reference is not assigned!");
        }
    }

    private void ChangeLightColor(InputAction.CallbackContext context)
    {
        if (lightSource != null)
        {
            lightSource.color = isDefaultColor ? newColor : defaultColor;
            isDefaultColor = !isDefaultColor;
        }
    }

    private void OnDestroy()
    {
        if (changeColorAction != null)
        {
            changeColorAction.action.performed -= ChangeLightColor;
        }
    }
}