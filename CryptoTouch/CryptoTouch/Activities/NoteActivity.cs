using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Transitions;

namespace CryptoTouch.Activities
{
    [Activity(Label = "NoteActivity", WindowSoftInputMode = SoftInput.StateVisible)]
    public class NoteActivity : Activity
    {
        private EditText _editText;
        private Button _saveButton;
        private Note _originalNote;
        private bool _isNewNote;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.ActivityTransitions);
            Window.RequestFeature(WindowFeatures.ContentTransitions);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NotePage);
        }

        private void UpdateNotes()
        {
            if (_isNewNote)
                NoteStorage.Notes.Add(new Note("note text here"));
            else
                NoteStorage.Notes.Find(note => note == _originalNote).Text = "new note text here";
            SecurityProvider.SaveNotes();
        }
    }
}