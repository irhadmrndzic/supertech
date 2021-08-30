using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace superTechMobile.Helper
{
    public class EntryLengthValidator : Behavior<Entry>
    {
        public int MaxLength { get; set; } = 5;
        public int MinLength { get; set; } = 5;

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            // if Entry text is longer than valid length  
            if (entry.Text.Length > this.MaxLength)
            {
                string entryText = entry.Text;

                entryText = entryText.Remove(entryText.Length - 2); // remove last char  

                entry.Text = entryText;
            }

            if (MinLength > 0)
                if (entry.Text.Length < this.MinLength)
                {
                    ((Entry)sender).TextColor = Color.Red;
                }
                else
                    ((Entry)sender).TextColor = Color.Black;
        }
    }
}
