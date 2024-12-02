namespace com.tttoe.runtime.Interfaces
{
    public interface IProvider<out T>
    {
        T Get();
    }

    public interface IProvider<in TParam, out TResult>
    {
        TResult Get(TParam param);
    }
}