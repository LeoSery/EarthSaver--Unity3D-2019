# project-Earth_Saver-2019
Game made during the year 2019 to have fun and learn Unity3D.

## Summary

- Presentation
- How to open the project
- How to build the project 
- Problems solving

## Presentation

Small low poly game, where the goal is to dodge meteorites to prevent them from hitting the planet earth.
![](https://i.imgur.com/NtkgZiz.gif)

Use the mouse to rotate the planet.
![](https://i.imgur.com/XkrxZyd.gif)

You have to make the meteorites fall into the water. If meteorites fall on continents, humanity loses life.
![](https://i.imgur.com/ASLYBFv.gif)

If the life of humanity reaches 0%, you lose.
![](https://i.imgur.com/BPyVUdA.gif)

## How to open the project:

- Clone the git repository to your computer with the following command :
```
git@github.com:LeoSery/EarthSaver--Unity3D-2019.git
```
or 
```
https://github.com/LeoSery/EarthSaver--Unity3D-2019.git
```

- open Unity Hub and do "*Add project from disk*"

    Select "`..\EarthSaver--Unity3D-2019`"

- Check that the project opens with the Unity editor in version "**2020.1.9f1**"

## How to build the project : 

- Once the project is open in Unity, do *"File" > "Build Settings"*

- In the window that has just appeared, in the *"Scenes In Build"* section, make sure that *"scenes/Game"* is checked.

- for the platform choose: *"PC, Mac & Linux Standalone"*

- then choose your platform in *"Target Platform"*

- and finally press *"Build And Run"*

## Problems solving :

The project uses different optional Unity packages. 
If you have an error concerning a package go to: ***"Window > Package Manager"*** and check that you have the following packages installed: 

```
- Post Processing (3.1.1)
- Test Framework (1.1.31)
- Text Mesh Pro (3.0.6)
- Unity UI (1.0.0)
```
