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

![Dashboard Grafana](https://raw.githubusercontent.com/sliiri/bb_exporter/main/assets/img/screenshot_BBox_Exporter_Grafana.png "Dashboard Grafana")

Télécharger le fichier JSON du dashboard ci-dessus : https://raw.githubusercontent.com/sliiri/bb_exporter/main/assets/grafana/BBox_Exporter.json

## Usage

### Installation

- Télécharger la release sourhaitée.
- Editer le fichier de configuration appsettings.json.
- Renseigner le mot de passe de connexion à l'interface de la BBox.
- Vous pouvez ajuster l'URL de l'interface d'admin de la BBox ou le port d'écoute de l'exporter.

```
{
    "BBoxAPIURL": "https://mabbox.bytel.fr",
    "BBoxPassword": "MYPASS",
    "BBoxAPIRefreshTime": 60,
    "MetricsServerListeningPort": 9100
}
```

### Exécution



### Compilation

TODO
