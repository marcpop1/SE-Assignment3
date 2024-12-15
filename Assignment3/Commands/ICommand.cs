namespace Assignment3.Commands;

public interface ICommand<out T>
{
    public T Execute();
}
