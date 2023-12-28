# Projet d'Animation Procédurale sur Unity

## Objectifs

Le projet d'animation procédurale sur Unity a pour objectif de créer une animation réaliste à l'aide de techniques procédurales. Il peut inclure des fonctionnalités telles que des mouvements générés de manière aléatoire, des réponses aux interactions de l'utilisateur, etc.

## Installation

1. **Prérequis :**
   Assurez-vous d'avoir Unity installé sur votre machine.

2. **Clonage du Projet :**
git clone https://lien-vers-votre-repository.git
cd nom-du-repository


3. **Ouverture du Projet dans Unity :**
- Ouvrez Unity Hub.
- Ajoutez le projet en sélectionnant le dossier cloné.

4. **Compilation et Exécution :**
- Compilez et exécutez le projet à l'aide d'Unity.

## Organisation du Code

Le code du projet est organisé comme suit (tout est dans Assets):

- **Scripts/ :** Contient tous les scripts C# nécessaires.
    - **GameScripts/ :**: Scripts necessaire au fonctionnement du jeu
        - `CarCollision.cs`: Script pour les collisions du personnages avec les voitures 
        - `Destroyer.cs`: Script pour detruire les sections au bout d'un certain temps
        - `GenerateLevel.cs`: Script pour génèrer une nouvelle section (endless runner) 
        - `LevelBoundary.cs`: Script pour ne pas depasser les limites du décor 
        - `LevelDistance.cs`: Script pour le score
        - `LevelStarter.cs`: Script pour le début du jeu avec le compte a rebours
        - `MainMenuFunction.cs`: Script pour l'affichage du menu
        - `ObstacleCollision.cs`: Script pour les collisions du personnage avec les obstacles
        - `PlayerMove.cs`: Script pour l'animation du personnage

    - **ProAnimScripts/ :**: Scripts necessaire au l'animation procédurale
        - `LegController.cs`: Script pour l'animation procédurale des pattes
        - `BodyMove.cs`: Script pour faire bouger le corps
        -  Autres : Anciens script non utilisé dans le projet mais a servi de base à notre réflexion. 

- **Characters/ :** Stocke les personnages
- **Game/ :** Stocke les animations, materiaux, fontes, sons utilisés dans le jeu
- **Decor/ :** Stocke le décor utilisées dans le projet.
- **Scenes/ :** Contient les scènes Unity.

## Résultats

Les résultats du projet incluent :
- Animation d'une créature générée de manière procédurale.
- Réponse aux interactions de l'utilisateur .
- Effets visuels et sonores

## Auteur

Aleyna YAGBASAN, Miryam ATAMNA, Mariam EL OUARRAD

---

