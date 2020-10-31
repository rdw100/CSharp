using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CSharp.CQRS.Demo
{
    /// <summary>
    /// Represents a patient using command query responsiblity segregation, event sourcing
    /// </summary>
    public class Patient
    {
        private int age;
        EventBroker broker;
        public Patient(EventBroker broker)
        {
            this.broker = broker;
            broker.Commands += BrokerOnCommands; // Listen to an event
            broker.Queries += BrokerOnQueries; // Subscribe to an event 
        }

        private void BrokerOnQueries(object sender, Query query)
        {
            var ac = query as AgeQuery;
            if (ac != null && ac.Target == this)
            {
                ac.Result = age;
            }
        }

        private void BrokerOnCommands(object sender, Command command)
        {
            var cac = command as ChangeAgeCommand;
            if (cac != null && cac.Target ==this)
            {
                // Send event before we assign an age, register to suppress removed changes
                if (cac.Register) broker.AllEvents.Add(new AgeChangedEvent(this, age, cac.Age));
                age = cac.Age;
            }
        }
    }

    /// <summary>
    /// Stores events behaves like a message broker.
    /// </summary>
    public class EventBroker
    {
        public IList<Event> AllEvents = new List<Event>();

        public event EventHandler<Command> Commands;
 
        public event EventHandler<Query> Queries;

        public void Command(Command c)
        {
            Commands.Invoke(this, c);
        }

        public T Query<T>(Query q)
        {
            Queries.Invoke(this, q);
            return (T) q.Result;
        }

        public void UndoLast()
        {
            var e = AllEvents.LastOrDefault();
            var ac = e as AgeChangedEvent;
            if (ac != null)
            {
                Command(new ChangeAgeCommand(ac.Target, ac.OldValue) { Register = false });
                AllEvents.Remove(e);
            }
        }
    }


    /// <summary>
    /// Returns data.
    /// </summary>
    /// <remarks>
    /// Cannot change data.
    /// </remarks>
    public class Query
    {
        public object Result;
    }

    /// <summary>
    /// Returns data for Age.
    /// </summary>
    /// <seealso cref="CSharp.CQRS.Demo.Query" />
    public class AgeQuery : Query
    {
        public Patient Target;
    }

    /// <summary>
    /// Performs an action.
    /// </summary>
    /// <remarks>
    /// Cannot return data.
    /// </remarks>
    /// <seealso cref="System.EventArgs" />
    public class Command : EventArgs
    {
        public bool Register = true;
    }

    /// <summary>
    /// Command performs change age action.
    /// </summary>
    /// <seealso cref="CSharp.CQRS.Demo.Command" />
    class ChangeAgeCommand : Command 
    {
        public Patient Target;
        public int Age;
        public ChangeAgeCommand(Patient target, int age)
        {
            Target = target;
            Age = age;
        }
    }

    /// <summary>
    /// Tracks changes to the object.
    /// </summary>
    public class Event
    {

    }

    /// <summary>
    /// Tracks changes to Age.
    /// </summary>
    /// <seealso cref="CSharp.CQRS.Demo.Event" />
    public class AgeChangedEvent : Event
    {
        public Patient Target;
        public int OldValue, NewValue;
        public AgeChangedEvent(Patient target, int oldValue, int newValue)
        {
            Target = target;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return $"Age changed from {OldValue} to {NewValue}";
        }
    }

    /// <summary>
    /// Overview of CQRS Event Sourcing
    /// </summary>
    class Program
    {
        static void Main()
        {
            var eb = new EventBroker();
            var p = new Patient(eb);
            eb.Command(new ChangeAgeCommand(p, 65));

            foreach (var e in eb.AllEvents)
            {
                Console.WriteLine(e);
            }

            int age;
            age = eb.Query<int>(new AgeQuery {Target = p});
            Console.WriteLine(age);

            // Get rid of last event
            eb.UndoLast();

            // Print all events
            foreach (var e in eb.AllEvents)
            {
                Console.WriteLine(e);
            }

            age = eb.Query<int>(new AgeQuery { Target = p });
            Console.WriteLine(age);

            Console.ReadKey();
        }
    }
}