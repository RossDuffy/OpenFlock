# OpenFlock_2
## About
OpenFlock is a customisable, Open-source flock simulation assets for the Unity game engine's 2D and 3D environments.

### Features
Simulation Scripts:
- Flock: spawns a flock when the simulation is run, holds the agent prefab and behaviour object
- Flock Agent: each flock individual, holds a Circle/Sphere Collider

Behaviours:
- Alignment
- Cohesion
- Steered Cohesion (a smoother version of cohesion)
- Separation
- Obstacle Avoidance
- Go To Flag
- Predator Chase
- Prey Flee
- Stay-in-Radius
- Composite (for combining behaviours)

Filters:
- Different Flock
- Same Flock
- Physics Layer (used for obstacle avoidance and go to flag)

Abstract classes:
- Flock Behaviour
- Filtered Flock Behaviour
- Context Filter

Custom Editors:
- Flock Editor
- Composite Behaviour Editor
- Stay in Radius Behaviour Editor

All of these features exist for both the 2D and 3D simulation. It is also possible for a user to change any of these scripts, extend the abstract classes, or create new features as they see fit.

## Installing

To install the assets, pull them into your Unity project's Assets folder. The Open_Flock folder will contain behaviour and filter scripts, and example scenes and objects for both 2D and 3D flocks.
    
## Creating a flock
To begin creating flocks, here is a step-by-step on how to build a simple flock with the assets in this project:
    
    Step 1: Creating the Flock in the scene
        - Create a new empty object in the Unity scene and give it a name. This will be the entire Flock.
        - In the new flock's inspector, go to 'Add Component' and search for the 'Flock' script component.
        - In the inspector, you should see a number of customisation options.
          The most important now are the empty Agent Prefab and Behaviour fields that need to be filled.
      
    Step 2: Creating the Flock Agent prefab
        - Create another empty game object. This is going to be used as each Agent in the flock.
        - In the inspector Add a 'Circle Collider 2D' to the Agent.
        - In the inspector Add the 'Flock Agent' script component.
        - Attach something visual to the Agent so it can be seen.
        - Drag the new Agent to your Prefabs folder and remove it from the scene.
          The Flock will create many of these when the simulation is run.
        - Lastly, drag the Agent prefab into the empty slot in the Flock inspector.
      
    Step 3: Creating the Flock Behaviour
        - In the 'Behaviour Objects' folder, in the right-click menu -> Create -> Flock -> Behaviour -> <2D/3D> -> Composite.
          This behaviour combines the other basic behaviours into a single, coherent move.
        - Repeat the previous part with a Cohesion, Alignment, and Avoidance behaviours.
        - Next is to add a filter to the basic behaviours. In the 'Filter Objects' folder,
          follow the first part except instead of Behaviour go to Filter in the right-click menu.
          Then create a 'Same Flock' filter so the flock agents can see other members of their flock.
        - Drag the filter into the empty slot in the basic behaviours.
          The basic behaviours are now ready to put into the Composite. 
        - In the Composite's inspector select 'Add Behaviour' and drag the basic behaviour
          objects into the created slots and give them a weight value.
        - It is recommended to add a 'Stay in Radius' behaviour to the composite to keep the agents on screen.
        - Add the Composite behaviour into the Behaviour slot in the Flock.
      
    Step 4: Running the simulation
        - Enable Random Spawn
        - Run the simulation and the flock should spawn the selected number of agents
          randomly around the centre point of the flock and begin flocking.
  
## Creating a custom behaviour & filters
If you desire to make a custom behaviour:

    - Create a new script in the 'Behaviour Scripts' folder.
    - Give your new behaviour a name.
    - Inherit from the FilteredFlockBehaviour abstract class and override the 'CalculateMove'
      method and implement your calculations.
    - The abstract class is located in the Scripts > AbstractFilteredFlockBehaviours folder for
      details on the required arguments to pass and values to return.
    - In brief the method returns a Vector telling the flock agent where to turn towards.
    - Once you have a new behaviour that returns a Vector, add [CreateAssetMenu(menuName = "pathName/BehaviourName")]
      so that the behaviour object can be easily created.
    - Next is to create the new behaviour object, add it to the composite behaviour, and give it a weight.
    
Making a new filter type is similar to the above, there is an abstract Filter class to inherit from to make the process smoother.

## Known Issues
- _Error loading custom layout -> Select 'quit' and re-launch:_ Sometimes on loading the project with Unity Hub an error message will appear stating "Error Loading Custom Layout". This seems to be an issue with Unity itself but I found selecting the 'quit' option in that dialogue box, then re-launching Unity worked.
- _Some Flock agents still fly through obstacles when they have the behaviour attached -> Increaese the behaviour's weight:_ This unfortunately won't 100% fix the problem, but it should help. The problem is with all the signals from other behaviours being received, sometimes the urge for the agent to cohere or align with its flockmates overcomes the signal from the obstacle avoidance behaviour in the current implementation.
- _3D FLock orbits consrtaint radius -> Increase size of constraint radius:_ This problem is believed to be caused by the 3D agents having a 360 degree field of view. The agents bump into the constraint barrier, then continue to align with their flockmates behind them, causing them to repeatedly hit the constraint barrier.
