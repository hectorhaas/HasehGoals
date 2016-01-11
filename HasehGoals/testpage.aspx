<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testpage.aspx.cs" Inherits="HasehGoals.testpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Page</title>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCot4oCuKg6yG2e66UtwMUpZW_yv_grvOQ&callback=initMap" >
    </script>
    <style type="text/css">
      html, body { height: 100%; margin: 0; padding: 0; }
      #map { height: 100%; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <div id="map"></div>
    <script type="text/javascript">
        var map;
        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -34.397, lng: 150.644 },
                zoom: 8
            });
        }

    </script>
</body>
</html>
