using System.Collections;
using UnityEngine;

public class ShaderController
{
    public const float DefaultDissolveTime = 0.5f;
    public const string DissolveAmountProperty = "_DissolveAmount";
    public const string VerticalDissolveAmountProperty = "_VerticalDissolveAmount";

    public static IEnumerator Vanish(Material[] materials)
    {
        float elapsedTime = 0f;

        while (elapsedTime < DefaultDissolveTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpedDissolve = Mathf.Lerp(0.290f, 1f, elapsedTime / DefaultDissolveTime);
            float lerpedVerticalDissolve = Mathf.Lerp(0.290f, 1.1f, elapsedTime / DefaultDissolveTime);

            foreach (var mat in materials)
            {
                if (mat != null)
                {
                    mat.SetFloat(DissolveAmountProperty, lerpedDissolve);
                    mat.SetFloat(VerticalDissolveAmountProperty, lerpedVerticalDissolve);
                }
            }

            yield return null;
        }
    }

    public static void ResetDesolveToDefaults(params Material[] materials)
    {
        foreach (var mat in materials)
        {
            if (mat != null)
            {
                mat.SetFloat(DissolveAmountProperty, 0);
                mat.SetFloat(VerticalDissolveAmountProperty, 0);
            }
        }
    }
}