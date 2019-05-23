using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{

    public static BatteryBar s_instance;
    public static GameObject bar;
    private bool removed = false;
    public static int misses = 0;

    private Action gameOverCallback;

    public static Action GameOverCallback
    {
        get
        {
            return s_instance.gameOverCallback;
        }

        set
        {
            s_instance.gameOverCallback = value;
        }
    }

    // Use this for initialization
    void Awake()
    {
        if (s_instance != null)
        {
            Destroy(this);
        }

        s_instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        if (s_instance == null) { return; }
    }

    void Update()
    {
        if (!removed)
        {
            GameObject life = GameObject.Find("[Life Left]");
            s_instance.transform.parent = life.transform;
            s_instance.transform.localPosition = new Vector3(0, 0, 0);
            bar.transform.parent = life.transform;
            bar.transform.localPosition = new Vector3(0, 0.01f, 0.01f);
            SpriteRenderer[] sr = life.GetComponentsInChildren<SpriteRenderer>();
            sr[0].sprite = null;
            sr[1].sprite = null;
            removed = true;
        }
    }

    public static void hit()
    {
        if (misses < 4)
        {
            misses++;
            bar.transform.localScale = new Vector3(1-misses/4f, 1, 1);
            bar.transform.localPosition = new Vector3(-misses/2.9f, 0.01f, 0.01f);
        }
        if (misses >= 4)
        {
            if (GameOverCallback != null)
            {
                GameOverCallback();
            }
        }
    }

    public static void DestroyBatteryBar()
    {
        if (s_instance == null) { return; }

        Destroy(s_instance);
    }
}
