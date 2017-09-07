using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class WarmUp : IState
{
	private Text stateLabel;
	private MicrowaveSM machine;

	public override void OnEnter (MicrowaveSM sm)
	{
		stateLabel = GameObject.Find ("/Canvas/CurrentStateText/CurrentStateValue").GetComponent<Text> ();

		if (CameFromState (sm, typeof(Off))) 
		{
			stateLabel.text = "WARMING UP";

			machine = GameObject.Find ("Canvas").GetComponent<MicrowaveSM> ();
			machine.StartCoroutine (WarmUpCR ());
		} 
		else if (CameFromState (sm, typeof(WarmUp))) 
		{
			stateLabel.text = "ALREADY WARMING UP";	
		}
	}

	IEnumerator WarmUpCR ()
	{
		yield return new WaitForSeconds (5f);

		machine.EventHandler (MEvent.WARM_UP_COMPLETE);
	}

	public override IState OnEvent (MEvent e)
	{
		if (e == MEvent.WARM_UP_COMPLETE) {
			return new Start ();
		}

		return this;
	}		
}
