using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Slider levelSlider;
    public EnemySpawner enemySpawner;

    private void Awake()
    {
        levelSlider.onValueChanged.AddListener(OnLevelChanged);
    }

    private void OnLevelChanged(float value)
    {
        enemySpawner.spawnRate = Mathf.Lerp(1f, 10f, 1 - value); // adjust as needed
    }
}
