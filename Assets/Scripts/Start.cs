﻿using UnityEngine;
using UnityEngine.UI;

public class Start : IState
{
	private Text stateLabel;

	public override void OnEnter (MicrowaveSM sm)
	{
		if (CameFromState (sm, typeof(WarmUp))) 
		{
			stateLabel = GameObject.Find ("/Canvas/CurrentStateText/CurrentStateValue").GetComponent<Text> ();
			stateLabel.text = "ON";
		}
	}

	public override IState OnEvent (MEvent e)
	{
		if (e == MEvent.PRESS_BUTTON) {
			return new Off ();
		}

		return this;
	}
}
