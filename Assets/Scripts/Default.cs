using UnityEngine;
using UnityEngine.UI;

public class Default : IState
{
	private Text stateLabel;

	public override void OnEnter (MicrowaveSM sm)
	{
			stateLabel = GameObject.Find ("/Canvas/CurrentStateText/CurrentStateValue").GetComponent<Text> ();
			stateLabel.text = "DEFAULT";
	}

	public override IState OnEvent (MEvent e)
	{
		if (e == MEvent.APP_START) {
			return new Off ();
		}

		return this;
	}
}
