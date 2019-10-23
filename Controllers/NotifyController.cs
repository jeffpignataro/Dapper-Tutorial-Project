using System;
public static class NotifyController
{
    public static void Send(Person person, Meeting meeting){
        Console.WriteLine($"{person.Name} is registered for {meeting.Name}.");
    }
}