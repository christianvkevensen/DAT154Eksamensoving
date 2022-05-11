using CarMVVM.Models;

namespace CarMVVM.ViewModel
{
    public interface ICarViewModel 
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Model { get; set; }

        public int Year { get; set; }

        public List<Car> Cars { get; set; }
        public List<CarViewModel> Lst { get; set; }
        public void LoadCurrenctObject(List<Car> cars) { }
        public async Task DeleteCar(int id) { }

        public async Task GetCars() { }

        public async Task AddCar(String name, String model, int year) { }
        public async Task EditCar(int id, String name, String model, int year) { }
    }
}
