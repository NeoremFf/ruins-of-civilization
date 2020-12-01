using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DitzelGames.PostProcessingTextureOverlay;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    private GameObject interactiveUI = null;

    private PostProcessVolume postProcessVolume = null;
    private DepthOfField depthOfField = null;
    private TextureOverlay textureOverlay = null;

    [SerializeField]
    private PuzzleManager puzzleManager = null;

    private GameObject pressButtonUI = null;
    private bool isPlayerNearby = false;

    private void Start()
    {
        pressButtonUI = GetComponentInChildren<Canvas>().gameObject;
        pressButtonUI.SetActive(false);

        postProcessVolume = FindObjectOfType<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out depthOfField);
        postProcessVolume.profile.TryGetSettings(out textureOverlay);
    }

    private void Update()
    {
        if (isPlayerNearby)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SetInteractiveState(!depthOfField.active);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMover player = other.gameObject.GetComponentInParent<PlayerMover>();
        if (player != null)
        {
            pressButtonUI.SetActive(true);
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMover player = other.gameObject.GetComponentInParent<PlayerMover>();
        if (player != null)
        {
            pressButtonUI.SetActive(false);
            isPlayerNearby = false;

            SetInteractiveState(false);
        }
    }

    private void SetInteractiveState(bool state)
    {
        depthOfField.active = state;
        textureOverlay.active = state;
        if (state)
            puzzleManager.PuzzleStarted();
        else
            puzzleManager.PuzzleCanceled();
    }
}
