using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leccion4_PSC_ManualResetEventSlim
{
    class Program
    {
        static void Main(string[] args)
        {
            DoManualResetEventSlim();
            Console.WriteLine("Presione <enter> para continuar...");
            Console.Read();

            /*Salida esperada*/
            /*
             1) Iniciando ejecución de Tarea (T)
             2) Estado Signal de PSC-MRES M1? {M1.IsSet} (T)
             3) Estado Signal de PSC-MRES M3? {M3.IsSet} (M)
             4) "Deseñalizando a PSC-MRES M3..." (M)
             ** Los mensajes del 1-4 pueden aparecer en cualquier orden... **
             5) Estado Signal de PSC-MRES M2? {M2.IsSet} (M)
             6) Señalizando a PSC-MRES M2... (M)
             7) Estado Signal de PSC-MRES M1? {M1.IsSet} (M)
             8) Señalizando a PSC-MRES M1... (M)
             ** Los mensajes del 5-8 deben aparecer en el orden descrito (después de los mensajes 1-4).
             9) Estado Signal de PSC-MRES M3? {M3.IsSet} (M)
             10) Reanudando ejecución en Tarea (T)
             11) Estado Signal de PSC-MRES M1? {M1.IsSet} (T)
             12) Estado Signal de PSC-MRES M2? {M2.IsSet} (T)
             13) Estado Signal de PSC-MRES M3? {M3.IsSet} (T)
             14) Señalizando a PSC-MRES M3... (T)
             ** Los mensajes del 9-14 pueden aparecer en cualquier orden.... (después d elos mensajes 5-8)**
             15) Finalizando ejecución de Tarea (T)
             16) Reanudando ejecución de Thread Principal (M)
             17) Por liberar recursos de PSC-MRES's (M)
             ** Los mensajes del 15-17 pueden aparecer en cualquier orden... (después de los mensajes 9-14)**
             18) Recursos liberados (M)
             19) Finalizando ejecución de método \"DoManualResetEventSlim\" (M)
             20) Presione <enter> para continuar... (M)
             */
        }

        static void DoManualResetEventSlim()
        {
            int countInvokeShowMessageMethod = 0;
            ManualResetEventSlim M1 = new ManualResetEventSlim();
            ManualResetEventSlim M2 = new ManualResetEventSlim(false);
            ManualResetEventSlim M3 = new ManualResetEventSlim(true);

            Task T = Task.Run(() =>
            {
                ShowMessage("Iniciando ejecución de Tarea", ref countInvokeShowMessageMethod);
                ShowMessage($"Estado Signal de PSC-MRES M1? {M1.IsSet}", ref countInvokeShowMessageMethod);
                M1.Wait();
                ShowMessage($"Reanudando ejecución en Tarea", ref countInvokeShowMessageMethod);
                ShowMessage($"Estado Signal de PSC-MRES M1? {M1.IsSet}", ref countInvokeShowMessageMethod);
                ShowMessage($"Estado Signal de PSC-MRES M2? {M2.IsSet}", ref countInvokeShowMessageMethod);
                ShowMessage($"Estado Signal de PSC-MRES M3? {M3.IsSet}", ref countInvokeShowMessageMethod);
                ShowMessage($"Señalizando a PSC-MRES M3...", ref countInvokeShowMessageMethod);
                M3.Set();
                ShowMessage("Finalizando ejecución de Tarea", ref countInvokeShowMessageMethod);
            });

            ShowMessage($"Estado Signal de PSC-MRES M3? {M3.IsSet}", ref countInvokeShowMessageMethod);
            ShowMessage($"Deseñalizando a PSC-MRES M3...", ref countInvokeShowMessageMethod);
            M3.Reset();
            ShowMessage($"Estado Signal de PSC-MRES M2? {M2.IsSet}", ref countInvokeShowMessageMethod);
            ShowMessage($"Señalizando a PSC-MRES M2...", ref countInvokeShowMessageMethod);
            M2.Set();
            ShowMessage($"Estado Signal de PSC-MRES M1? {M1.IsSet}", ref countInvokeShowMessageMethod);
            ShowMessage($"Señalizando a PSC-MRES M1...", ref countInvokeShowMessageMethod);
            M1.Set();
            ShowMessage($"Estado Signal de PSC-MRES M3? {M3.IsSet}", ref countInvokeShowMessageMethod);
            M3.Wait();
            ShowMessage("Reanudando ejecución de Thread Principal", ref countInvokeShowMessageMethod);
            ShowMessage("Por liberar recursos de PSC-MRES's", ref countInvokeShowMessageMethod);
            T.Wait();
            M1.Dispose();
            M2.Dispose();
            M3.Dispose();
            ShowMessage("Recursos liberados", ref countInvokeShowMessageMethod);
            ShowMessage("Finalizando ejecución de método \"DoManualResetEventSlim\"", ref countInvokeShowMessageMethod);
        }

        static void ShowMessage(string message, ref int countInvokes)
        {
            Interlocked.Increment(ref countInvokes);
            Console.WriteLine($"{countInvokes}) {message}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
