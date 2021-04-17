# OpenFlock_2

## Installing:

To install the assets, pull them into your Unity project's Assets folder. The Open_Flock folder will contain behaviour and filter scripts, and example scenes and objects for both 2D and 3D flocks.
    
## Creating a flock:
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
  
## Creating a custom behaviour & filters:
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
