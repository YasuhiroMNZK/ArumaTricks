using UnityEngine;

public class Pause : MonoBehaviour
{
    // ---- シングルトン的アクセス ----
    public static Pause Instance { get; private set; }

    // 一時暂停フラグ
    [SerializeField] private bool isPaused = false;

    // 現在の暂停状態をどこからでも参照できる静的プロパティ
    public static bool IsPausedStatic => Instance != null && Instance.isPaused;

    private void Awake()
    {
        // シンプルなシングルトン
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // ---- 外部から呼ぶ API ----

    // トグル动作
    public void TriggerPause()
    {
        SetPaused(!isPaused);
    }

    // 暂停専用
    public void PauseGame()
    {
        SetPaused(true);
    }

    // 恢复専用
    public void ResumeGame()
    {
        SetPaused(false);
    }

    // static ラッパー
    public static void StaticPause()
    {
        if (Instance != null)
        {
            Instance.PauseGame();
        }
    }

    public static void StaticResume()
    {
        if (Instance != null)
        {
            Instance.ResumeGame();
        }
    }

    // 暂停状態のセット
    public void SetPaused(bool pause)
    {
        if (isPaused == pause) return;

        isPaused = pause;

        if (isPaused)
        {
            OnPaused();
        }
        else
        {
            OnResumed();
        }
    }

    // 暂停になった瞬間に 1 回だけ呼ばれる
    private void OnPaused()
    {
        // ゲーム全体を停止
        Time.timeScale = 0f;

        // 必要ならここで暂停 UI を表示
        // PauseMenu.SetActive(true);
    }

    // 暂停解除になった瞬間に 1 回だけ呼ばれる
    private void OnResumed()
    {
        // ゲーム全体を再开
        Time.timeScale = 1f;

        // 必要ならここで暂停 UI を非表示
        // PauseMenu.SetActive(false);
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
