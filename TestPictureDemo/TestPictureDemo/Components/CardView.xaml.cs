using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPictureDemo.Database.SQLiteSettings.DbEntities;
using TestPictureDemo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestPictureDemo.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardView : StackLayout
    {
        public static readonly BindableProperty CardSourceProperty =
            BindableProperty.Create(
                propertyName: "CardSource",
                returnType: typeof(IEnumerable<PrincipalPost>),
                declaringType: typeof(IEnumerable<PrincipalPost>),
                defaultValue: default(IEnumerable<PrincipalPost>),
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: OnPropertyChanged);

        public IEnumerable<PrincipalPost> CardSource
        {
            get => (IEnumerable<PrincipalPost>)GetValue(CardSourceProperty);
            set => SetValue(CardSourceProperty, value);
        }


        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CardView control)
            {
                var gifts = newValue as IEnumerable<PrincipalPost>;

                control.cardContainer.ItemsSource = gifts;
            }
        }
        public CardView()
        {
            InitializeComponent();
        }
    }
}