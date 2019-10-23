using System;
using System.ComponentModel.DataAnnotations;

public class Meeting
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public Meeting()
    {

    }
    public Meeting(int id, string name, string location, DateTime startDateTime, DateTime endDateTime)
    {
        Id = id;
        Name = name;
        Location = location;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
    }

}