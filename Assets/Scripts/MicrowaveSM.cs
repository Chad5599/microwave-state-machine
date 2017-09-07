using UnityEngine;
using UnityEngine.UI;

public enum MEvent
{
    PRESS_BUTTON,
    WARM_UP_COMPLETE
}

public class MicrowaveSM : MonoBehaviour
{
    public IState state;
    public Button button;

    void Awake()
    {
        state = new Off();
        state.OnEnter();

        button.onClick.AddListener(() => { EventHandler(MEvent.PRESS_BUTTON); });
    }

    public void EventHandler(MEvent e)
    {
        state = state.OnEvent(e);
        state.OnEnter();
    }
}
