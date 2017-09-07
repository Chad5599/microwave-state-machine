using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class WarmUp : IState
{
    private Text stateLabel;
    private MicrowaveSM machine;
    private bool isWarmingUp;

    public void OnEnter()
    {
        if (!isWarmingUp)
        {
            isWarmingUp = true;

            stateLabel = GameObject.Find("/Canvas/CurrentStateText/CurrentStateValue").GetComponent<Text>();
            stateLabel.text = "WARMING UP";

            machine = GameObject.Find("Canvas").GetComponent<MicrowaveSM>();
            machine.StartCoroutine(WarmUpCR());
        }
    }

    IEnumerator WarmUpCR()
    {
        yield return new WaitForSeconds(5f);

        machine.EventHandler(MEvent.WARM_UP_COMPLETE);
    }

    public IState OnEvent(MEvent e)
    {
        if (e == MEvent.WARM_UP_COMPLETE)
        {
            isWarmingUp = false;

            return new Start();
        }

        return this;
    }
}
