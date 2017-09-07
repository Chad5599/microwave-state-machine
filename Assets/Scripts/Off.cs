using UnityEngine;
using UnityEngine.UI;

public class Off : IState
{
    private Text stateLabel;

	public override void OnEnter(MicrowaveSM sm)
    {
		if ((CameFromState(sm, typeof(Start))) || (CameFromState(sm, typeof(Default))) ) 
		{
			stateLabel = GameObject.Find ("/Canvas/CurrentStateText/CurrentStateValue").GetComponent<Text> ();
			stateLabel.text = "OFF";
		}
    }

    public override IState OnEvent(MEvent e)
    {
        if (e == MEvent.PRESS_BUTTON)
        {
            return new WarmUp();	
        }

        return this;
    }
}
