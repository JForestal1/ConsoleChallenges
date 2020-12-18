using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge6_repo
{
    public class CarRepo
    {
        List<Car> _listOfCars = new List<Car>();

        public bool AddCar(Car newCar)
        {
             int preAddCount = _listOfCars.Count();           
            _listOfCars.Add(newCar);
            if (_listOfCars.Count > preAddCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCar(string carName, Car updatedCar)
        {
            bool found = false;
            int index = 0;
            int location = 0;
            foreach(Car each in _listOfCars)
            {
                if (each.Name == carName)
                {
                    found = true;
                    location = index;
                }
                index++;
            }
            if (found)
            {
                _listOfCars[location] = updatedCar;
            }
            return found;
        }

        public bool DeleteCar(string carName)
        {
            bool found = false;
            int index = 0;
            int location = 0;
            foreach (Car each in _listOfCars)
            {
                if (each.Name == carName)
                {
                    found = true;
                    location = index;
                }
                index++;
            }
            if (found)
            {
                _listOfCars.RemoveAt(location);
            }
            return found;
        }

        public List<Car> GetAllCars()
        {
            return _listOfCars;
        }

        public Car GetOneCar(string name)
        {
            bool found = false;
            int index = 0;
            int location = 0;
            foreach (Car each in _listOfCars)
            {
                if (each.Name == name)
                {
                    found = true;
                    location = index;
                }
                index++;
            }
            if (found)
            {
                return _listOfCars[location];
            }
            else
            {
                return null;
            }
        }
    }
}
