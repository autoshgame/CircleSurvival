using UnityEngine.UI;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Button btn;

    void Start()
    {
        btn.onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        SoundManager.Instance.PlayAudio(SoundUtils.BUTTON_CLICK);
    }
}
