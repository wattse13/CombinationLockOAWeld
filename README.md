# Eli Watts
# 12/16/2021
# Independent Study Write Up

## Some Context:

Last summer I created a prototype for the College Simulator project. The prototype is playable and does a reasonable job of communicating how the College Simulator plans on implementing mini-games for its in-game academic lessons. However, the codebase is a mile long tangle of spaghetti code which is not maintainable, extensible, or even in many cases functional. 
After completing the prototype, I was happy that I had successfully created something that at least worked some of the time and that it was something which could be used for demonstrating the College Simulator’s goals. There were many things however, that I was not satisfied with and my plan this semester was to make a better and more generic version of the prototype which could ideally be used for multiple different mini games within the College Simulator project. While I did make some progress towards that goal, the process has been surprisingly challenging.


## My Initial Plans:

Above everything else, I wanted to avoid the chaotic and non-generic coding approach that I used when creating the first prototype. My hope was that design patterns would help me achieve this goal. I spent some time researching different design patterns and eventually decided on trying to use a state machine for my planned mini game template. 

I decided on the state machine for a couple of reasons. First, the prototype I made has a collection of interactable objects each of which can exist in a different state – off unsafe, off safe, on unsafe, on safe – and the consequences for interacting with these objects varied by their current state. In this case, a state machine seemed like a logical way for organizing specific behavior based on each individual object’s current state. 

Second, I thought the state machine would allow for easier extensibility. The original prototype I made is devoid of animations, sound, or really anything dynamic. Again, the state machine seemed like a good base from which these kinds of behaviors could be added and modified on an object by object and state by state level. 

Third, I found the idea of implementing some restrictions on how I approached the project appealing. Restrictions often help me focus as it reduces possibilities, and the paralysis of too many choices, and they often help me focus more on using, and re-using, a single structure rather than trying to create, and re-create, multiple structures. 

Along with the state machine, I wanted to use Unity’s new-ish Addressables system. I stumbled upon this system when trying to understand how to properly use Unity’s Resource folder. According to the research I did on the Resource folder, it seemed like the Addressables system was a new system meant to replace the Resource folder which, according to many forum posts, was often misused and a detriment to game performance. My plan to was for each state in the state machine to store different paths to different Addressable data folders. By changing the interactable object’s state, the state machine would also use a new path to find and retrieve new assets stored in a new folder and thus change the interactable object’s appearance or description. 

If any of this feels as though I was putting the cart before the horse, that is because I was, and once I actually started trying to implement any of this, things fell apart rather quickly. More on that in a future segment!


## The Addressables System Falls Apart:

After consuming the few available resources on the Addressable system, I began trying to implement it into my new project. Downloading the package from the Unity registry went easily enough and setting up some of the basics, like giving objects an address, also seemed like no problem. However, when it actually came time to retrieve the data I had stored, nothing worked. As of writing this, I am still unsure if I mistyped the path names, if I misused one of the necessary function calls, or if I forgot to properly set up the Addressable system in my project. I spent many hours rewatching and rereading the few tutorials available before finally giving up and returning to the Resource folder, of which the base game already made heavy use. 

From what I read about Addressables, it sounds like a great system. My hope is that one day when there is more documentation about how to use it and when there are more community made tutorials, I might be able to finally implement the system in one of my projects.


## The State Machine Falls Apart (sorta):

At this point, I felt largely discouraged by my failure to get the Addressable system working in even a simple test environment. To comfort myself, I told myself that my original idea with the state machine could still work even if I ended up using the less optimal, though more familiar, Resources folder. Thankfully, there are plenty of resources on how to implement a state machine and setting up the framework went smoothly. 

I started by creating an `Abstract Base State Class` from which all states would derive. This abstract class started with three functions which I thought all states would share -- `EnterState`, `UpdateState`, and `UpdateLists`. `EnterState` would be used to initialize any starting behaviors an object might display upon changing state. `UpdateState` would be used when a player interacted with an object and the object needed to then decide if that action would result in a state change. `UpdateList` would be used to update a data storage scripts which would theoretically hold on to data related to which states each object was in. 

To manage all the scripts which derived from the `Abstract Base Class` I created an `ObjectStateManager`. This script contains a reference to the `Abstract Base Class` which means any object deriving from the abstract class can fill the reference. It also contains a reference to all of the scripts which I made deriving from the abstract class. A variable `currentState` holds a reference to whichever state an object is currently in. On `Start` the `ObjectStateManager` first sets the object state, and then calls the `EnterState()` method using dot notaion `currentState.EnterState(this)`. It also passes in a reference to itself, this, to satisfy the `EnterState(ObjectStateManager interactable)` parameter. The `ObjectStateManager` also has a function `SwitchState(ObjectBaseState state)` which switches an object’s state based on whatever state parameter is passed to it.

After deriving a few states from the `Abstract Base Class` I was able to set up a test which changed a test object’s state after specific buttons were pressed on the keyboard. While I was very happy to get the state machine working, at least in theory, the title of this section is “The State Machine Falls Apart (sorta)” which implies that something went wrong. 
And it did, sorta. 

With my tests working, I began to add additional functionality which I thought would be necessary for a point-and-click mini game template. This included things like tool tips, modal windows, and other context menus. As I worked on other parts of the template, I began to get the sinking feeling that I’d lost track of the ‘scope’ for the mini games I was working on. Yes, the state machine did change an object’s behavior based on its state, but if that behavior change was a simple change in a text-description, wouldn’t a `list` or `dictionary` work just as well and be simpler? I spoke some more with one of my colleagues on the project, David, and eventually resigned myself to the conclusion that an entire 
state machine for simple five-minute point-and-click games was probably a good bit of over engineering.

