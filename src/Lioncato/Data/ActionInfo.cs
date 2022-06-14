#nullable disable

namespace Lioncato.Data;

public record ActionInfo<T>
{
    public T Result { get; set; }
    public ActionType Type { get; set; }

    public ActionInfo(ActionType type, T rs)
    {
        Result = rs;
        Type = type;
    }
}