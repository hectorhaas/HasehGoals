<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MyPlaces.aspx.cs" Inherits="HasehGoals.MyPlaces" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }

        #map {
            height: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <h1>My Places</h1>
        </div>
        <div class="row" style="height: 100%; width: 100%;">
            <div id="map" style="height: 600px; width: 100%;"></div>
            &nbsp;
        </div>
        <script type="text/javascript">
            //$(window).resize(function () {
            //    var h = $(window).height(),
            //        offsetTop = 60; // Calculate the top offset

            //    $('#map').css('height', (h - offsetTop));
            //}).resize();
            var map;
            function initMap() {
                map = new google.maps.Map(document.getElementById('map'), {
                    center: { lat: 39.50, lng: -98.35 },
                    zoom: 4
                });
                var image = {
                    url: '_img/retard.jpg',
                    scaledSize: new google.maps.Size(50, 50),
                    origin: new google.maps.Point(0, 0),
                    anchor: new google.maps.Point(0, 50)
                };
                var myLatlng = new google.maps.LatLng(-25.363882, 131.044922);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    title: "Hello World!",
                    icon: image
                });
                // To add the marker to the map, call setMap();
                marker.setMap(map);
            }
        </script>
        <script async defer
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCot4oCuKg6yG2e66UtwMUpZW_yv_grvOQ&callback=initMap">
        </script>
    </div>
</asp:Content>
