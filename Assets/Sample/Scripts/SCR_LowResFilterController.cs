using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SCR_LowResFilterController : MonoBehaviour
{
    [field: Header("_")]
    [field: SerializeField] private UniversalRenderPipelineAsset urpAsset = null;

    [field: Space(10), Header("_")]
    [field: SerializeField] private Vector2 targetResolution = new(640, 480);

    private void Start() => Set();
#if UNITY_EDITOR
    private void OnValidate() => Set();
#endif

    private void Set()
    {
        if (urpAsset == null)
        {
            return;
        }

        if (targetResolution.x <= 64)
        {
            return;
        }

        if (targetResolution.y <= 64)
        {
            return;
        }

        urpAsset.upscalingFilter = UpscalingFilterSelection.Point;
        urpAsset.renderScale = Screen.currentResolution.height > targetResolution.y ? (1 / (Screen.currentResolution.height / targetResolution.y)) : 1;
        urpAsset.msaaSampleCount = 1;
    }
}