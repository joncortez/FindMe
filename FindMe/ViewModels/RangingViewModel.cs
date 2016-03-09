using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Acr;
using Estimotes;
using FindMe.Models;
using FindMe.Services;
using Syncfusion.SfGauge.XForms;
using Xamarin.Forms;

namespace FindMe.ViewModels
{
    public class RangingViewModel : LifecycleViewModel
    {
        private readonly BeaconRegion _beaconRegion;

        public ObservableCollection<LinearScale> Scales { get; }

        private int _proximity;
        public int Proximity
        {
            get { return _proximity; }
            set
            {
                if (_proximity != value)
                {
                    _proximity = value;
                    OnPropertyChanged();
                }
            }
        }

        public RangingViewModel(Attendee attendee)
        {
            Scales = new ObservableCollection<LinearScale>();
            ConfigureGauge();

            var eventService = ServiceLocator.EventService;
            var uuid = eventService.Event.BeaconUuid;
            var major = ushort.Parse(eventService.Event.BeaconMajor);
            var beaconName = attendee.Beacon.Name;
            var minor = ushort.Parse(attendee.Beacon.Minor);

            _beaconRegion = new BeaconRegion(beaconName, uuid, major, minor);

            EstimoteManager.Instance.Ranged += this.OnRanged;
            EstimoteManager.Instance.StartRanging(_beaconRegion);
        }

        public void Cleanup()
        {
            EstimoteManager.Instance.Ranged -= this.OnRanged;
            EstimoteManager.Instance.StopRanging(_beaconRegion);
        }

        private void OnRanged(object sender, IEnumerable<IBeacon> beacons)
        {
            var beacon = beacons.FirstOrDefault();
            if (beacon != null)
            {
                switch (beacon.Proximity)
                {
                    case Estimotes.Proximity.Immediate:
                        Proximity = 100;
                        break;
                    case Estimotes.Proximity.Near:
                        Proximity = 66;
                        break;
                    case Estimotes.Proximity.Far:
                        Proximity = 33;
                        break;
                    case Estimotes.Proximity.Unknown:
                    default:
                        Proximity = 0;
                        break;
                }

                var scale = Scales.FirstOrDefault();
                foreach (var linearPointer in scale.Pointers)
                {
                    linearPointer.Value = Proximity;
                }
            }
        }

        private void ConfigureGauge()
        {
            // Adding scale to Lineargauge.
            var scale = new LinearScale();
            scale.MinimumValue = 0;
            scale.MaximumValue = 100;
            scale.Interval = 20;
            scale.ScaleBarLength = 100;
            scale.ScaleBarColor = Color.FromRgb(250, 236, 236);
            scale.LabelColor = Color.FromRgb(84, 84, 84);
            scale.MinorTicksPerInterval = 1;
            scale.ScaleBarSize = 13;
            scale.ScalePosition = ScalePosition.BackWard;

            // Major Ticks setting
            var major = new LinearTickSettings();
            major.Length = 10;
            major.Color = Color.FromRgb(175, 175, 175);
            major.Thickness = 1;
            scale.MajorTickSettings = major;

            // Minor Ticks setting
            var minor = new LinearTickSettings();
            minor.Length = 10;
            minor.Color = Color.FromRgb(175, 175, 175);
            minor.Thickness = 1;
            scale.MinorTickSettings = minor;

            var pointers = new List<LinearPointer>();

            // SymbolPointer
            var symbolPointer = new SymbolPointer();
            symbolPointer.Value = 0;
            symbolPointer.Offset = 0.0;
            symbolPointer.Thickness = 3;
            symbolPointer.Color = Color.FromRgb(65, 77, 79);

            // BarPointer
            var rangePointer = new BarPointer();
            rangePointer.Value = 0;
            rangePointer.Color = Color.FromRgb(206, 69, 69);
            rangePointer.Thickness = 10;
            pointers.Add(symbolPointer);
            pointers.Add(rangePointer);

            scale.Pointers = pointers;

            Scales.Add(scale);
        }
    }
}
