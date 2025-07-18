namespace LeasingTestAssignment.Application.Common;

/// <summary>
/// Представляет результат операции, включая статус успешности и потенциальные сообщения об ошибках.
/// </summary>
/// <typeparam name="T">Тип результата.</typeparam>
public class ResultOfT<T>
{
    public ResultOfT(T result)
    {
        IsSuccess = true;
        Result = result;
        ErrorMessage = null;
    }

    public ResultOfT(string? errorMessage)
    {
        IsSuccess = false;
        Result = default;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Получает значение, указывающее, была ли операция успешной.
    /// </summary>
    public bool IsSuccess { get; private set; }

    /// <summary>
    /// Получает результат операции.
    /// </summary>
    public T? Result { get; private set; }

    /// <summary>
    /// Получает сообщение об ошибке, если операция завершилась неудачей.
    /// </summary>
    public string? ErrorMessage { get; private set; }

    /// <summary>
    /// Создает успешный результат.
    /// </summary>
    /// <param name="result">Результат операции.</param>
    /// <returns>Экземпляр <see cref="ResultOfT{T}"/>, указывающий на успешность.</returns>
    public static ResultOfT<T> Success(T result) => new(result);

    /// <summary>
    /// Создает неудачный результат.
    /// </summary>
    /// <param name="errorMessage">Сообщение об ошибке, связанное с неудачей.</param>
    /// <returns>Экземпляр <see cref="ResultOfT{T}"/>, указывающий на неудачу.</returns>
    public static ResultOfT<T> Fail(string? errorMessage) => new(errorMessage);
}
