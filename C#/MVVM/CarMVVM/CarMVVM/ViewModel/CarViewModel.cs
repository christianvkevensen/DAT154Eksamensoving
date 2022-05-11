using CarMVVM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace CarMVVM.ViewModel
{
    public class CarViewModel : ICarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }

        public int Year { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();

        public List<CarViewModel> Lst { get; set; } = new ();

        private HttpClient _httpClient;

        public CarViewModel()
        {

        }

        public CarViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task EditCar(int id, String name, String model, int year)
        {
            Car car = new Car();
            car.Id = id;
            car.Name = name;
            car.Year = year;
            car.Model = model;
            car.Year = year;
            await _httpClient.PutAsJsonAsync("api/Cars/"+id, car);
            GetCars();
        }

        public async Task GetCars()
        {
            List<Car> cars = await _httpClient.GetFromJsonAsync<List<Car>>("api/Cars");
            LoadCurrenctObject(cars);
        }
        public async Task DeleteCar(int id)
        {
            await _httpClient.DeleteAsync("api/cars/" + id);
            GetCars();
        }

        public async Task AddCar(String name, String model, int year)
        {
            Car car = new Car();
            car.Name = name;
            car.Model = model;
            car.Year = year;
            _httpClient.PostAsJsonAsync("api/Cars/", car);
            GetCars();
        }

        public void LoadCurrenctObject(List<Car> cars)
        {
            this.Cars = new List<Car>();
            foreach (var car in cars)
            {
                this.Cars.Add(car);
            }
        }

        public static implicit operator Car(CarViewModel carViewModel)
        {
            return new CarViewModel
            {
                Id = carViewModel.Id,
                Name = carViewModel.Name,
                Model = carViewModel.Model,
                Year = carViewModel.Year,
            };
        }
        public static implicit operator CarViewModel(Car car)
        {
            return new Car
            {
                Id = car.Id,
                Name = car.Name,
                Model = car.Model,
                Year=car.Year,                
            };
        }
    }
}
