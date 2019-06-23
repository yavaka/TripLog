﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLocation;
using Foundation;
using TripLog.Models;
using TripLog.Services;
using UIKit;

namespace TripLog.iOS.Services
{
    //Location service
    public class LocationService : ILocationService
    {
        CLLocationManager _manager;
        TaskCompletionSource<CLLocation> _tcs;

        public async Task<GeoCoords> GetGeoCoordinatesAsync()
        {
            _manager = new CLLocationManager();
            _tcs = new TaskCompletionSource<CLLocation>();

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                _manager.RequestWhenInUseAuthorization();
            }

            _manager.LocationsUpdated += (s, e) =>
            {
                _tcs.TrySetResult(e.Locations[0]);
            };

            _manager.StartUpdatingLocation();

            var location = await _tcs.Task;

            return new GeoCoords
            {
                Latitude = location.Coordinate.Latitude,
                Longitude = location.Coordinate.Longitude
            };
        }
    }
}