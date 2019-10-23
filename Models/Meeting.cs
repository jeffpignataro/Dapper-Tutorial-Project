using System;

public class Meeting
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public Meeting()
    {

    }
    public Meeting(string name, string location, DateTime startDateTime, DateTime endDateTime)
    {
        Name = name;
        Location = location;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
    }

}