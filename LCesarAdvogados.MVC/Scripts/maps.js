function initialize()
{
    var myLatLng = new google.maps.LatLng(-22.751305, -47.327010);
    var map = new google.maps.Map(document.getElementById("map"),
    {
        zoom: 17,
        center: myLatLng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    var marker = new google.maps.Marker(
    {
        position: myLatLng,
        map: map,
        title: 'L.CESAR Advogados'
    });
}