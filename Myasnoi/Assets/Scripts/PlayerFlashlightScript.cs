using UnityEngine;

public class PlayerFlashlightScript : MonoBehaviour
{
    public Light PlayerFlashlight;

    void Update()
    {
        bool furtherInputKey = Input.GetKey(KeyCode.Q), 
            closerInputKey = Input.GetKey(KeyCode.E);
        if (closerInputKey || furtherInputKey)
            PlayerFlashLightParametersChange(further: furtherInputKey);
    }

    private void PlayerFlashLightParametersChange(bool further)
    {
        const int maxFlashlightrange = 25, minFlashflightrange = 8, intensityMultiplier = 2;
        if (PlayerFlashlight.range <= maxFlashlightrange && further
            || PlayerFlashlight.range >= minFlashflightrange && !further)
        {
            const float toAdd = 0.03f;
            float sign = further ? 1 : -1;
            PlayerFlashlight.range +=  toAdd * sign;
            PlayerFlashlight.intensity -= intensityMultiplier * toAdd * sign;
        }
    }
}
