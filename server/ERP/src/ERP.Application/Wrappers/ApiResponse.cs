namespace ERP.Application.Wrappers;

public class ApiResponse<T>
{
    public bool Succeeded { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();
    public T? Data { get; set; }

    public static ApiResponse<T> Success(T data, string message = "")
        => new() { Succeeded = true, Data = data, Message = message };

    public static ApiResponse<T> Failure(string message, List<string>? errors = null)
        => new() { Succeeded = false, Message = message, Errors = errors ?? new() };
}