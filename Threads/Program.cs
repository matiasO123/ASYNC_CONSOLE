// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Threads;

//Initial configs
Designer.Initial_Config();
The_Looper tl = new The_Looper();
Stopwatch sw = Stopwatch.StartNew();
Console.WriteLine("Hello, this is a practical exampe of how asincronism and threads work");
Thread.Sleep(3000);
Designer.Separator();
//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
Console.WriteLine("CHAPTER 1 - SIMPLE LOOPS");
Designer.Separator();
//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
Thread.Sleep(3000);

One_Loop(tl, sw);

two_loops(tl, sw);

Two_loops_parallels(tl, sw);

Four_Loops(tl, sw);

Task task11, task21, task3, task4;

Four_Loops_parallels(tl, sw, out task11, out task21, out task3, out task4);

//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
Console.Clear();
Designer.Separator();
Console.WriteLine("CHAPTER 2 - LOOPS AND PRINTINGS");
Designer.Separator();
//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------

long until;

int steps;

Four_loops_writing(tl, sw, out until, out steps);

Four_loops_writing_parallels(tl, sw, out task11, out task21, out task3, out task4, until, steps);

four_loops_writing_more(tl, sw, out until, out steps);

Four_loops_writing_more_parallels(tl, sw, out task11, out task21, out task3, out task4, until, steps);

Four_loops_writing_much_more(tl, sw, out until, out steps);

Four_loops_writing_much_more_parallels(tl, sw, out task11, out task21, out task3, out task4, until, steps);

Four_loops_writing_less_processing_much(tl, sw, out until, out steps);

Four_loops_writing_less_processing_much_parellels(tl, sw, out task11, out task21, out task3, out task4, until, steps);

Four_loops_writing_less_processing_even_more(tl, sw, out until, out steps);

Four_loops_writing_less_processing_even_more_parellels(tl, sw, out task11, out task21, out task3, out task4, until, steps);
Console.Clear();

//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
Designer.Separator();
Console.WriteLine("CHAPTER 3 - DELAYS AND ASYNCHONISM");
Designer.Separator();
//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------

Barman barman = new Barman();
Barman_secuential(sw, barman);
Barman_parallel();
//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
//------------------------------------------------------------------------
Thread.Sleep(5000);
Console.WriteLine("Thanks for participate of this little tutorial!!");
Thread.Sleep(5000);




void Barman_parallel()
{
    Console.WriteLine("The next round, the barman will try to make the drink, while the snack is warming up. Lets see the results");
    Console.WriteLine("Press any button to start");
    Console.ReadKey();
    sw = Stopwatch.StartNew();
    sw.Restart();
    Task.Run(async () =>
    {
        Task<bool> tbool = barman.Warm_Up_Snack_Async();
        Task<bool> t2bool = barman.Make_Coctel_Async();
        bool boolResult = await t2bool;
    }).GetAwaiter().GetResult();
    sw.Stop();
    Console.WriteLine("Final time in miliseconds: " + sw.ElapsedMilliseconds);
    Thread.Sleep(3000);
    Console.WriteLine("As we can see, the asinchronism is better than stay looking and the snack warming up!!");
}


static void One_Loop(The_Looper tl, Stopwatch sw)
{
    //First test
    Console.WriteLine("Lets execute a loop and take the time");
    Console.WriteLine("The loop go from 0 to " + tl.until);
    Thread.Sleep(3000);
    Console.WriteLine("Press a button and check the time");
    Console.ReadKey();
    sw.Restart();
    tl.Only_Loop();
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Designer.Separator();
    Thread.Sleep(3000);
}

static void two_loops(The_Looper tl, Stopwatch sw)
{
    //Starting second test
    Console.WriteLine("Lets checks what happens if we run the same loop twice (remember to press a button)");
    Console.ReadKey();
    sw.Restart();
    for (int i = 0; i < 2; i++) tl.Only_Loop();
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Console.WriteLine("As you can see, the time is not exactly twice. It is due to several factor that are beyond this test");
    Designer.Separator();
    Thread.Sleep(3000);
}

static void Two_loops_parallels(The_Looper tl, Stopwatch sw)
{
    //Third test
    Console.WriteLine("Lets checks what happens if we run the same loop twice, but at the same time");
    Console.ReadKey();
    sw.Restart();
    Task task1 = Task.Run(() => tl.Only_Loop());
    Task task2 = Task.Run(() => tl.Only_Loop());
    // Wait for both tasks to complete
    Task.WaitAll(task1, task2);
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Console.WriteLine("As you can see, the time is less than the previous test. this proves that parallelism is, in most cases, faster");
    Designer.Separator();
    Thread.Sleep(3000);
}

