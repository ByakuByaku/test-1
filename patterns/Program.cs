// See https://aka.ms/new-console-template for more information

using patterns;
using System.Security.Cryptography;

logger.Instance.setminlogLevel(logLevel.Debug);

logger.Instance.LogInformation("Приложение запущено");
logger.Instance.LogWarning("Это предупреждение");
logger.Instance.LogError("Это ошибка");

