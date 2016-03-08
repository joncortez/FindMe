using Estimotes;

namespace FindMe.ViewModels
{
    public class BeaconViewModel : BaseViewModel
    {
        public string Uuid { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
        public string Proximity { get; set; }

        public BeaconViewModel(IBeacon beacon)
        {
            this.Uuid = beacon.Uuid;
            this.Major = $"{beacon.Major}";
            this.Minor = $"{beacon.Minor}";
            this.Proximity = $"{beacon.Proximity}";
        }
    }
}
