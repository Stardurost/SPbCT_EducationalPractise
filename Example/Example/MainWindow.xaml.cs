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

namespace Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboSpecialisation.ItemsSource = App.DataBase.Specializations.ToList();
            ComboSpecialisation.SelectedIndex = 0;

            ComboDoctor.ItemsSource = App.DataBase.Doctors.ToList();
            ComboDoctor.SelectedIndex = 0;

        }

        private void ComboSpecialisation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedSpecialization = ComboSpecialisation.SelectedItem as Entites.Specialization;
            if (SelectedSpecialization != null)
            {
                var doctors = App.DataBase.Doctors.ToList()
                .Where(p => p.Specialization == SelectedSpecialization);
                ComboDoctor.ItemsSource = doctors;
                ComboDoctor.SelectedIndex = 0;
            }
        }

        private void ComboDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedDoctor = ComboDoctor.SelectedItem as Entites.Doctor;
            if (SelectedDoctor != null)
            {
                GenerateSchedule(SelectedDoctor);
            }
        }


        private void GenerateSchedule(Entites.Doctor SelectedDoctor)
        { 
            var StartDate = DateTime.Now.Date;
            var EndDate = StartDate.AddDays(5);

            var ScheduleGenerator = new Utils.ScheduleGenerator(StartDate, EndDate, 
                 SelectedDoctor.DoctorSchedules.ToList());

            var headers = ScheduleGenerator.GenerateHeaders();

            var appointment = ScheduleGenerator.GenerateAppointments(headers);
           
            LoadSchedule(headers, appointment);


        }

        private void LoadSchedule(List<Entites.ScheduleHeader> headers, 
            List<List<Entites.ScheduleAppointment>> appointment)
        {
            DGridSchedule.Columns.Clear();
            for (int i = 0; i < headers.Count(); i++)
            {
                // Фабрика для настройки заголовков
                FrameworkElementFactory headerFactory = 
                    new FrameworkElementFactory(typeof(UserControls.ScheduleHeaderControl));
                headerFactory.SetValue(DataContextProperty, headers[i]);

                // Шаблон заголовка
                var headerTemplate = new DataTemplate
                {
                    VisualTree = headerFactory

                };

                FrameworkElementFactory cellFactory =
                    new FrameworkElementFactory(typeof(UserControls.ScheduleAppointmentControl));
               // Привязка текущего столбца к индексу списка значений
                cellFactory.SetBinding(DataContextProperty, new Binding($"[{i}]"));
                // обработка событий
                cellFactory.AddHandler(MouseDownEvent,
                    new MouseButtonEventHandler(BtnAppointment_MouseDown), true);

                // шаблон ячейки
                var cellTemplate = new DataTemplate
                {
                    VisualTree = cellFactory
                };

                var ColumnTemplate = new DataGridTemplateColumn
                {
                    HeaderTemplate = headerTemplate,
                    Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                    CellTemplate = cellTemplate

                };
                // Добавление столбца в таблицу
                DGridSchedule.Columns.Add(ColumnTemplate);
            }
            DGridSchedule.ItemsSource = appointment;
            
        }

        private void BtnAppointment_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var currentControl = sender as UserControls.ScheduleAppointmentControl;
            var currentAppointment = currentControl.DataContext as Entites.ScheduleAppointment;

            if (currentAppointment != null && currentAppointment.ScheduleId > 0
                && currentAppointment.AppointmentType == Entites.AppointmentType.Free)
            {
                App.DataBase.Appointments.Add(new Entites.Appointment
                {
                    DoctorScheduleId = currentAppointment.ScheduleId,
                    StartTime = currentAppointment.StartTime,
                    EndTime = currentAppointment.EndTime,
                    ClientId = 1
                }
                    );
                App.DataBase.SaveChanges();
                MessageBox.Show("Вы записаны на прием");
                ComboDoctor_SelectionChanged(ComboDoctor, null);
            }
        }
    }


}
