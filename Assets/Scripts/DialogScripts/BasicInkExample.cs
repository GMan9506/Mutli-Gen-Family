using UnityEngine;
using UnityEngine.UI;
using System;
using Ink.Runtime;
using UnityEngine.SceneManagement;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class BasicInkExample : MonoBehaviour {

    public  TextAsset initialStory = null;

    public  TextAsset firstStory = null;

    public  TextAsset secondStory = null;

    public  TextAsset thirdStory = null;

    public  TextAsset endStory = null;

    public  Story story;

    public  Canvas canvas = null;

    // UI Prefabs
    public  Text textPrefab = null;

    public  Button buttonPrefab = null;

    public enum STATE
    {
        INITIAL,
        FIRST,
        SECOND,
        THIRD,
        END
    }

    public static event Action<Story> OnCreateStory;

    // Variable that represents that it is suppose to start story
    public bool isStarted = false;

    // Variable that represents the part of the story we are in
    public static STATE state = STATE.INITIAL;


    void Awake () {
		// Remove the default message
		RemoveChildren();

        //Set the story based on which scene is loaded.
        
        state = ( SceneManager.GetSceneByName("topdowntest").IsValid() ) ? STATE.FIRST : state;
        state = ( SceneManager.GetSceneByName("TableSetUp").IsValid() ) ? STATE.SECOND : state;
        state = ( SceneManager.GetSceneByName("testMinigame").IsValid() ) ? STATE.THIRD : state;
        state = ( SceneManager.GetSceneByName("testMinigame").IsValid() ) ? STATE.END : state;

        StartStory();
	}

	// Creates a new Story object with the compiled story which we can then play!
	public void StartStory () {
        //Specify which story to start
        switch (state)
        {
            case STATE.INITIAL:
                story = new Story(initialStory.text);
                break;
            case STATE.FIRST:
                story = new Story(firstStory.text);
                break;
            case STATE.SECOND:
                story = new Story(secondStory.text);
                break;
            case STATE.THIRD:
                story = new Story(thirdStory.text);
                break;
            case STATE.END:
                story = new Story(endStory.text);
                break;
            default:
                break;
        }

		// story = new Story (inkJSONAsset.text);
        if(OnCreateStory != null) OnCreateStory(story);
		RefreshView();
	}
	
	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	void RefreshView () {
		// Remove all the UI on screen
		RemoveChildren ();
		
		// Read all the content until we can't continue any more
		while (story.canContinue) {
			// Continue gets the next line of the story
			string text = story.Continue ();
			// This removes any white space from the text.
			text = text.Trim();
			// Display the text on screen!
			CreateContentView(text);
		}

		// Display all the choices, if there are any!
		if(story.currentChoices.Count > 0) {
			for (int i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim ());
				// Tell the button what to do when we press it
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
			}
		}
		// If we've read all the content and there's no choices, the story is finished!
		else {
			Button choice = CreateChoiceView("End of story.\nRestart?");
			choice.onClick.AddListener(delegate{
                //StartStory();
                UnloadDialogManager();
			});
		}

        Canvas.ForceUpdateCanvases();

	}

    void UnloadDialogManager()
    {
        SceneManager.UnloadSceneAsync("DialogManager");
    }

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

	// Creates a textbox showing the the line of text
	void CreateContentView (string text) {
		Text storyText = Instantiate (textPrefab) as Text;
		storyText.text = text;
		storyText.transform.SetParent (canvas.transform, false);
	}

	// Creates a button showing the choice text
	Button CreateChoiceView (string text) {
		// Creates the button from a prefab
		Button choice = Instantiate (buttonPrefab) as Button;
		choice.transform.SetParent (canvas.transform, false);
		
		// Gets the text from the button prefab
		Text choiceText = choice.GetComponentInChildren<Text> ();
		choiceText.text = text;

		// Make the button expand to fit the text
		HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
		layoutGroup.childForceExpandHeight = false;

		return choice;
	}

	// Destroys all the children of this gameobject (all the UI)
	void RemoveChildren () {
		int childCount = canvas.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			GameObject.Destroy (canvas.transform.GetChild (i).gameObject);
		}
	}

}
