//Attendance Mediator Class
public abstract class AttendanceMediator
{
    public abstract void Register(Person person, Meeting meeting);
    public abstract void Notify(Person person, Meeting meeting);

}