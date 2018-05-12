using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leccion4_PSC_Barrier
{
    class Program
    {
        static void Main(string[] args)
        {
            UseBarrier();
            Console.WriteLine("Presione <enter> para finalizar");
            Console.Read();
        }

        static void UseBarrier()
        {
            int SignalsCount = 0;
            Barrier B = new Barrier(4, barrier =>
            {
                Console.WriteLine($"Se ha completado la fase {barrier.CurrentPhaseNumber + 1}, " +
                    $"número de señalizaciones: {SignalsCount}");
            });

            Console.WriteLine($"Número de participantes, antes de invocar a AddParticipant: {B.ParticipantCount}");

            B.AddParticipants(2);

            Console.WriteLine($"Número de participantes, después de invocar a AddParticipants: {B.ParticipantCount}");

            B.RemoveParticipant();

            Console.WriteLine($"Número de participantes, después de invocar a RemoveParticipant: {B.ParticipantCount}");

            Action<string> ConcurrentAction = delegate (string subOperacion)
            {
                Console.WriteLine($"Iniciando fase 1 - {subOperacion}");
                Thread.Sleep(3000);
                Console.WriteLine($"Finalizando ejec fase 1 - {subOperacion}");
                Interlocked.Increment(ref SignalsCount);
                B.SignalAndWait();
                Console.WriteLine($"Iniciando fase 2 - {subOperacion}");
                Thread.Sleep(3000);
                Console.WriteLine($"Finalizando ejec fase 2 - {subOperacion}");
                Interlocked.Increment(ref SignalsCount);
                B.SignalAndWait();
                Console.WriteLine($"Iniciando fase 3 - {subOperacion}");
                Thread.Sleep(3000);
                Console.WriteLine($"Finalizando ejec fase 3 - {subOperacion}");
                Interlocked.Increment(ref SignalsCount);
                B.SignalAndWait();
            };

            Parallel.Invoke(() => ConcurrentAction("sub operacion 1"), () => ConcurrentAction("sub operacion 2"), () => ConcurrentAction("sub operacion 3"),
                () => ConcurrentAction("sub operacion 4"), () => ConcurrentAction("sub operacion 5"));

            B.Dispose();
        }
    }
}
