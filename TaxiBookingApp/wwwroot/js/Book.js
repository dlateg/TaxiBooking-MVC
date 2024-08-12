let map;
let directionsService;
let directionsRenderer;

async function initMap() {
    const { Map } = await google.maps.importLibrary("maps");
    directionsService = new google.maps.DirectionsService();
    directionsRenderer = new google.maps.DirectionsRenderer();
    var mapOptions = {
        zoom: 7,
        center: { lat: 51.5195786, lng: -0.0606907 }
    };
    map = new google.maps.Map(document.getElementById('map'), mapOptions);
    directionsRenderer.setMap(map);
    directionsRenderer.setPanel(document.getElementById('directionsPanel'));

    calculateAndDisplayRoute();
}

function calculateAndDisplayRoute() {
    var data = document.getElementById('nearest_driver').value;
    console.log(data)
    var driver = JSON.parse(data);
    const startLat = driver.Latitude;
    const startLong = driver.Longitude;

    const endLat = parseFloat(latitude);
    const endLong = parseFloat(longitude);

    directionsService.route(
        {
            origin: new google.maps.LatLng(startLat, startLong),
            destination: new google.maps.LatLng(endLat, endLong),
            travelMode: google.maps.TravelMode.DRIVING
        },
        function (response, status) {
            if (status === 'OK') {
                directionsRenderer.setDirections(response);
            } else {
                window.alert('Directions request failed due to ' + status);
            }
        }
    );

    const image = document.getElementById('image-url').value;

    new google.maps.Marker({
        position: { lat: startLat, lng: startLong },
        map: map,
        icon: image,
    });
}


window.onload = initMap;
