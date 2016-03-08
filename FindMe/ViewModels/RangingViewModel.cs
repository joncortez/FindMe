using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Acr;
using Estimotes;

namespace FindMe.ViewModels
{
    public class RangingViewModel : LifecycleViewModel
    {
        public BeaconViewModel BeaconViewModel { get; set; }
        public BeaconRegion Region { get; set; }

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

        public RangingViewModel()
        {
            Region = new BeaconRegion("Jon's beacon 1", "B9407F30-F5F8-466E-AFF9-25556B57FE6D", 57790, 32936);

            EstimoteManager.Instance.Ranged += this.OnRanged;
//            var status = await EstimoteManager.Instance.Initialize();
//            if (status != BeaconInitStatus.Success)
//                Debug.WriteLine($"Beacon functionality failed - {status}"); // TODO: Display alert
//            else
                EstimoteManager.Instance.StartRanging(Region);
        }

        public void Cleanup()
        {
            EstimoteManager.Instance.Ranged -= this.OnRanged;
            EstimoteManager.Instance.StopRanging(Region);
        }

        public override void OnStart()
        {
            Region = new BeaconRegion("ice", "B9407F30-F5F8-466E-AFF9-25556B57FE6D", 57790, 32936);
            base.OnStart();
        }

        public override async void OnActivate()
        {
            base.OnActivate();

            EstimoteManager.Instance.Ranged += this.OnRanged;
            var status = await EstimoteManager.Instance.Initialize();
            if (status != BeaconInitStatus.Success)
                Debug.WriteLine($"Beacon functionality failed - {status}"); // TODO: Display alert
            else
                EstimoteManager.Instance.StartRanging(Region);
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
            }
        }
    }
}
