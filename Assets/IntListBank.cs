using AirFishLab.ScrollingList;
using UnityEngine;
using UnityEngine.UI;

// The bank for providing the content for the box to display
// Must be inherit from the class BaseListBank
public class IntListBank : BaseListBank
{
    [SerializeField]
    private Image[] _contents;

    // Create a data wrapper for carrying the data
    private DataWrapper _dataWrapper = new DataWrapper();

    // This function will be invoked by the `CircularScrollingList`
    // when acquiring the content to display
    // The object returned will be converted to the type `object`
    // which will be converted back to its own type in `IntListBox.UpdateDisplayContent()`
    public override object GetListContent(int index)
    {
        _dataWrapper.value = _contents[index];
        return _dataWrapper;
        //return _contents[index];
    }

    public override int GetListLength()
    {
        return _contents.Length;
    }
}

public class DataWrapper
{
    public Image value;
}