using _04Encapsulation;

// Create a new Car object
Car secondCar = new Car("BMW", "M5", "Blue", 3);

// Display initial car info (expected error due to invalid door count)
secondCar.CarInfo();

// Correct the number of doors
secondCar.NumberOfDoors = 4;

// Display updated car info
secondCar.CarInfo();
