using AirFishLab.ScrollingList;
using UnityEngine;
using UnityEngine.UI;

// The box used for displaying the content
// Must be inherited from the class ListBox
public class IntListBox : ListBox
{
    [SerializeField]
    private Image _contentImage;

    //[SerializeField]
    //private Text _contentText;

    private bool doOnce = true;

    // This function is invoked by the `CircularScrollingList` for updating the list content.
    // The type of the content will be converted to `object` in the `IntListBank` (Defined later)
    // So it should be converted back to its own type for being used.
    // The original type of the content is `int`.
    protected override void UpdateDisplayContent(object content)
    {
        var data = (DataWrapper)content;
        _contentImage = (Image)data.value;
        
        // only add the image as a child object once to ensure no memory overflow
        if (doOnce)
        {
            Instantiate(_contentImage, gameObject.transform);
            doOnce = false;
        }
        
        //_contentImage = ((Image)content);
        // _contentText.text = ((int)content).ToString();
    }
}