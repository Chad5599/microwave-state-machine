using UnityEngine;
using UnityEngine.UI;

public class Start : IState
{
    private Text stateLabel;

    public void OnEnter()
    {
        stateLabel = GameObject.Find("/Canvas/CurrentStateText/CurrentStateValue").GetComponent<Text>();
        stateLabel.text = "ON";
    }

    public IState OnEvent(MEvent e)
    {
        if (e == MEvent.PRESS_BUTTON)
        {
            return new Off();
        }

        return this;
    }
}
