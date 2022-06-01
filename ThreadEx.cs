/*
    INTRODUCTION TO USING THREADS IN C# (for multi-threading in applications)    
    From: https://www.javatpoint.com/c-sharp-multithreading    
    and https://www.tutorialspoint.com/the-benefits-of-multithreaded-programming

    Multithreading
    Multithreading allows the execution of multiple threads of a program to work simultaneously (or seemingly so).
    It is useful in environments where resources (e.g. memory, data, files) are shared.
    For example, a web browser with multithreading can use one thread for user contact and another for image downloading at the same time
    To create multithreaded application in C#, we need to use System.Threading namespace.
    
    System.Threading Namespace
    The System.Threading namespace contains classes and interfaces to provide the facility of multithreaded programming. It also provides classes to synchronize the thread resource. A list of commonly used classes are given below:

    Thread
    Mutex
    Timer
    Monitor
    Semaphore
    ThreadLocal
    ThreadPool
    Volatile etc.

    Process and Thread
    A process represents an application whereas a thread represents a module of the application. 
    Process is heavyweight component whereas thread is lightweight. 
    A thread can be termed as lightweight subprocess because it is executed inside a process.

    Whenever you create a process, a separate memory area is occupied. But threads share a common memory area.

    C# Thread Life Cycle
    In C#, each thread has a life cycle. 
    The life cycle of a thread is started when instance of System.Threading.Thread class is created. 
    When the task execution of the thread is completed, its life cycle is ended.

    There are following states in the life cycle of a Thread in C#.

    Unstarted
    Runnable (Ready to run)
    Running
    Not Runnable
    Dead (Terminated)
    Unstarted State
    When the instance of Thread class is created, it is in unstarted state by default.

    Runnable State
    When start() method on the thread is called, it is in runnable or ready to run state.

    Running State
    Only one thread within a process can be executed at a time. 
    At the time of execution, thread is in running state.

    Not Runnable State
    The thread is in not runnable state, if sleep() or wait() method is called on the thread, or input/output operation is blocked.

    Dead State
    After completing the task, thread enters into dead or terminated state.

    C# Thread class
    C# Thread class provides properties and methods to create and control threads. It is found in System.Threading namespace.

    Class Properties

    CurrentThread	returns the instance of currently running thread.
    IsAlive	        checks whether the current thread is alive or not. 
                    It is used to find the execution status of the thread.
    IsBackground	is used to get or set value whether current thread is in background or not.
    ManagedThreadId	is used to get unique id for the current managed thread.
    Name	        is used to get or set the name of the current thread.
    Priority	    is used to get or set the priority of the current thread.
    ThreadState	    is used to return a value representing the thread state.

    Class Methods

    Abort()	        is used to terminate the thread. It raises ThreadAbortException.
    Interrupt()	    is used to interrupt a thread which is in WaitSleepJoin state.
    Join()	        is used to block all the calling threads until this thread terminates.
    ResetAbort()	is used to cancel the Abort request for the current thread.
    Resume()	    is used to resume the suspended thread. It is obselete.
    Sleep(Int32)	is used to suspend the current thread for the specified milliseconds.
    Start()	        changes the current state of the thread to Runnable.
    Suspend()	    suspends the current thread if it is not suspended. It is obselete.
    Yield()	        is used to yield the execution of current thread to another thread.

*/


using System;
using System.Threading;


namespace ThreadExample
{
   // MyThread class --- contains a simple Countdown() method from 10 to 0
    public class MyThread
    {
        public void Countdown ()
        {
            /*
                Synchronization is a technique that allows only one thread to access the resource for the particular time. 
                No other thread can interrupt until the assigned thread finishes its task.
                
                In multithreading program, threads are allowed to access any resource for the required execution time. 
                Threads share resources and executes asynchronously. 
                Accessing shared resources (data) is critical task that sometimes may halt the system. 
                We deal with it by making threads synchronized.

                Advantages: consistency is maintained and there is no interference between threads
                Used in transactions like deposits and withdrawals

                C# uses the 'lock' keyword to execute program synchronously. 
                It is used to get lock for the current thread, execute the task and then release the lock. 
                It ensures that other thread does not interrupt the execution until the execution is finished
            */
            //lock (this);
            Thread t = Thread.CurrentThread;
            Console.WriteLine(t.Name + " has started");

            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine(t.Name + " - " + i);
                // Sleep() method suspends the current thread for the specified milliseconds 
                // This is done to allow other threads get the chance to start execution
                //Thread.Sleep(300);
            }

            Console.WriteLine(t.Name + " has ended");
        }
    }

    class ThreadEx
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of Main() method");

            // Create instance of MyThread class
            // NOTE: This is needed so that we can run a non-static Countdown() method inside our static Main() method
            // mt is stand for MyThread
			MyThread mt = new MyThread();

            // Set up 3 thread objects to run their own separate countdown
            Thread t1 = new Thread(new ThreadStart(mt.Countdown));
            Thread t2 = new Thread(new ThreadStart(mt.Countdown));
            Thread t3 = new Thread(new ThreadStart(mt.Countdown));

            // Set up names for each thread
            t1.Name = "Thread01";
            t2.Name = "Thread02";
            t3.Name = "Thread03";

            // Set priority levels for each thread
            // NOTE: This is not guaranteed because thread execution is highly system-dependent
            //t3.Priority = ThreadPriority.Highest;
            //t2.Priority = ThreadPriority.Normal;
            //t1.Priority = ThreadPriority.Lowest;

            // Start() method is used to start the thread
            t1.Start();
            // Join() method causes all the calling threads to wait until the current thread (joined thread) 
            // is terminated or completes its task
            //t1.Join();
            t2.Start();
            t3.Start();

            
            /*
            try
            {
                // Abort() method is used to terminate the thread
                t1.Abort();
                t2.Abort();
                t3.Abort();
            }
            catch (ThreadAbortException tae)
            {
                Console.WriteLine(tae.ToString());
            }

            Console.WriteLine(t1.Name + " status: " + t1.IsAlive);
            Console.WriteLine(t2.Name + " status: " + t2.IsAlive);
            Console.WriteLine(t3.Name + " status: " + t3.IsAlive);
            */
            Console.WriteLine("End of Main() method");
            Console.WriteLine("\n\nEnter any key to exit!");
            string anyKey = Console.ReadLine();

        }
    }
}
