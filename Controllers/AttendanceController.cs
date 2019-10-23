using System;
using System.Collections.Generic;

public class AttendanceController : AttendanceMediator
{
    private Dictionary<string, Person> _attendees = new Dictionary<string, Person>();

    public Dictionary<string, Person> Attendees { get => _attendees; set => _attendees = value; }

    public override void Notify(Person person, Meeting meeting)
    {
        //Don't be static! 
        NotifyController.Send(person, meeting);
    }

    public override void Register(Person person, Meeting meeting)
    {
        if (!Attendees.ContainsValue(person)) { 
            Attendees.Add(person.Name, person);
            Notify(person, meeting);
        }
        else{
            Console.WriteLine("Attendee is already registered for {0}", meeting.Name);
        }
    }
}