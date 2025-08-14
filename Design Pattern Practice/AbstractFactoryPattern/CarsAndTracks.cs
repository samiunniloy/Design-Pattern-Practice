using System;
namespace AbstractFactoryDesignPattern
{
    public interface IEngine
    {
        string GetEngineType();
    }
    public interface ITire
    {
        string GetTireType();
    }
    public class ElectricCarEngine : IEngine
    {
        public string GetEngineType()
        {
            return "Electric Car Engine";
        }
    }
    public class ElectricCarTire : ITire
    {
        public string GetTireType()
        {
            return "Electric Car Tire";
        }
    }
    public class GasCarEngine : IEngine
    {
        public string GetEngineType()
        {
            return "Gas Car Engine";
        }
    }
    public class GasCarTire : ITire
    {
        public string GetTireType()
        {
            return "Gas Car Tire";
        }
    }

    public class ElectricTruckEngine : IEngine
    {
        public string GetEngineType()
        {
            return "Electric Truck Engine";
        }
    }

    public class ElectricTruckTire : ITire
    {
        public string GetTireType()
        {
            return "Electric Truck Tire";
        }
    }
    public class GasTruckEngine : IEngine
    {
        public string GetEngineType()
        {
            return "Gas Truck Engine";
        }
    }
    public class GasTruckTire : ITire
    {
        public string GetTireType()
        {
            return "Gas Truck Tire";
        }
    }

    public interface IVehicleFactory
    {
        IEngine CreateEngine();
        ITire CreateTire();
    }
    public class ElectricCarFactory : IVehicleFactory
    {
        public IEngine CreateEngine() => new ElectricCarEngine();
        public ITire CreateTire() => new ElectricCarTire();
    }

    public class GasCarFactory : IVehicleFactory
    {
        public IEngine CreateEngine() => new GasCarEngine();
        public ITire CreateTire() => new GasCarTire();
    }

    public class ElectricTruckFactory : IVehicleFactory
    {
        public IEngine CreateEngine() => new ElectricTruckEngine();
        public ITire CreateTire() => new ElectricTruckTire();
    }

    public class GasTruckFactory : IVehicleFactory
    {
        public IEngine CreateEngine() => new GasTruckEngine();
        public ITire CreateTire() => new GasTruckTire();
    }

    public class VehicleManufacturingPlant
    {
        private readonly IEngine _engine;
        private readonly ITire _tire;

        public VehicleManufacturingPlant(IVehicleFactory factory)
        {
            _engine = factory.CreateEngine();
            _tire = factory.CreateTire();
        }

        public void DescribeVehicle()
        {
            Console.WriteLine($"Vehicle with Engine: {_engine.GetEngineType()} and Tire: {_tire.GetTireType()}");
        }
    }

    public class AbstractCarsAndTracks
    {
        public static void main()
        {
            var electricCarFactory = new ElectricCarFactory();
            var electricCarPlant = new VehicleManufacturingPlant(electricCarFactory);
            electricCarPlant.DescribeVehicle();

            var gasTruckFactory = new GasTruckFactory();
            var gasTruckPlant = new VehicleManufacturingPlant(gasTruckFactory);
            gasTruckPlant.DescribeVehicle();

            Console.ReadKey();
        }
    }
}