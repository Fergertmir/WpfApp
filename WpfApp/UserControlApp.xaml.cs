using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.MyControls
{
    /// <summary>
    /// Interaction logic for UserControlApp.xaml
    /// </summary>

    public partial class Group
    {
        public int Id { get; set; }
        public List<int> Items { get; set; }
        public string Procedure { get; set; } 
    }
    public partial class UserControlApp : UserControl
    {
        public static DependencyProperty TeethSelectedProperty;
        public static DependencyProperty FocuseNowProperty;
        public static DependencyProperty LastElementSelectedProperty;
        public static DependencyProperty GroupsProperty;

        public static RoutedCommand MyCommand { get; set; }
        public UserControlApp()
        {
            InitializeComponent();
            // Создание привязки
            CommandBinding bind = new CommandBinding(ApplicationCommands.New);

            // Присоединение обработчика событий
            bind.Executed += NewCommand_Executed;

            // Регистрация привязки
            this.CommandBindings.Add(bind);
            MyCommand = new RoutedCommand("NewCommand", typeof(UserControlApp));
        }

        static UserControlApp()
        {
            GroupsProperty = DependencyProperty.Register(
                    "Groups",
                    typeof(List<Group>),
                    typeof(UserControlApp),

                    new FrameworkPropertyMetadata(
                        new List<Group>(), new PropertyChangedCallback(GroupsChanged)));

            LastElementSelectedProperty = DependencyProperty.Register(
                    "LastElementSelected",
                    typeof(int),
                    typeof(UserControlApp),
                    new FrameworkPropertyMetadata(
                        0, new PropertyChangedCallback(LastElementSelectedChanged)));

            FocuseNowProperty = DependencyProperty.Register(
                    "FocuseNow",
                    typeof(int),
                    typeof(UserControlApp),
                    new FrameworkPropertyMetadata(
                        0, new PropertyChangedCallback(FocuseChanged)));

            TeethSelectedProperty = DependencyProperty.Register(
                    "TeethSelected",
                    typeof(bool[]),
                    typeof(UserControlApp),
                    new FrameworkPropertyMetadata(
                        new bool[32] { false, false, false, false, false, false, false, false, 
                            false, false, false, false, false, false, false, false, false, false, 
                            false, false, false, false, false, false, false, false, false, false, 
                            false, false, false, false}, FrameworkPropertyMetadataOptions.AffectsMeasure |
                        FrameworkPropertyMetadataOptions.AffectsRender,
                        new PropertyChangedCallback(OnTeethSelectedChanged)));
            
        }

        public bool[] TeethSelected
        {
            get { return (bool[])GetValue(TeethSelectedProperty); }
            set { SetValue(TeethSelectedProperty, value); }
        }

        public int FocuseNow
        {
            get { return (int)GetValue(FocuseNowProperty); }
            set { SetValue(FocuseNowProperty, value); }
        }

        public int LastElementSelected
        {
            get { return (int)GetValue(LastElementSelectedProperty); }
            set { SetValue(LastElementSelectedProperty, value); }
        }

        public List<Group> Groups
        {
            get { return (List<Group>)GetValue(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }

        // Метод, вызываемый при изменении значения свойства TeethSelectedProperty (но это bool[] а значит он не может отследить изменения)
        private static void OnTeethSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // ...
        }

        // Метод, вызываемый при изменении значения свойства FocuseNowProperty
        private static void FocuseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // ...
        }

        // Метод, вызываемый при изменении значения свойства LastElementSelectedProrerty
        private static void LastElementSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // ...
        }

        // Метод, вызываемый при изменении значения свойства GroupsChanged
        private static void GroupsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // ...
        }

        private void ChBox_Checked(object sender, RoutedEventArgs e)
        {
            TeethValueChanged((sender as CheckBox).IsChecked ?? false, 
                Convert.ToInt32((sender as CheckBox).Name.Remove(0, 5)));
            
        }

        private void TeethValueChanged(bool IsChacked, int ChBoxId )
        {
            bool[] TeethSelect = TeethSelected;
            TeethSelect[ChBoxId - 1] = IsChacked;
            TeethSelected = TeethSelect;

            if (IsChacked == true)
            {
                LastElementSelected = ChBoxId;
            }
            else if (LastElementSelected == ChBoxId)
            {
                for (int i = 0; i <= TeethSelect.Length - 1; i++)
                {
                    if (TeethSelect[i] == true)
                    {
                        LastElementSelected = (i + 1);
                        return;
                    }
                }
                LastElementSelected = 0;
            }
        }

        private void ChBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TeethValueChanged((sender as CheckBox).IsChecked ?? false,
                Convert.ToInt32((sender as CheckBox).Name.Remove(0, 5)));
        }

        private void ChBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FocuseNowChanged(Convert.ToInt32((sender as CheckBox).Name.Remove(0, 5)));
            HighlightTwinTooth(FocuseNow, Brushes.Coral);
        }

        private void FocuseNowChanged(int ChBoxId)
        {
            FocuseNow = ChBoxId;
        }
        private void HighlightTwinTooth(int ChBoxId, SolidColorBrush Focuse)
        {
            switch (ChBoxId)
            {
                case 1:
                    ChBox32.Background = Focuse;
                    break;
                case 2:
                    ChBox31.Background = Focuse;
                    break;
                case 3:
                    ChBox30.Background = Focuse;
                    break;
                case 4:
                    ChBox29.Background = Focuse;
                    break;
                case 5:
                    ChBox28.Background = Focuse;
                    break;
                case 6:
                    ChBox27.Background = Focuse;
                    break;
                case 7:
                    ChBox26.Background = Focuse;
                    break;
                case 8:
                    ChBox25.Background = Focuse;
                    break;
                case 9:
                    ChBox24.Background = Focuse;
                    break;
                case 10:
                    ChBox23.Background = Focuse;
                    break;
                case 11:
                    ChBox22.Background = Focuse;
                    break;
                case 12:
                    ChBox21.Background = Focuse;
                    break;
                case 13:
                    ChBox20.Background = Focuse;
                    break;
                case 14:
                    ChBox19.Background = Focuse;
                    break;
                case 15:
                    ChBox18.Background = Focuse;
                    break;
                case 16:
                    ChBox17.Background = Focuse;
                    break;
                case 17:
                    ChBox16.Background = Focuse;
                    break;
                case 18:
                    ChBox15.Background = Focuse;
                    break;
                case 19:
                    ChBox14.Background = Focuse;
                    break;
                case 20:
                    ChBox13.Background = Focuse;
                    break;
                case 21:
                    ChBox12.Background = Focuse;
                    break;
                case 22:
                    ChBox11.Background = Focuse;
                    break;
                case 23:
                    ChBox10.Background = Focuse;
                    break;
                case 24:
                    ChBox9.Background = Focuse;
                    break;
                case 25:
                    ChBox8.Background = Focuse;
                    break;
                case 26:
                    ChBox7.Background = Focuse;
                    break;
                case 27:
                    ChBox6.Background = Focuse;
                    break;
                case 28:
                    ChBox5.Background = Focuse;
                    break;
                case 29:
                    ChBox4.Background = Focuse;
                    break;
                case 30:
                    ChBox3.Background = Focuse;
                    break;
                case 31:
                    ChBox2.Background = Focuse;
                    break;
                case 32:
                    ChBox1.Background = Focuse;
                    break;
                default:
                    break;
            }
        }

        private void ChBox_LostFocus(object sender, RoutedEventArgs e)
        {
            HighlightTwinTooth(FocuseNow, Brushes.Gray);
            FocuseNowChanged(Convert.ToInt32((sender as CheckBox).Name.Remove(0, 5)));
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            bool[] TeethSelect = TeethSelected;
            int CurrentElement = Convert.ToInt32((e.OriginalSource as CheckBox).Name.Remove(0, 5));
            if (LastElementSelected != 0)
            {
                if (CurrentElement > LastElementSelected)
                {
                    for (int i = 0; i <= TeethSelect.Length - 1; i++)
                    {
                        if (LastElementSelected > i + 1 || CurrentElement < i + 1)
                        {
                            TeethValueChanged(false, i + 1);
                            ChangeChecke(i + 1, false);
                        }
                        else
                        {
                            if (TeethSelect[i] == false)
                            {
                                TeethValueChanged(true, i + 1);
                                ChangeChecke(i + 1, true);
                            }
                        }
                    }
                }
                else if (CurrentElement < LastElementSelected)
                {
                    for (int i = 0; i <= TeethSelect.Length - 1; i++)
                    {
                        if (LastElementSelected > i + 1 || CurrentElement > i + 1)
                        {
                            TeethValueChanged(false, i + 1);
                            ChangeChecke(i + 1, false);
                        }
                        else
                        {
                            if (TeethSelect[i] == false)
                            {
                                TeethValueChanged(true, i + 1);
                                ChangeChecke(i + 1, true);
                            }
                        }
                        if (TeethSelect[i] == false)
                            LastElementSelected = i + 1;
                    }
                }
            }
            else
            {
                TeethValueChanged(!TeethSelect[CurrentElement - 1], CurrentElement);
            }
                
            
        }

        private void ChangeChecke(int ChBoxId, bool Check)
        {
            switch (ChBoxId)
            {
                case 1:
                    ChBox1.IsChecked = Check;
                    break;
                case 2:
                    ChBox2.IsChecked = Check;
                    break;
                case 3:
                    ChBox3.IsChecked = Check;
                    break;
                case 4:
                    ChBox4.IsChecked = Check;
                    break;
                case 5:
                    ChBox5.IsChecked = Check;
                    break;
                case 6:
                    ChBox6.IsChecked = Check;
                    break;
                case 7:
                    ChBox7.IsChecked = Check;
                    break;
                case 8:
                    ChBox8.IsChecked = Check;
                    break;
                case 9:
                    ChBox9.IsChecked = Check;
                    break;
                case 10:
                    ChBox10.IsChecked = Check;
                    break;
                case 11:
                    ChBox11.IsChecked = Check;
                    break;
                case 12:
                    ChBox12.IsChecked = Check;
                    break;
                case 13:
                    ChBox13.IsChecked = Check;
                    break;
                case 14:
                    ChBox14.IsChecked = Check;
                    break;
                case 15:
                    ChBox15.IsChecked = Check;
                    break;
                case 16:
                    ChBox16.IsChecked = Check;
                    break;
                case 17:
                    ChBox17.IsChecked = Check;
                    break;
                case 18:
                    ChBox18.IsChecked = Check;
                    break;
                case 19:
                    ChBox19.IsChecked = Check;
                    break;
                case 20:
                    ChBox20.IsChecked = Check;
                    break;
                case 21:
                    ChBox21.IsChecked = Check;
                    break;
                case 22:
                    ChBox22.IsChecked = Check;
                    break;
                case 23:
                    ChBox23.IsChecked = Check;
                    break;
                case 24:
                    ChBox24.IsChecked = Check;
                    break;
                case 25:
                    ChBox25.IsChecked = Check;
                    break;
                case 26:
                    ChBox26.IsChecked = Check;
                    break;
                case 27:
                    ChBox27.IsChecked = Check;
                    break;
                case 28:
                    ChBox28.IsChecked = Check;
                    break;
                case 29:
                    ChBox29.IsChecked = Check;
                    break;
                case 30:
                    ChBox30.IsChecked = Check;
                    break;
                case 31:
                    ChBox31.IsChecked = Check;
                    break;
                case 32:
                    ChBox32.IsChecked = Check;
                    break;
                default:
                    break;
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (ComBox2.SelectedItem != null && ComBox3.SelectedItem !=null && LastElementSelected != 0)
            {
                bool[] TeethSelect = TeethSelected;
                Group NewGroup = new Group();
                int Id = Convert.ToInt32(ComBox2.SelectedItem);
                List<Group> AllGroup = Groups;
                foreach(Group Item in AllGroup)
                {
                    if (Item.Id == Id)
                    {
                        NewGroup = Item;
                    }
                }

                int Index = AllGroup.IndexOf(NewGroup);

                NewGroup.Items.RemoveRange(0, NewGroup.Items.Count);
                NewGroup.Procedure = ComBox3.Text;

                for (int i = 0; i <= TeethSelect.Length - 1; i++)
                {
                    if (TeethSelect[i] == true)
                    {
                        NewGroup.Items.Add(i + 1);
                        TeethValueChanged(false, i + 1);
                        ChangeChecke(i + 1, false);
                    }
                }
                AllGroup[Index] = NewGroup;
                ComBox2.SelectedIndex = -1;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ComBox2.SelectedItem != null)
            {
                int Id = Convert.ToInt32(ComBox2.SelectedItem);
                foreach (Group Item in Groups)
                {
                    if (Item.Id == Id)
                    {
                        foreach (int i in Item.Items)
                        {
                            TeethValueChanged(false, i);
                            ChangeChecke(i, false);
                        }
                        Groups.Remove(Item);
                        ComBox2.Items.Remove(Id);
                        break;
                    }
                }
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (ComBox1.HasItems == true && ComBox1.SelectedItem != null && LastElementSelected != 0)
            {
                bool[] TeethSelect = TeethSelected;
                Group NewGroup = new Group();
                NewGroup.Items = new List<int>();
                List<Group> AllGroup = Groups;
                if (AllGroup != null)
                {
                    if (AllGroup.Count == 0)
                    {
                        NewGroup.Id = 1;
                    }
                    else
                    {
                        NewGroup.Id = AllGroup.LastOrDefault().Id + 1;
                    }

                    NewGroup.Procedure = ComBox1.Text;

                    for (int i = 0; i <= TeethSelect.Length - 1; i++)
                    {
                        if (TeethSelect[i] == true)
                        {
                            NewGroup.Items.Add(i + 1);
                            TeethValueChanged(false, i + 1);
                            ChangeChecke(i + 1, false);
                        }
                    }
                    AllGroup.Add(NewGroup);
                    ComBox2.Items.Add(NewGroup.Id);
                }
                
                
            }
            else
            {
                MessageBox.Show("Please, select the type of procedure and teeth.");
            }
        }

        private void ComBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComBox2.HasItems == true && ComBox2.SelectedItem != null)
            {

                int Id = Convert.ToInt32(e.AddedItems[0].ToString());
                bool[] TeethSelect = TeethSelected;
                Group ThisGroup = new Group();

                foreach (Group Item in Groups)
                {
                    if (Item.Id == Id)
                    {
                        ThisGroup = Item;
                        break;
                    }
                }

                for (int i = 0; i <= TeethSelect.Length - 1; i++)
                {
                    if (TeethSelect[i] == true)
                    {
                        TeethValueChanged(false, i + 1);
                        ChangeChecke(i + 1, false);
                    }
                }

                foreach(int Item in ThisGroup.Items)
                {
                    TeethValueChanged(true, Item);
                    ChangeChecke(Item, true);
                }

                if (ComBox3.HasItems == true)
                {
                    ComBox3.Text = ThisGroup.Procedure;
                }
            }
            
        }
    }
}
