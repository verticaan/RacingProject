using UnityEngine;

public class ControllerSwitcher : MonoBehaviour
{
    public void AdvanceController()
    {
        GetComponent<CarController>().enabled = true;
        GetComponent<CarControllerSimple>().enabled = false;
    }

    public void SimpleController()
    {
        GetComponent<CarControllerSimple>().enabled = true;
        GetComponent<CarController>().enabled = false;
    }
}