using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyWorld.Behaviours
{
  public  class MinLengthValidatorBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty MinLengthProperty = BindableProperty.Create("MinLength", typeof(int), typeof(MaxLengthValidatorBehavior), 0);


        public int MinLength
        {
            get { return (int)GetValue(MinLengthProperty); }
            set { SetValue(MinLengthProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }

        private void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length < MinLength)
                ((Entry)sender).TextColor = Color.Red;
            else
                ((Entry)sender).TextColor = Color.Green;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;

        }
    }
}
