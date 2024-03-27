using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    private int currentCar;

    public CarStatsAnimation carStatsAnim;

    private void Start()
    {
        currentCar = SaveManager.instance.currentCar;
        SelectCar(currentCar);
    }
    private void SelectCar(int _index)
    {
        //previousButton.interactable = (_index != 0);
        //nextButton.interactable= (_index != transform.childCount-1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }

        switch (_index)
        {
            case 0:
                carStatsAnim.FrostBladeStatsAnimIn();
                carStatsAnim.PaveMasterStatsAnimOut();
                carStatsAnim.DesertShiftStatsAnimOut();
                break;
            case 1:
                carStatsAnim.PaveMasterStatsAnimIn();
                carStatsAnim.FrostBladeStatsAnimOut();
                carStatsAnim.DesertShiftStatsAnimOut();
                break;
            case 2:
                carStatsAnim.DesertShiftStatsAnimIn();
                carStatsAnim.FrostBladeStatsAnimOut();
                carStatsAnim.PaveMasterStatsAnimOut();
                break;
            default:
                // Handle cases for other indices if needed
                break;
        }
    }

    public void ChangeCar(int _change)
    {
        currentCar += _change;

        if (currentCar > transform.childCount - 1)
            currentCar = 0;
        else if (currentCar < 0)
            currentCar = transform.childCount - 1;

        SaveManager.instance.currentCar = currentCar;
        SaveManager.instance.Save();

        SelectCar(currentCar);
    }
}
