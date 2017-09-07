using UnityEngine;
using UnityEngine.UI;

public enum MEvent
{
	APP_START,
    PRESS_BUTTON,
    WARM_UP_COMPLETE
}

public class MicrowaveSM : MonoBehaviour
{
    public IState previousState;
    public Button button;

	private IState state;

    void Awake()
    {
		button.onClick.AddListener(() => { EventHandler(MEvent.PRESS_BUTTON); });
		EventHandler(MEvent.APP_START);
    }

    public void EventHandler(MEvent e)
    {
		
		if (state == null)
		{
			state = new Default();
		} 

		previousState = state;

		state = state.OnEvent(e);
		state.OnEnter(this);

    }
}
