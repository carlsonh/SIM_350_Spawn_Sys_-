using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicleFactory
{
    IVehicle Create(VehicleRequirements vehicleReqs);
}

public class VehicleFactory : AbstractVehicleFactory
{
    private readonly IVehicleFactory _factory;
    private readonly VehicleRequirements _requirements;

    public VehicleFactory(VehicleRequirements vehicleReqs)
    {
        _factory = vehicleReqs.bEngine ? (IVehicleFactory)new MotorVehicleFactory() : new CycleFactory();


        _requirements = vehicleReqs;
        //Limit checks
        _requirements.wheelCount = Mathf.Max(1, vehicleReqs.wheelCount);
        _requirements.passengerCount = Mathf.Max(1, vehicleReqs.passengerCount);

    }
    public override IVehicle Create()
    {
        return _factory.Create(_requirements);
    }
}




public class CycleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements vehicleReqs)
    {
        switch (vehicleReqs.passengerCount)
        {
            case 1:
                if (vehicleReqs.wheelCount == 1) return new Unicycle();
                return new Bicycle();
            case 2:
                return new Tandem();
            case 3:
                return new Tribike();
            case 4:
                if (vehicleReqs.bCargo) return new GoKart();
                return new FamilyBike();
            default:
                return new Bicycle();
        }
    }
}

public class MotorVehicleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements vehicleReqs)
    {
        switch (vehicleReqs.passengerCount)
        {
            case 1:
                return new Motorbike();
            case 2:
                return new Motortrike();
            default:
                return new Truck();
        }
    }
}