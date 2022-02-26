# bb_exporter

bb_exporter est un [Exporter](https://prometheus.io/docs/instrumenting/exporters/) [Prometheus](https://prometheus.io) pour la [Box fibre Ultym de Bouygues Telecom](https://www.bouyguestelecom.fr/offres-internet/bbox-ultym).

Il a été développé en .Net 6 et est compatible avec les plateformes :
- Linux x64 (testé)
- Linux ARM (testé)
- Linux ARM64
- Win x86
- Win x64
- OSX x64

Une fois l'exporter installé, configuré et intégré à Prometheus, les graphiques ci-dessous peuvent être créés dans Grafana :

![Dashboard Grafana](https://github.com/sliiri/bb_exporter/blob/main/assets/screenshot_BBox%20Exporter_Grafana.png "Dashboard Grafana")
