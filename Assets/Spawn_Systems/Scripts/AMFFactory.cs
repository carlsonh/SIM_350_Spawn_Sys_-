using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAMFFactory
{
    IAMF Create(AMFRequirements vehicleReqs);
}

public class AMFFactory : AbstractVehicleFactory
{
    private readonly IAMFFactory _factory;
    private readonly AMFRequirements _requirements;

    public AMFFactory(AMFRequirements vehicleReqs)
    {
        Debug.Log(vehicleReqs.wingCount);

        _factory = vehicleReqs.amfType switch //what
        {
            AMFType.Animal => (IAMFFactory)new AMFAnimal(),
            AMFType.Mechanical => (IAMFFactory)new AMFMechanical(),
            AMFType.Failure => (IAMFFactory)new AMFFailure(),
        };

        Debug.Log(vehicleReqs.wingCount);


        _requirements = vehicleReqs;
        //Limit checks
        _requirements.wingCount = Mathf.Max(0, vehicleReqs.wingCount);
    }
    public override IAMF Create()
    {
        return _factory.Create(_requirements);
    }
}




public class AMFAnimal : IAMFFactory
{
    public IAMF Create(AMFRequirements vehicleReqs)
    {
        switch (vehicleReqs.wingCount)
        {
            case 0:
                return new Croc(vehicleReqs.bMoving);
            case 2:
                return new Bird(vehicleReqs.bMoving);
            case 4:
                return new Red_Kayle(vehicleReqs.bMoving);
            default:
                return new Croc(vehicleReqs.bMoving);
        }
    }
}

public class AMFMechanical : IAMFFactory
{
    public IAMF Create(AMFRequirements vehicleReqs)
    {
        switch (vehicleReqs.wingCount)
        {
            case 0:
                return new Car(vehicleReqs.bMoving);
            case 2:
                return new Bird(vehicleReqs.bMoving);
            case 4:
                return new Helicopter(vehicleReqs.bMoving);
            default:
                return new Car(vehicleReqs.bMoving);
        }
    }
}

public class AMFFailure : IAMFFactory
{
    public IAMF Create(AMFRequirements vehicleReqs)
    {
        switch (vehicleReqs.wingCount)
        {
            case 0:
                return new Penguin(vehicleReqs.bMoving);
            case 2:
                return new Morgana(vehicleReqs.bMoving);
            case 4:
                return new Kayle_11(vehicleReqs.bMoving);
            default:
                return new Penguin(vehicleReqs.bMoving);
        }
    }
}