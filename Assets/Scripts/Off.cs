using UnityEngine;
using UnityEngine.UI;

public class Off : IState
{
    private Text stateLabel;

    public void OnEnter()
    {
        stateLabel = GameObject.Find("/Canvas/CurrentStateText/CurrentStateValue").GetComponent<Text>();
        stateLabel.text = "OFF";
    }

    public IState OnEvent(MEvent e)
    {
        if (e == MEvent.PRESS_BUTTON)
        {
            return new WarmUp();	
        }

        return this;
    }
}
