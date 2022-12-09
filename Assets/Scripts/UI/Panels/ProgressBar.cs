using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private float progress;
    [SerializeField] private Image image;
    private void Update()
    {
        progress = LevelManager.GetLevelProgress();
        image.fillAmount = progress;
    }
}