static void Four_Loops(The_Looper tl, Stopwatch sw)
{
    //Starting fourth test
    Console.WriteLine("Lets checks what happens if we run the same loop four times, but one after another");
    Console.ReadKey();
    sw.Restart();
    for (int i = 0; i < 4; i++) tl.Only_Loop();
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Designer.Separator();
    Thread.Sleep(3000);
}

static void Four_Loops_parallels(The_Looper tl, Stopwatch sw, out Task task11, out Task task21, out Task task3, out Task task4)
{
    //fifth test
    Console.WriteLine("Lets checks what happens if we run the same loop four times, but at the same time");
    Console.ReadKey();
    The_Looper tl1 = new The_Looper();
    sw.Restart();
    task11 = Task.Run(() => tl.Only_Loop());
    task21 = Task.Run(() => tl.Only_Loop());
    task3 = Task.Run(() => tl.Only_Loop());
    task4 = Task.Run(() => tl.Only_Loop());
    // Wait for both tasks to complete
    Task.WaitAll(task11, task21, task3, task4);
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Console.WriteLine("Now we can see a bigger diffence of time! this is due to parallelism");
    Designer.Separator();
    Thread.Sleep(3000);
    Thread.Sleep(3000);
}

static void Four_loops_writing(The_Looper tl, Stopwatch sw, out long until, out int steps)
{
    Thread.Sleep(1000);
    Console.WriteLine("lets go with different test. Until now we have been testing with loops. Let´s combine it with write operations and let´s check what happens...");
    //Starting sixth test
    Thread.Sleep(5000);
    Console.WriteLine("Lets run the loop four times, one after another. Now the loop will write some number of the loop in the console");
    until = 10000;
    steps = 100;
    Console.WriteLine("The loop will run from 0 to " + until + " and only will print the number jumping on " + steps);
    Console.ReadKey();
    sw.Restart();
    for (int i = 0; i < 4; i++) tl.Loop_and_writeLine(until, steps);
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Designer.Separator();
}

static void Four_loops_writing_parallels(The_Looper tl, Stopwatch sw, out Task task11, out Task task21, out Task task3, out Task task4, long until, int steps)
{
    //seventh test
    Console.WriteLine("Lets run the same loop four times, but at the same time");
    Console.ReadKey();
    tl = new The_Looper();
    sw.Restart();
    task11 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task21 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task3 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task4 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    // Wait for all tasks to complete
    Task.WaitAll(task11, task21, task3, task4);
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Thread.Sleep(3000);
    Console.WriteLine("We might see a difference between both processes");
    Designer.Separator();
    Thread.Sleep(3000);
}

static void four_loops_writing_more(The_Looper tl, Stopwatch sw, out long until, out int steps)
{
    // test 8
    Console.WriteLine("Lets run the loop four times, one after another. But lets increase the number of printings");
    until = 10000;
    steps = 1;
    Console.WriteLine("The loop will run from 0 to " + until + " and only will print the number jumping on " + steps);
    Console.ReadKey();
    sw.Restart();
    for (int i = 0; i < 4; i++) tl.Loop_and_writeLine(until, steps);
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Designer.Separator();
}

static void Four_loops_writing_more_parallels(The_Looper tl, Stopwatch sw, out Task task11, out Task task21, out Task task3, out Task task4, long until, int steps)
{
    //test 9
    Console.WriteLine("Lets run the same loop four times, but at the same time");
    Console.ReadKey();
    tl = new The_Looper();
    sw.Restart();
    task11 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task21 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task3 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task4 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    // Wait for all tasks to complete
    Task.WaitAll(task11, task21, task3, task4);
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Thread.Sleep(3000);
    Console.WriteLine("Now the secuential process is faster. this is due to conflict between the tasks while trying to write in the same place! They have to wait until the previous task releases the writing property in the console!");
    Designer.Separator();
    Thread.Sleep(3000);
}

static void Four_loops_writing_much_more(The_Looper tl, Stopwatch sw, out long until, out int steps)
{
    // test 10
    Console.WriteLine("Lets run the loop four times, one after another. But lets increase the 'until' and the 'steps' numbers of the loop");
    until = 10000000;
    steps = 1000;
    Console.WriteLine("The loop will run from 0 to " + until + " and only will print the number jumping on " + steps);
    Console.ReadKey();
    sw.Restart();
    for (int i = 0; i < 4; i++) tl.Loop_and_writeLine(until, steps);
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Designer.Separator();
    Thread.Sleep(3000);
}

