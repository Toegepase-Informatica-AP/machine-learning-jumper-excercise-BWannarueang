# Unity ML-Agents: Jumper opdracht

## Benodigdheden

- Unity v...
- Unity project
- Python / anaconda

## Installatie & Set-up

- Unity package
- Python package

## Project voorbereiding# Unity ML-Agents: Jumper opdracht

Team VR-Brothers: Bunyarit Wannarueang & Younes Hlalem

<small>2020 - 2021</small>

![Afbeelding game](img/1.png)

## Introductie

In dit project zien we hoe we met behulp van ML-Agents een zelflerende agent kunnen creëren die een obstakel zal herkennen en aan de hand hiervan een besluit zal nemen om het object te ontwijken door er over te springen of erdoor te worden geraakt. Het obstakel krijgt elke episode een andere snelheid mee en de agent moet over bepaalde obstakels springen, maar andere obstakels genereren bonuspunten bij collision.

## Benodigdheden

- Unity game-engine
  - Unity project (Jumper opdracht)
  - Ml-agents Unity package v1.0.5
- Visual studio
- Python 3
  - Anaconda (Python environment)
  - Tensorflow

## Beloning systeem

Onze jumper zal moeten leren een onderscheid te moeten maken tussen obstakels en bonuspunten. Dit kunnen we hem aanleren doormiddel van een puntensysteem. Het een zal punten aftrekken als hij een obstakel raakt en punten bij tellen bij het raken van een bonus. Hieronder staan de mogelijke situaties duidelijk opgesomd.

| Observatie        |  Actie   |   Beloning |
| :---------------- | :------: | ---------: |
| Inkomend obstakel | Springen |   + 1 punt |
| Inkomend obstakel |  Raken   |   - 1 punt |
| Inkomende bonus   | Springen | - 0.5 punt |
| Inkomende bonus   |  Raken   |   + 1 punt |

## Game omgeving

Onze game bevat enkele essentiële basis elementen; zoals de camera en belichting. Daaronder vind men de Environment game-object. Dit was een leeg object waarin we vervolgens alle nodige elementen, die direct impact zullen hebben op de agent, in verzamelen.

![Afbeelding game omgeving](img/2.png)

Hierin bevinden zich:

- Score: Een tekstvak die zich fysiek op het speelveld bevindt zodat de gebruiker duidelijk de punten kan meevolgen.
- Ground: Dit object spreekt voor zich. Het is de grond waarvan de speler zich afduwt, waarop hij land en waarover de obstakels zich verschuiven.
- Spawner: Bevat meerdere elemanten maar is vooral verantwoordelijk voor het puntensysteem, het spawnen van objecten en het verwijdere van onnodige objecten.
  - Player: Dit is de jumper die over obstakels springt. Hier maken we een agent van.
  - Wall: Bevind zich achter de speler en bevat maar een script, sinds het maar een functie heeft; De obstakels verwijderen die al voorbij de speler zijn geraakt.

### Player

Zoals eerder vermeld wordt de Player object gebruikt door ML-Agent als agent om hem zo voor ons spelletje te trainen. De speler kan zich niet verplaatsen, hij kan enkel springen.

![Afbeelding player](img/3.png)

De Speler bevat 3 belangrijke componenten:

- Jumper script: Om hem te laten springen
- Behavior Parameters: Om aan te tonen dat dit de agent is en hoe hij getraint moet worden
- Ray perception sensor: Dit compontent vormt de "ogen" van onze agent, hiermee kan hij objecten identificeren vanop afstand.

![Afbeelding player](img/4.png)

## Trainen

Uiteindelijk moeten we de agent trainen. Om de Agent te trainen hebben we een python omgeving nodig waarin we gebruik maken van ml- agents. Maak een nieuwe folder aan in je project, genaamd Learning. Dit zal alle bestanden die bij het trainen nodig zijn en worden gecreërd duidelijk scheiden. Voeg in deze map volgend yml bestand, genaamd "Jumper.yml", toe.

```yml
behaviors:
  Jumper:
    trainer_type: ppo
    max_steps: 5.0e5
    time_horizon: 64
    summary_freq: 10000
    keep_checkpoints: 5
    checkpoint_interval: 50000

    hyperparameters:
      batch_size: 32
      buffer_size: 9600
      learning_rate: 3.0e-4
      learning_rate_schedule: constant
      beta: 5.0e-3
      epsilon: 0.2
      lambd: 0.95
      num_epoch: 3

    network_settings:
      num_layers: 2
      hidden_units: 128
      normalize: false
      vis_encoder_type: simple

    reward_signals:
      extrinsic:
        strength: 1.0
        gamma: 0.99
      curiosity:
        strength: 0.02
        gamma: 0.99
        encoding_size: 256
        learning_rate: 1e-3
```

Vervolgens moeten we dit config-bestand runnen. Het trainen wordt gestart na volgend commando uit te voeren in je terminal.

```
mlagents-learn Jumper.yml --run-id Jumper-01
```

Meteen na het starten moet men op unity op start klikken zodat ml-agents dit kan detecteren.

Het trainingsproces kan je live monitoren. Via TensorBoard kan ,en gemakkelijk een overzicht openen. Gebruik hiervoor volgend commando in je terminal.

```
tensorboard --logdir results
```

Als er na dit commando niet automatisch een nieuw scherm opent kan je dit zelf doen door naar <http://localhost:6006> te gaan in je browser.

- Objecten in ons spel, nodige code, etc...

## Trainen

- Agents trainen