At the moment, the state machine is not being used. While I did learn a lot while trying to implement it – I got to write my first abstract class! – learning is only half of the reason that I am working on the College Simulator project and balancing the needs for a minimally viable product with good coding architecture is a lesson I have been continually trying to learn this entire semester. 


## Scriptable Object Event Misadventures:

Having spent, and ultimately ‘wasted’, a lot of time trying to get the state machine working was frustrating. At this point, I was also getting worried that I would not be able to meet some self-imposed deadlines for when I wanted to have the point-and-click template finished. Unfortunately, though maybe predictably, rather than sit down and write some basic code, which could be edited later, I again tried to find a system/pattern which I thought would solve all my problems.

This time I stumbled upon an approach to making an event system which relied upon scriptable objects. This system was appealing because it seemed flexible and designer friendly which both sounded great for making future games based on a single template. 

There are two main components to the system: `GameEventSO` which is a class from which scriptable objects can be made and `GameEventListener` which is a class that holds a reference to a `Game Event Scriptable Object` and then calls functions on the `Game Event Scriptable Object` using dot notation. 

The `GameEventSO` contains a `HashSet` which holds a reference to all listeners. A `HashSet` is used to prevent a single listener from being added twice. It also contains a method `Raise()` to invoke a function call for all of its listeners, and two methods, `RegisterListener()` and `UnregisterListener()` for adding or removing listeners.

On enable, the `GameEventListener` adds itself as a listener to whichever `GameEventSO` it holds in its serialized field reference. It also removes itself as listener on disable. It also holds a serialized field for a `Unity Event`. The `Unity Event` fires when the `GameEventSO.Raise()` event triggers the `GameEventListener.OnEventRaised()` function. 

After setting up these two scripts, I was able to pass around some information about an object to other UI elements which would then display that object data. To do that successfully though, required a lot of dragging and dropping in the Unity Editor. In one iteration I came close to being able to pass an object’s data container through the `GameEventSO` `GameEventListener` chain to a UI element but could not quite figure it out. Because there was so much necessary dragging and dropping of references in the Unity Editor to get this system to work, a fair question would be “Why go through all the effort?” As of writing this, I am still unable to answer that question which is why I abandoned this system as well. 

While I may not be using this system in the College Simulator project I do think it has a lot of potential, and I hope to be able to use it in some future personal projects. Abandoning this approach is another lesson in a long list of repeated attempts on my part to understand the fact that trying to plan away bad code most likely will result in no code. 


## So What Now?:

I think, I hope, that at this point I’ve started to accept that writing good code is a process of iteration. Fancy coding architecture can be added during periods of refactoring after desired functionality has already been achieved. As such, my plans for making the point-and-click template are now much simpler than they have ever been.

Ever interactable object has a data component. This component holds a reference to a scriptable object. The scriptable object contains information about the object, like its name, description, alt name, alt description, etc. 

A single `ObjectManager` holds a `dictionary` which contains every object’s scriptable object data container. The interactable object’s name, as seen in the hierarchy, acts as the key for the scriptable object data container to which it corresponds. When any external objects want access to an interactable object’s data, it uses the interactable object name to read data from the corresponding value in the `ObjectManager` dictionary.

For UI elements, I am using a two-pronged approach; there is a component attached to the interactable object and a corresponding manager attached to the UI objects. For example, the `ToolTipComponent` is attached to an interactable object. It has a reference to both the `ObjectManager` and the `ToolTipManager`. When it registers that the mouse is hovering over the interactable object calls an `ObjectManager` function using dot notation `myObjectManager.RequestData(gameObject.name);` and passes in the interactable object name as an argument. The value which that function returns is then used as an argument in a function call it makes on the `ToolTipManager` using dot notation, `myToolTipManager.DisplayText(returnedData);`. The menu which opens after clicking on an object works in a similar way, but with click events rather than hover events.

There are probably plenty of ways to improve this system. I am trying my hardest to ignore them at the moment. Sure, I am avoiding some obviously bad coding practices, like using lots of `GameObject.Find()` calls, but in the most part I am trying to write code that works so I can make it better later. Having detailed everything that led me to this point, it seems absurd that it took me this long to get to the simpler approach I am now taking. While I am hoping that maybe some of the other approaches I tried to implement will at some point be useful in the College Simulator project, I am happy that I got the opportunity to try them and will hopefully make use of them in another project someday in the future. 


## Other Things I Learned About Game Design:

Communication! Throughout this project it was necessary to speak with other colleagues to plan and coordinate our efforts. I helped facilitate this by creating documents on topics like accessibility or general game design goals. Doing so helped me, and I hope other colleagues as well, start to form a shared idea of the game we were all working towards. Communication also meant learning how to ask my other colleagues, like David, for help when I was struggling with coding issues or informing Tricia about my struggles to meet certain deadlines which we had previously agreed upon.

Feature Creep/Changing Goals! Over the semester the mini games I have been developing have changed from welding, to water conservation, to freshmen seminar. Even with lots of communication the needs of a project are constantly changing and evolving. 

Work/Life Balance! Three jobs are too many jobs. Studying on top of the three jobs is a whole other nightmare. I don’t want to make excuses for my lack of progress over the semester, but I definitely underestimated just how much time I was going to need to get everything done that I wanted/needed to in day-to-day life. Thankfully next semester I can make some changes, like taking fewer classes and cutting my work hours in half, so that I have more time to focus on the College Simulator project.


## Outro:

Being part of an actual development team has made me aware of game development problems I never would have known about had I not started working on this project. While I may not have accomplished everything that I wanted to this semester, I learned much more than I could have imagined about coding, game design, and how to work in a team of developers. I hope that my contributions to the project will be useful as I am excited about the idea of continuing to work on the project for the foreseeable future. Again, thank you Professor Cassens, for originally offering me this opportunity! 
