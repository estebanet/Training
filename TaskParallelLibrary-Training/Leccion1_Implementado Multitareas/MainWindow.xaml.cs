using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Leccion1_Implementado_Multitareas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource CTS;
        CancellationToken CT;
        Task LongRunningTask;

        public MainWindow()
        {
            InitializeComponent();
            //CreateTask();
            //RunTaskGroup();
            //ReturnTaskValue();
        }

        void CreateTask()
        {
            //INI - Ejercicio 1.
            Task T;
            // T = new Task(ShowMessage);
            //T = new Task(new Action(ShowMessage));
            Action ActionDelegate = new Action(ShowMessage);
            T = new Task(ActionDelegate);
            Action ActionDelegate2 = delegate
            {
                MessageBox.Show("Ejecutando método anónimo");
            };

            Task T2 = new Task(ActionDelegate2);

            Action ActionDelegate3 = () => ShowMessage();
            Task T3 = new Task(ActionDelegate3);
            Task T6 = new Task(objectParameter => MessageBox.Show(objectParameter.ToString()),
                "Ejecutando Tarea con expresión lambda con parámetro");
            //FIN - Ejercicio 1.

            //INI - Ejercicio 2.
            Task T7 = new Task(() => AddMessage("Ejecutando tarea"));
            T7.Start();
            AddMessage("En el hilo principal");

            Task T8 = Task.Factory.StartNew(() => AddMessage("Tarea iniciada con TaskFactory"));

            Task T9 = Task.Run(() => AddMessage("Tarea ejecutado con Task.Run"));

            Task.Run(delegate
            {
                Task T10 = Task.Run(() =>
                {
                    AddMessage("Iniciando tarea 10...");
                    Thread.Sleep(10000);
                    AddMessage("Finalizando tarea 10");
                });

                AddMessage("Esperando a la tarea 10");
                T10.Wait();
                AddMessage("La tarea finalizó su ejecución");
            });
        }

        //Ejercicio 2
        void RunTaskGroup()
        {
            Task[] TaskGroup =
            {
                Task.Run(() => RunTask(1)),
                Task.Run(() => RunTask(2)),
                Task.Run(() => RunTask(3)),
                Task.Run(() => RunTask(4)),
                Task.Run(() => RunTask(5))
            };

            WriteToOutput("Esperando a que se ejecute al menos una tarea");
            int TaskNumber = Task.WaitAny(TaskGroup);
            WriteToOutput("Se ha ejecutado al menos la tarea " + TaskNumber);
        }

        void RunTask(byte taskNumber)
        {
            WriteToOutput($"Iniciando tarea {taskNumber}");
            Thread.Sleep(10000);
            WriteToOutput($"Tarea {taskNumber} finalizada");
        }

        void WriteToOutput(string message)
        {
            System.Diagnostics.Debug.WriteLine(
                $"Mensaje: {message}, " +
                $"Hilo: {Thread.CurrentThread.ManagedThreadId}" +
                $"{Environment.NewLine}");
        }

        void ShowMessage() => MessageBox.Show("Ejecutando método ShowMessage");

        void AddMessage(string message)
        {
            int ThreadId = Thread.CurrentThread.ManagedThreadId;
            this.Dispatcher.Invoke(() => Messages.Content +=
                $"Mensaje: {message}, " +
                $"Hilo: {ThreadId}{Environment.NewLine}");
        }

        //Ejercicio 3
        void ReturnTaskValue()
        {
            Task<int> T;

            T = Task.Run<int>(() => new Random().Next(1000));
            WriteToOutput($"Valor devuelto por la tarea {T.Result}");

            //Task<int> T2 = Task<int>.Run<int>(delegate
            //{
            //    WriteToOutput("Generando un número aleatorio");
            //    Thread.Sleep(10000);
            //    return new Random().Next(1000);
            //});

            Task<int> T2;
            T2 = new Task<int>(() =>
            {
                WriteToOutput("Generando un número aleatorio");
                Thread.Sleep(10000);
                return new Random().Next(1000);
            });
            T2.Start();
            
            WriteToOutput("Esperando por la tarea 2");
            WriteToOutput($"Valor devuelto por la tarea 2 {T2.Result}");
            WriteToOutput("Fin del método ReturnTaskValue");
        }

        //Ejercicio 4
        private void StartTask_Click(object sender, RoutedEventArgs e)
        {
            CTS = new CancellationTokenSource();
            CT = CTS.Token;
            Task.Run(() =>
            {
                LongRunningTask = Task.Run(() =>
                {
                    DoLongRunningTask(CT);
                }, CT);

                try
                {
                    LongRunningTask.Wait();
                }
                catch (AggregateException ae)
                {
                    foreach (var Inner in ae.InnerExceptions)
                    {
                        if (Inner is TaskCanceledException)
                        {
                            AddMessage("Tarea cancelada y TaskCanceledException manejado");
                        }
                        else
                        {
                            AddMessage($"Exepción: {Inner.Message}");
                        }
                    }
                }
            });
        }

        private void DoLongRunningTask(CancellationToken cT)
        {
            int[] IntsArray = Enumerable.Range(1, 10).ToArray();
            for(int i = 0; i < IntsArray.Length && !cT.IsCancellationRequested; i++)
            {
                AddMessage($"Proceso {IntsArray[i]}");
                Thread.Sleep(2000);
            }
            if (cT.IsCancellationRequested)
            {
                //Lógica para terminar la tarea de forma apropiada.
                AddMessage("Proceso cancelado");
                cT.ThrowIfCancellationRequested();
                //throw new OperationCanceledException();
            }
        }

        //Ejercicio 4
        private void CancelTask_Click(object sender, RoutedEventArgs e)
        {
            if (CTS != null)
            {
                CTS.Cancel();
            }
        }

        //Ejercicio 4
        private void ShowTaskStatus_Click(object sender, RoutedEventArgs e)
        {
            if(LongRunningTask != null)
            {
                AddMessage($"Estatus de tarea: {LongRunningTask.Status}");
            }
        }
    }
}
