using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiService.Models;
using TaxiService.ViewModels;

namespace TaxiService.Components
{
    public class DriversList : ViewComponent
    {
        private readonly IDriversRepository _driversRepository;
        private readonly ITimeRepository _timeRepository;

        public DriversList(IDriversRepository driversRepository, ITimeRepository timeRepository)
        {
            _driversRepository = driversRepository;
            _timeRepository = timeRepository;
        }
        public IViewComponentResult Invoke(string selectedStatus, string selectedVehicleType)
        {
            DriversListViewModel driversListViewModel = new DriversListViewModel();
            IEnumerable<Drivers> driversFilteredByStatus = null;
            IEnumerable<Drivers> driversFilteredByVehicleType = null;
            IEnumerable<Drivers> driversFilteredByStatusAndVehicleType = null;

            driversListViewModel.Times = _timeRepository.AllTimes;

            if (selectedStatus == "" && selectedVehicleType == "")
            {
                driversListViewModel.Drivers = _driversRepository.AllDrivers;
                return View(driversListViewModel);
            }
            else if (selectedVehicleType == "") {
                driversFilteredByStatus = _driversRepository.GetDriversByStatus(selectedStatus);
                driversListViewModel.Drivers = driversFilteredByStatus;
                return View(driversListViewModel);
            }
            else if (selectedStatus == "")
            {
                driversFilteredByVehicleType = DriversRepository.GetDriversFromCollectionByVehicleType(_driversRepository.AllDrivers, selectedVehicleType);
                driversListViewModel.Drivers = driversFilteredByVehicleType;
                return View(driversListViewModel);
            }
           
            driversFilteredByStatus = _driversRepository.GetDriversByStatus(selectedStatus);
            driversFilteredByStatusAndVehicleType = DriversRepository.GetDriversFromCollectionByVehicleType(driversFilteredByStatus, selectedVehicleType);
            driversListViewModel.Drivers = driversFilteredByStatusAndVehicleType;
            return View(driversListViewModel);
        }
    }
}
