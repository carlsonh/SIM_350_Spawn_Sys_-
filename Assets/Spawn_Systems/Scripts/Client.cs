using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public VehicleRequirements vehicleReqs = new VehicleRequirements();

    private static IVehicle GetVehicle(VehicleRequirements reqs)
    {
        VehicleFactory _factory = new VehicleFactory(reqs);
        return _factory.Create();
    }





    #region UI Setting Vehicle Requirements
    public void SetWheelCount(int wheelCount)
    {
        vehicleReqs.wheelCount = wheelCount + 1;//UI pass offset
    }
    public void SetPassengerCount(int passengerCount)
    {
        vehicleReqs.passengerCount = passengerCount + 1;//UI pass offset
    }

    public void SetUsesEngine(bool useEngine)
    {
        vehicleReqs.bEngine = useEngine;
    }

    public void SetHasCargo(bool useCargo)
    {
        vehicleReqs.bCargo = useCargo; //Ignored in the factory
    }

    #endregion UI Setting Vehicle Requirements

    public void CreateVehicle()
    {
        IVehicle vhc = GetVehicle(vehicleReqs);
        Debug.Log(vhc + " produced");
    }

}