static void Four_loops_writing_much_more_parallels(The_Looper tl, Stopwatch sw, out Task task11, out Task task21, out Task task3, out Task task4, long until, int steps)
{

    //test 11
    Console.WriteLine("Lets run the same loop four times, but at the same time");
    Console.ReadKey();
    tl = new The_Looper();
    sw.Restart();
    task11 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task21 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task3 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task4 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    // Wait for all tasks to complete
    Task.WaitAll(task11, task21, task3, task4);
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Console.WriteLine("Now the secuential process is still faster. this is due to conflict between the tasks while trying to write in the same place! They have to wait until the previous task releases the writing property in the console!");
    Designer.Separator();
}

static void Four_loops_writing_less_processing_much(The_Looper tl, Stopwatch sw, out long until, out int steps)
{
    Thread.Sleep(3000);
    // test 12
    Console.WriteLine("Lets run the loop four times, one after another. But lets increase 'steps' numbers of the loop");
    until = 10000000;
    steps = 100000;
    Console.WriteLine("The loop will run from 0 to " + until + " and only will print the number jumping on " + steps);
    Console.ReadKey();
    sw.Restart();
    for (int i = 0; i < 4; i++) tl.Loop_and_writeLine(until, steps);
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Designer.Separator();
}

static void Four_loops_writing_less_processing_much_parellels(The_Looper tl, Stopwatch sw, out Task task11, out Task task21, out Task task3, out Task task4, long until, int steps)
{
    Thread.Sleep(3000);
    //test 13
    Console.WriteLine("Lets run the same loop four times, but at the same time");
    Console.ReadKey();
    tl = new The_Looper();
    sw.Restart();
    task11 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task21 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task3 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task4 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    // Wait for all tasks to complete
    Task.WaitAll(task11, task21, task3, task4);
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Console.WriteLine("Now the parallel process is faster. this is because the proccess takes longer than the conflicts while writing. Now there are less writing conflicts");
    Designer.Separator();
    Thread.Sleep(3000);
}

static void Four_loops_writing_less_processing_even_more(The_Looper tl, Stopwatch sw, out long until, out int steps)
{
    // test 14
    Console.WriteLine("Lets run the loop one last time, four times, one after another. But lets increase the until and the 'steps' numbers of the loop");
    until = 1000000000;
    steps = 10000000;
    Console.WriteLine("The loop will run from 0 to " + until + " and only will print the number jumping on " + steps);
    Console.ReadKey();
    sw.Restart();
    for (int i = 0; i < 4; i++) tl.Loop_and_writeLine(until, steps);
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Designer.Separator();
    Thread.Sleep(3000);
}

static void Four_loops_writing_less_processing_even_more_parellels(The_Looper tl, Stopwatch sw, out Task task11, out Task task21, out Task task3, out Task task4, long until, int steps)
{
    //test 15
    Console.WriteLine("Lets run the same loop four times, but at the same time");
    Console.ReadKey();
    tl = new The_Looper();
    sw.Restart();
    task11 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task21 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task3 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    task4 = Task.Run(() => tl.Loop_and_writeLine(until, steps));
    // Wait for all tasks to complete
    Task.WaitAll(task11, task21, task3, task4);
    sw.Stop();
    Console.WriteLine("Time in miliseconds: " + sw.ElapsedMilliseconds);
    Thread.Sleep(3000);
    Console.WriteLine("Now the parallel process is even faster. this is because the proccess takes much longer than the conflicts while writing. Now we can see a very notable difference...");
    Designer.Separator();
    Thread.Sleep(3000);
    Thread.Sleep(3000);
    Thread.Sleep(3000);
}

static void Barman_secuential(Stopwatch sw, Barman barman)
{
    Console.WriteLine("Now we have a barman who is cooking and making drinks");
    Thread.Sleep(3000);
    Console.WriteLine("Lets imagine we have a snack that must be warmed up and takes 3 seconds. And then the barman has to make a coctel that takes 3 seconds");
    Thread.Sleep(3000);
    Console.WriteLine("First test will be secuential one");
    Console.WriteLine("Press any button to start");
    Console.ReadKey();
    barman = new Barman();
    sw = Stopwatch.StartNew();
    sw.Restart();
    barman.Warm_Up_Snack();
    Thread.Sleep(500);
    barman.Make_Coctel();
    sw.Stop();
    Console.WriteLine("Final time in miliseconds: " + sw.ElapsedMilliseconds);
    Designer.Separator();
    Thread.Sleep(3000);
}