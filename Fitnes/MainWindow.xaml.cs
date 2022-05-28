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

namespace Fitnes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // загружаем тренеров для выбора в списке
            ComboTrainer.ItemsSource = App.DataBase.Trainers.ToList();
            ComboTrainer.SelectedIndex = 0;

        }

        private void ComboTrainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedTrainer = ComboTrainer.SelectedItem as Entites.Trainer; // выбранный тренер
            // проверка если выбран тренер
            if (SelectedTrainer != null)
            {
                GenerateSchedule(SelectedTrainer);
            }
        }

        private void GenerateSchedule(Entites.Trainer SelectedTrainer)
        {
            var StartDate = DateTime.Now.Date;  // начальная дата - сегодня
            var EndDate = StartDate.AddDays(7); // расписание на неделю, т.к. 7 дней

            var ScheduleGenerator = new Utils.ScheduleGenerator(StartDate, EndDate,
                 SelectedTrainer.WorkDays.ToList());

            var headers = ScheduleGenerator.GenerateHeaders(); // инициилизация заголовков 
            var appointments = ScheduleGenerator.GenerateAppointments(headers);
             
           
             LoadSchedule(headers, appointments );                // запуск процедуры загрузки расписания

        }


        private void LoadSchedule(List<Entites.ScheduleHeader> headers, 
                   List<List<Entites.ScheduleAppointment>> appointment)
            {
            DGridSchedule.Columns.Clear();                      // очистка столбцов
            for (int i = 0; i < headers.Count(); i++)           // проход каждого заголовка
            {
                // Фабрика для настройки заголовков
                FrameworkElementFactory headerFactory =
                    new FrameworkElementFactory(typeof(User_Controls.HeaderControl));
                headerFactory.SetValue(DataContextProperty, headers[i]);

                // Шаблон заголовка
                var headerTemplate = new DataTemplate
                {
                    VisualTree = headerFactory
                };

                // Фабрика настройки ячейки
                FrameworkElementFactory cellFactory =
                new FrameworkElementFactory(typeof(User_Controls.AppointmentControl));

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
            var currentControl = sender as User_Controls.AppointmentControl;
            var currentAppointment = currentControl.DataContext as Entites.ScheduleAppointment;

            if (currentAppointment != null && currentAppointment.ScheduleId > 0
                && currentAppointment.AppointmentType == Entites.AppointmentType.Free)
            {
                App.DataBase.Registrations.Add(new Entites.Registration
                {
                    Id = currentAppointment.ScheduleId,
                    StartTime = currentAppointment.StartTime,
                    EndTime = currentAppointment.EndTime,
                    Date = currentAppointment.Date,
                    Trainer = currentAppointment.Trainer
                }
                    );
                try
                {
                    App.DataBase.SaveChanges();
                }
                catch { MessageBox.Show(currentAppointment.ScheduleId.ToString()); };


                MessageBox.Show("Вы записаны на занятие");
                ComboTrainer_SelectionChanged(ComboTrainer, null);
                }
        }

    }





    /*
       
    /////////////////
                    

                
   


    /////////////
       
    
        

        
      var appointment = ScheduleGenerator.GenerateAppointments(headers); // инициилизация записей в расписании
            
         
       
    */

}
