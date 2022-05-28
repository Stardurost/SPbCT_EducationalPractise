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

namespace Example.UserControls
{
    /// <summary>
    /// Interaction logic for ScheduleAppointment.xaml
    /// </summary>
    public partial class ScheduleAppointmentControl : UserControl
    {
        public ScheduleAppointmentControl()
        {
            InitializeComponent();
        }

        private void Button_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is Entites.ScheduleAppointment currentAppointment)
            {
                BtmAppointment.Content = $"{currentAppointment.StartTime.ToString(@"hh\:mm")}  "+
                    $"-  {currentAppointment.EndTime.ToString(@"hh\:mm")}";


                switch (currentAppointment.AppointmentType)
                {
                    case Entites.AppointmentType.Busy:
                        {   BtmAppointment.IsEnabled = false;
                            BtmAppointment.Foreground = new SolidColorBrush(Colors.Gray);
                            BtmAppointment.Visibility = Visibility.Visible;
                        }
                        break;
                    case Entites.AppointmentType.DayOff:
                        {
                            BtmAppointment.IsEnabled = false;
                            BtmAppointment.Visibility = Visibility.Hidden;
                        }
                        break;
                    case Entites.AppointmentType.Free:
                        { BtmAppointment.IsEnabled = true;
                            BtmAppointment.Visibility = Visibility.Visible;
                        }
                        break;
                }
            
            }
        }
    }
}
