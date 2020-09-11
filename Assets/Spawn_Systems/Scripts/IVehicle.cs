using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicle { }

//Cycles
public class Unicycle : IVehicle { }
public class Bicycle : IVehicle { }
public class Tandem : IVehicle { }
public class Tribike : IVehicle { }
public class FamilyBike : IVehicle { }
public class GoKart : IVehicle { }


//Vehicles
public class Motorbike : IVehicle { }
public class Motortrike : IVehicle { }
public class Truck : IVehicle { }
