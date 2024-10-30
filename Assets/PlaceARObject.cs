using UnityEngine;

public class PlaceARObject : MonoBehaviour
{
    public GameObject arObject; // AR object to place
    public float targetLatitude = 59.29880555555555f; // Set to target GPS latitude
    public float targetLongitude = 18.0365f; // Set to target GPS longitude

    private GPSLocationConverter gpsConverter;
    private LocationService locationService;

    void Start()
    {
        // Find GPSLocationConverter component on GPSManager
        gpsConverter = GameObject.Find("GPSManager").GetComponent<GPSLocationConverter>();

        // Get Unity world position from GPS
        Vector3 targetPosition = gpsConverter.ConvertGPStoUnityPosition(targetLatitude, targetLongitude);

        // Place the AR object at the target position
        Instantiate(arObject, targetPosition, Quaternion.identity);


        // Find the LocationService on the LocationManager GameObject
        locationService = GameObject.Find("LocationManager").GetComponent<LocationService>();

        // Get the current location
        Vector2 currentGPSLocation = locationService.GetCurrentGPSLocation();
        Debug.Log("Using current GPS location: " + currentGPSLocation);
    }
}


