<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="geoCache.Demo._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="http://openlayers.org/api/OpenLayers.js"></script>

    <script type="text/javascript">
        <!--
        var map, layer;

        function init(){
            map = new OpenLayers.Map($('map'), { maxResolution: 1.40625 / 2 });
            var cacheUrl = "geoCache.ashx?";
            map.addLayer(new OpenLayers.Layer.WMS("VMap0", cacheUrl, { layers: 'basic', format: 'image/png' }));
            //map.addControl(new OpenLayers.Control.LayerSwitcher());
            map.addControl(new OpenLayers.Control.Permalink());
            if (!map.getCenter()) map.zoomToMaxExtent();
        }
        // -->
    </script>

</head>
<body onload="init()">
    <div id="map" style="width:1024px;height:512px;margin:10px;border: 1px solid #888;"></div> 
    <form id="form1" runat="server">
    </form>
</body>
</html>
